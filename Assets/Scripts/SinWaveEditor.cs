using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

[CustomEditor(typeof(SinApproxProfile))]
public class SinWaveEditor : Editor
{
    public int makeSinWaveSampling = 16;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SinApproxProfile profile = target as SinApproxProfile;

        makeSinWaveSampling = EditorGUILayout.IntField("Generate Sample Rate", makeSinWaveSampling);

        if (GUILayout.Button("Generate Sin Wave"))
        {
            float step = Mathf.PI * 2f / (float)makeSinWaveSampling;
            profile.sin = new float[makeSinWaveSampling];

            for (int i = 0; i < makeSinWaveSampling; ++i)
            {
                Debug.Log("Step is now " + step * i);
                profile.sin[i] = Mathf.Sin(step * i);
            }
        }
    }
}
