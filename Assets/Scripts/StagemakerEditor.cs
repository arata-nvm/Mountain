using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StageMaker))]
public class StageMakerEditor : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        StageMaker createStage = target as StageMaker;

        if (GUILayout.Button("CrateStage")) {
            createStage.Create(Vector3.zero);
        }

        if (GUILayout.Button("DeleteStage")) {
            createStage.Delete();
        }
    }
}