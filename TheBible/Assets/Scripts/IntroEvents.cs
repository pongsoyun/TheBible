using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroEvents : MonoBehaviour
{
    [SerializeField]
    private Button TwinklingButton;
    public bool tutorialEnd = false;
    public void StartGame()
    {
        Debug.Log("게임 시작!");
        StartCoroutine(BlinkingButton());
    }
    public void ExitGame()
    {
        Debug.Log("게임 끝!");
        StopAllCoroutines();
        Application.Quit();
    }
    
    IEnumerator BlinkingButton()
    {
        while(!tutorialEnd)
        {
            TwinklingButton.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            TwinklingButton.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
