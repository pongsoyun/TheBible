using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Button[] onClickHighlight;
    public GameObject tutorialPanel;


    void Start()
    {
        tutorialPanel.SetActive(true);
    }


    void Update()
    {
        HighLightButton();
    }

    private void HighLightButton()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            onClickHighlight[0].Select();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            onClickHighlight[1].Select();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onClickHighlight[2].Select();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            onClickHighlight[3].Select();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            onClickHighlight[4].Select();
        }
        else
        {

        }
    }
}
