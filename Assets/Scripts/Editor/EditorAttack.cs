using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(Attackholder))]
public class EditorAttack : Editor
{

    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();
    //    Attackholder atkh = (Attackholder)target;

    //    EditorGUILayout.Space(15);
    //    EditorGUILayout.LabelField("--çUåÇçÏê¨--");
    //    Rect r = EditorGUILayout.BeginHorizontal();
    //    Rect r2 = EditorGUILayout.BeginVertical();
    //    if (GUI.Button(r2, GUIContent.none))
    //    {
    //        atkh.attackList.Add(new Attackholder.kougeki());
    //        Repaint();

    //    }
    //    GUILayout.Label("êVÇµÇ¢çUåÇÇçÏê¨Ç∑ÇÈ");
    //    EditorGUILayout.EndVertical();
    //    Rect r3 = EditorGUILayout.BeginVertical();
    //    if (GUI.Button(r3, GUIContent.none))
    //    {
    //        atkh.attackList.Remove(atkh.attackList[atkh.attackList.Count-1]);
    //        Repaint();

    //    }
    //    GUILayout.Label("çUåÇÇè¡Ç∑");
    //    EditorGUILayout.EndVertical();
    //    EditorGUILayout.EndHorizontal();
    //    for (int i = 0; i < atkh.attackList.Count; i++)
    //    {
    //        EditorGUILayout.BeginHorizontal();
    //        atkh.attackList[i].type = (Attackholder.AttackType)EditorGUILayout.EnumFlagsField(atkh.attackList[i].type);
    //        atkh.attackList[i].time = EditorGUILayout.FloatField(atkh.attackList[i].time);
    //        atkh.AssignAttack(atkh.attackList[i]);
    //        EditorGUILayout.EndHorizontal();
    //    }

    //    if (GUI.changed)
    //    { 
    //        //save changes ui
    //        EditorUtility.SetDirty(atkh);
    //        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    //        PrefabUtility.RecordPrefabInstancePropertyModifications(atkh);
    //        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
    //        serializedObject.ApplyModifiedProperties();
    //        serializedObject.Update();
    //        //save changes data
    //        PlayerPrefs.DeleteAll();
    //        for(int i = 0; i < atkh.attackList.Count; i++)
    //        {
    //            PlayerPrefs.SetString("type_" + i, atkh.attackList[i].type.ToString());
    //            PlayerPrefs.SetFloat("time_" + i, atkh.attackList[i].time);
    //        }

    //    }
    //    else
    //    {
    //        atkh.LoadInspectorData();
    //    }

    //}

}