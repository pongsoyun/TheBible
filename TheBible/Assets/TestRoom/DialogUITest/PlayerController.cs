using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public GameManager manager; // 대화창 UI를 위한 manager 호출


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} : This is {collision.gameObject.tag}");
        manager.Action(collision.gameObject); // manager 에게 parameter로 gameObject 전달
    }


}
