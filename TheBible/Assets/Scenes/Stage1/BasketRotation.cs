using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketRotation : MonoBehaviour
{
    [SerializeField]

    [Range(0, 1)]
    public float rotZ = 0.3f; // default : 0.3f

    [Range(0, 40)]
    public int rotSpeed = 20; // defalut : 20
    public bool dirRight = true;


    void Update()
    {
        if (transform.rotation.z >= rotZ)
        {
            dirRight = false;
        }
        else if (transform.rotation.z <= -rotZ)
        {
            dirRight = true;
        }

        if (dirRight == true)
        {
            transform.Rotate(new Vector3(0, 0, rotSpeed) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -rotSpeed) * Time.deltaTime);
        }


    }
}