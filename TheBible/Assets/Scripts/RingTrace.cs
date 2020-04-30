using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrace : MonoBehaviour
{
    public Transform MainChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, MainChar.position.y + 1.05f, transform.position.z);
    }
}
