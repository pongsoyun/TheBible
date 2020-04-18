using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoneClick : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Stone2")){
            // Player 돌맞았을 때 Animation 추가되면 넣을 부분 

        }
    }
}
