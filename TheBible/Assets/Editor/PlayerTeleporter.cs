﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerTeleporter : EditorWindow
{
    GameObject[] teleport;
    GameObject player;

    [MenuItem("Window/Teleporter")]
    static void Open()
    {
        GetWindow<PlayerTeleporter>();
    }

    void OnGUI()
    {
        //EditorGUILayout.LabelField("Example Label");
        GUILayout.BeginVertical();
        if (GUILayout.Button("Find Teleport Position"))
        {
            teleport = GameObject.FindGameObjectsWithTag("Flag");
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null || teleport == null)
            {
                Debug.LogError("Necessary Objects Not Exists! Check Set True");
                return;
            }
        }

        EditorGUILayout.LabelField($"Player Position : {player.transform.position}");
        EditorGUILayout.LabelField("Flag List");

        foreach (var tel in teleport)
        {
            Debug.Log($"GUI Button Make {tel.name}");
            if (GUILayout.Button($"{tel.name}"))
            {
                Debug.Log($"{tel.transform.position}, Player : {player.transform.position}");
                player.transform.position = tel.transform.position;
                Debug.Log("Player Teleport!");
            }
        }
        GUILayout.EndVertical();
    }
}
