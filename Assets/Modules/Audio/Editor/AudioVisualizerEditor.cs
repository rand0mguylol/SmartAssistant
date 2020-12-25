using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;
using System.Linq;

// [CustomEditor(typeof(Agent))]
public class AudioVisualizerEditor : EditorBase
{
  Agent agent;

  void OnEnable() => agent = (Agent)target;

  public override void OnInspectorGUI()
  {
  }
}