using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : Singleton<TutorialManager>
{
    public Button[] onClickHighlight;
    public GameObject tutorialPanel;
    public bool tutorialEnd = false;

    void Update()
    {
        HighLightButton();
    }

    private void HighLightButton()
    {
        if(onClickHighlight != null)
        {
            for (int btnIndex = 0; btnIndex < onClickHighlight.Length; btnIndex++)
            {
                onClickHighlight[btnIndex].image.color = Color.white;
            }

            if (Input.GetKey(KeyCode.A))
            {
                onClickHighlight[0].image.color = Color.red;
            }
            if (Input.GetKey(KeyCode.D))
            {
                onClickHighlight[1].image.color = Color.red;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                onClickHighlight[2].image.color = Color.red;
            }
            if (Input.GetKey(KeyCode.E))
            {
                onClickHighlight[3].image.color = Color.red;
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                onClickHighlight[4].image.color = Color.red;
            }
        }
    }

    public void FinishTutorial()
    {
        tutorialEnd = true;
        tutorialPanel.SetActive(false);
    }
}
