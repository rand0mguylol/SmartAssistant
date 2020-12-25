using UnityEngine;
using UnityEditor;

// [CustomEditor(typeof(Agent))]
public class AudioVisualizerEditor : EditorBase
{
  Agent agent;

  void OnEnable() => agent = (Agent)target;

  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();



    // #region Inspector Routine Task
    // if (GUILayout.Button("Refresh Editor Layout")) EnsureStyles();
    // // if (centeredLabelStyle == null) EnsureStyles();

    // // if (agent.audioForceField != null && agent.textureDim == TextureDimension.None) agent.textureDim = agent.audioForceField.dimension;

    // GUILayout.Space(spaceB);  
    // #endregion

    // agent.showAudioSettings = EditorGUILayout.Foldout(agent.showAudioSettings, "Audio Settings", true, foldoutStyle);
    // if (agent.showAudioSettings)
    // {
    //   GUILayout.BeginVertical(box);
    //   EditorGUILayout.PropertyField(serializedObject.FindProperty("audioVFX"), new GUIContent("Audio VFX Graph"));
    //   EditorGUILayout.PropertyField(serializedObject.FindProperty("audioSource"), new GUIContent("Audio Source"));
    //   EditorGUILayout.PropertyField(serializedObject.FindProperty("fft"), new GUIContent("FFT Window"));
    //   GUI.enabled = false;
    //   EditorGUILayout.IntField("Audio Hertz", Agent.audioHertz);
    //   EditorGUILayout.IntField("Sample Size", Agent.sampleSize);
    //   EditorGUILayout.IntField("Band Size", Agent.bandSize);
    //   GUI.enabled = true;
    //   GUILayout.EndVertical();
    //   GUILayout.Space(spaceA);
    // }

    // agent.showMicSettings = EditorGUILayout.Foldout(agent.showMicSettings, "Mic Settings", true, foldoutStyle);
    // if (agent.showMicSettings)
    // {
    //   GUILayout.BeginVertical(box);
    //   GUI.enabled = false;
    //   EditorGUILayout.TextField("Mic Device", Agent.micDevice);
    //   GUI.enabled = true;
    //   GUILayout.EndVertical();
    //   GUILayout.Space(spaceA);
    // }

    // agent.showAudioVisualizer = EditorGUILayout.Foldout(agent.showAudioVisualizer, "Audio Visualizer", true, foldoutStyle);
    // if (agent.showAudioVisualizer)
    // {
    //   GUILayout.BeginVertical(box);
    //   GUILayout.EndVertical();
    //   GUILayout.Space(spaceA);
    // }

    // agent.showAgentInteraction = EditorGUILayout.Foldout(agent.showAgentInteraction, "Agent Interaction", true, foldoutStyle);
    // if (agent.showAgentInteraction)
    // {
    //   GUILayout.BeginVertical(box);
    //   agent.showRotation = EditorGUILayout.Foldout(agent.showRotation, "Rotatation", true, subFoldoutStyle);
    //   if (agent.showRotation)
    //   {
    //     EditorGUILayout.PropertyField(serializedObject.FindProperty("rotationMultiplier"), new GUIContent("Rotation Multiplier"));
    //     EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityDamping"), new GUIContent("Velocity Damping"));
    //     EditorGUILayout.PropertyField(serializedObject.FindProperty("intensityCoefficient"), new GUIContent("Intensity Coefficient"));
    //     EditorGUILayout.PropertyField(serializedObject.FindProperty("intervalTime"), new GUIContent("Interval Update Time"));
    //     GUI.enabled = false;
    //     EditorGUILayout.PropertyField(serializedObject.FindProperty("rotationVelocity"), new GUIContent("Rotation Velocity"));
    //     GUI.enabled = true;
    //     GUILayout.Space(spaceB);
    //   }

    //   GUILayout.EndVertical();
    //   GUILayout.Space(spaceA);
    // }

    // if(EditorGUI.EndChangeCheck())
    // {
    //   EditorApplication.QueuePlayerLoopUpdate();
    //   serializedObject.ApplyModifiedProperties();
    // }

    // GUILayout.Space(spaceA);

    // GUI.backgroundColor = Color.gray;
    // EditorGUILayout.LabelField("~~ OPEN THIS ONLY IF YOU KNOW WHAT YOU ARE DOING ~~", centeredLabelStyle);
    // GUILayout.Space(spaceB);
    // GUI.backgroundColor = Color.white;

    // agent.drawDefaultInspect = EditorGUILayout.Foldout(agent.drawDefaultInspect, "Draw Default Inspector", true, subFoldoutStyle);
    // if (agent.drawDefaultInspect)
    //   DrawDefaultInspector();
  }
}