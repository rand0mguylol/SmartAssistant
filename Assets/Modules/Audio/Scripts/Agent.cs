using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
[RequireComponent(typeof(AudioSource))]
public partial class Agent : MonoBehaviour
{
  public VisualEffect audioVFX;
  private const float epsilon = 0.001f;
  
  #region VFX Property IDs
  private int noiseIntensity;
  #endregion

  #region Editor Stuff
  [HideInInspector]
  public bool drawDefaultInspect;
  #endregion

  void Start()
  {
    InitVFXPropertyIDs();

    InitAgentInteraction();
    InitAudioVisualizer();
  }

  void Update()
  {
    UpdateAgentInteraction();
    UpdateAudioVisualizer();
  }

  void InitVFXPropertyIDs()
  {
    // audio1 = Shader.PropertyToID("Audio1");
    // audio2 = Shader.PropertyToID("Audio2");
    // audio3 = Shader.PropertyToID("Audio3");
    // audio4 = Shader.PropertyToID("Audio4");
    // audio5 = Shader.PropertyToID("Audio5");
    // audio6 = Shader.PropertyToID("Audio6");
    // audio7 = Shader.PropertyToID("Audio7");
    // audio8 = Shader.PropertyToID("Audio8");
    noiseIntensity = Shader.PropertyToID("Intensity");
  }
}
