using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
  public AudioSource audioSource;
  public AudioClip audioClip;
  public static float[] audioSpectrum;

  public FFTWindow fft;
  
  public uint sampleNum = 512;
  public float amplitudeMultiplier = 10f;

  public Material material;
  // Start is called before the first frame update
  void Start()
  {
    // audioSource = GetComponent<AudioSource>();
    audioClip = audioSource.clip;
    print(audioClip.frequency);
  }

  // Update is called once per frame
  void Update()
  {
    // float[] audioSpectrum = new float[1024];
    // float[] audioOutput = new float[1024];

    audioSpectrum = new float[sampleNum];
    audioSource.GetSpectrumData(audioSpectrum, 0, fft);


    for (int i = 1; i < audioSpectrum.Length - 1; i++)
    {
      Debug.DrawLine(new Vector3((i - 1)*0.01f + 1, audioSpectrum[i] * amplitudeMultiplier + 10), new Vector3(i *0.01f + 1, audioSpectrum[i + 1] * amplitudeMultiplier + 10), Color.cyan);
      // Debug.DrawLine(new Vector3(i - 1, audioSpectrum[i] * 20 + 10, 0), new Vector3(i, audioSpectrum[i + 1] * 20 + 10, 0), Color.red);
      // Debug.DrawLine(new Vector3(i - 1, Mathf.Log(audioSpectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(audioSpectrum[i]) + 10, 2), Color.cyan);
      // Debug.DrawLine(new Vector3(Mathf.Log(i - 1), audioSpectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), audioSpectrum[i] - 10, 1), Color.green);
      // Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(audioSpectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(audioSpectrum[i]), 3), Color.blue);
    }
  }
}
