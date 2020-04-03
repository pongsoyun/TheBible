using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBasket : MonoBehaviour
{
    public Transform BasketBack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(BasketBack.position.x, BasketBack.position.y, transform.position.z);
    }
}
