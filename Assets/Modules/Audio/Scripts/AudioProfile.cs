using UnityEngine;

namespace Audio
{
  [System.Serializable]
  public class AudioProfile
  {
    public int channel;
    public FFTWindow window;
    public int sampleSize;
    public float power;
    public float scale;
  }
}