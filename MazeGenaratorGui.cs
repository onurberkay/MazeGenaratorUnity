#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MazeGenarator))]
public class MazeGenaratorGui : Editor
{
    public override void OnInspectorGUI()
    {
        MazeGenarator myTarget = (MazeGenarator)target;
        DrawDefaultInspector();
        /*
        myTarget.box = EditorGUILayout.GameObjectField("width", myTarget.width);
        myTarget.width = EditorGUILayout.IntField("width", myTarget.width);
        myTarget.height = EditorGUILayout.IntField("height", myTarget.height);
        myTarget.startx= EditorGUILayout.IntField("startx", myTarget.startx);
        myTarget.starty = EditorGUILayout.IntField("starty", myTarget.starty);
        myTarget.sunHeight = EditorGUILayout.FloatField("sunHeight", myTarget.sunHeight);
        myTarget.sunWidth = EditorGUILayout.FloatField("sunWidtht", myTarget.sunWidth);*/



        if (GUILayout.Button("Generate All"))
        {
            myTarget.GenerateAll();
        }
        if (GUILayout.Button("Delete All"))
        {
            myTarget.DeleteAll();
        }
        if (GUILayout.Button("Maze Generate"))
        {
            myTarget.MazeGenerate();
        }
        if (GUILayout.Button("Maze Delete"))
        {
            myTarget.MazeDelete();
        }
        if (GUILayout.Button("Light Generate"))
        {
            myTarget.LightGenerate();
        }
        if (GUILayout.Button("Light Delete"))
        {
            myTarget.LightDelete();
        }
        
    }
}

#endif

