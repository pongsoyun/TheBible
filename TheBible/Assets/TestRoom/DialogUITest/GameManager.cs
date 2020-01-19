using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject talkPanel;
    public Text TalkText;
    public GameObject scanObject; // Player가 조사했던 object

    public bool isAction; // UI가 실행되고있는지 확인하는 변수

    public void OffUI()
    {
        isAction = false;
        talkPanel.SetActive(isAction);
    }
    public void Action(GameObject scanObj)
    {
        if (!isAction)
        {
            // Enter Action 
            isAction = true;
            scanObject = scanObj;
            TalkText.text = $"이것의 이름은 {scanObject.name} 이라고 한다.";
            Invoke("OffUI", 3);
        }
        talkPanel.SetActive(isAction);


    }

}
