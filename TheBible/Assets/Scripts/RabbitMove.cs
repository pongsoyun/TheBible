using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMove : MonoBehaviour
{
    Vector3 target = new Vector3(15, -21, 0);

    // Update is called once per frame
    void Update()
    {
        // 저는 애니메이터로 변경합니다. 쓰지 않기로 했습니다. 하지만 우선 남겨둡니다.. 
        transform.position = Vector3.Lerp(transform.position, target, 0.005f);
    }
}
