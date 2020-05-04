using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTalkingBubblePlay : MonoBehaviour
{
    public GameObject BigTalkingBubble;
    // Start is called before the first frame update
    void Start()
    {// 6초 후 bubble 활성화
        Debug.Log("출력력뎢ㅁ러ㅕㅇ니ㅗ랴ㅏ저되놔러");
        Invoke("Printer", 2f);
        Invoke("BubbleON", 4f);
    }

    void BubbleON()
    {
        Debug.Log("BubbleON");
        BigTalkingBubble.SetActive(true);
    }

    void Printer()
    {
        Debug.Log("printer ");
    }
}
