using UnityEngine;
using UnityEngine.VFX;

public partial class Agent : MonoBehaviour
{
  #region Audio Settings
  [Header("Audio Settings")]
  public AudioSource audioSource;
  public AudioClip audioClip;
  public FFTWindow window;

  public const int audioHertz = 44100;
  public const int samples = 1024;
  public const float audioProfile = 0.0f;

  public const int frequencyBands = 8;

  private float[] cached_Samples;
  private float[] cached_FreqBands;
  private float[] cached_FreqBandBuffer;
  private float[] cached_FreqBufferDecrease;
  private float[] cached_FreqBandHighest;
  private float[] cached_AudioBand;
  private float[] cached_AudioBandBuffer;

  private float cached_Amplitude;
  private float cached_AmplitudeBuffer;
  private float cached_AmplitudeHighest;
  #endregion

  #region Mic Settings
  public static string micDevice;
  #endregion

  #region Audio Visualizer
  [Header("Audio Visualizer")]
  public float radiusIncrement = 0.05f;
  private float defaultRadius;
  private float noisePosition;
  #endregion

  #region Editor Stuffs
  [HideInInspector]
  public bool showAudioSettings,
  showMicSettings,
  showAudioVisualizer;
  #endregion

  void InitAudioVisualizer()
  {
    cached_Samples = new float[samples];
    cached_FreqBands = new float[frequencyBands];
    cached_FreqBandBuffer = new float[frequencyBands];
    cached_FreqBufferDecrease = new float[frequencyBands];
    cached_FreqBandHighest = new float[frequencyBands];
    cached_AudioBand = new float[frequencyBands];
    cached_AudioBandBuffer = new float[frequencyBands];
    InitializeAudioProfile(audioProfile);

    noisePosition = 0.0f;
    defaultRadius = audioVFX.GetFloat(radius);

    micDevice = Microphone.devices[0].ToString();
    audioSource.Play();
  }

  void UpdateAudioVisualizer()
  {
    GenerateFrequencyBands();
    GenerateAudioBands();
    GenerateAmplitude();

    noisePosition += cached_Amplitude * 0.1f;
    audioVFX.SetFloat(noisePositionAddition, noisePosition);
    audioVFX.SetFloat(noiseIntensity, cached_Amplitude + cached_AudioBand[0]);
    audioVFX.SetFloat(radius, defaultRadius + Mathf.Lerp(0.0f, radiusIncrement, cached_AudioBand[0]));
  }

  private void InitializeAudioProfile(float value)
  {
    for (int i = 0; i < cached_FreqBandHighest.Length; ++i)
    {
      cached_FreqBandHighest[i] = value;
    }
  }

  private void GenerateAmplitude()
  {
    cached_Amplitude = 0.0f;
    cached_AmplitudeBuffer = 0.0f;

    int length = Mathf.Min(cached_AudioBand.Length, cached_AudioBandBuffer.Length);
    for (int i = 0; i < length; ++i)
    {
      cached_Amplitude += cached_AudioBand[i];
      cached_AmplitudeBuffer += cached_AudioBandBuffer[i];
    }

    if (cached_Amplitude > cached_AmplitudeHighest)
    {
      cached_AmplitudeHighest = cached_Amplitude;
    }
    cached_Amplitude /= cached_AmplitudeHighest;
    cached_AmplitudeBuffer /= cached_AmplitudeHighest;
  }

  private void GenerateAudioBands()
  {
    for (int i = 0; i < cached_FreqBands.Length; ++i)
    {
      if (cached_FreqBands[i] > cached_FreqBandHighest[i])
      {
        cached_FreqBandHighest[i] = cached_FreqBands[i];
      }
      cached_AudioBand[i] = cached_FreqBands[i] / cached_FreqBandHighest[i];
      cached_AudioBandBuffer[i] = cached_FreqBandBuffer[i] / cached_FreqBandHighest[i];
    }
  }

  private void GenerateFrequencyBands()
  {
    // 44100 / 1024 = 43Hz per sample
    // 20 - 60
    // 60 - 250
    // 250 - 500
    // 500 - 2000
    // 2000 - 4000
    // 4000 - 6000
    // 6000 - 20000

    audioSource.GetSpectrumData(cached_Samples, 0, window);

    CreateFreqBand(ref cached_FreqBands, ref cached_Samples);
    ModulateFrequencyBands(ref cached_FreqBandBuffer, ref cached_FreqBufferDecrease);
  }

  private void ModulateFrequencyBands(ref float[] freqBandBuffer, ref float[] freqBufferDecrease)
  {
    for (int i = 0; i < freqBandBuffer.Length; ++i)
    {
      if (cached_FreqBands[i] > freqBandBuffer[i])
      {
        freqBandBuffer[i] = cached_FreqBands[i];
        cached_FreqBufferDecrease[i] = 0.005f;
      }

      if (cached_FreqBands[i] < freqBandBuffer[i])
      {
        freqBandBuffer[i] -= freqBufferDecrease[i];
        freqBufferDecrease[i] *= 1.2f;
      }
    }
  }

  void CreateFreqBand(ref float[] band, ref float[] spectrum)
  {
    int count = 0;

    for (int i=0; i < frequencyBands; i++)
    {
      int sampleCount = (int) Mathf.Pow(2, i) * 2;
      if (i == 7) sampleCount += 2;

      float average = 0.0f;
      for (int s=0; s < sampleCount; s++)
      {
        average += spectrum[count]*(count + 1);
        count ++;
      }

      average /= count;
      band[i] = average * 10;
    }
  }

  Vector4 SetForce(Vector3 position, ref float force)
  {
    return new Vector4(position.x, position.y, position.z, Mathf.Clamp(force, 0, 10.0f));
  }

  void OnDrawGizmos()
  {
  }
}
