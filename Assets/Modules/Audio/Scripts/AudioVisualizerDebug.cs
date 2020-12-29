using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Audio;

public class AudioVisualizerDebug : MonoBehaviour
{
  public AudioSource audioSource;
  public AudioProfile audioProfile;
  public AudioVisualizer audioVisualizer;

  public float width;

  void Awake()
  {
    audioVisualizer = new AudioVisualizer(ref audioSource, ref audioProfile);
  }

  // Update is called once per frame
  void Update()
  {
    audioVisualizer.SampleSpectrum();
  }

  void OnDrawGizmos()
  {
    if (Application.isPlaying)
    {
      Gizmos.color = Color.cyan;
      for (int s=0; s < audioVisualizer.samples.Length; s++)
        Gizmos.DrawCube(transform.position + new Vector3(width*s, 0, 0), new Vector3(width, audioVisualizer.samples[s], width));
    }
    
  }
}
