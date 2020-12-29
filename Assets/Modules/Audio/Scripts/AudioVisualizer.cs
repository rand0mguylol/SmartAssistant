using UnityEngine;

namespace Audio
{
  public class AudioVisualizer
  {
    public AudioSource source;
    public AudioProfile profile;
    public AudioVisualizer(ref AudioSource source, ref AudioProfile profile)
    {
      this.source = source;
      this.profile = profile;

      Init();
    }

    public float[] samples;
    public float[] sampleBuffers;

    public void Init() => samples = new float[profile.sampleSize];

    public void SampleSpectrum() => source.GetSpectrumData(samples, profile.channel, profile.window);

    public void RescaleSamples()
    {
      for (int s=0; s < samples.Length; s++)
        samples[s] = Mathf.Pow(Mathf.Sqrt(samples[s]), profile.power) * profile.scale;
    }
  }
}