using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEvents : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("게임 시작!");
    }
    public void ExitGame()
    {
        Debug.Log("게임 끝!");
        Application.Quit();
    }
}
