using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveWeight;
    [SerializeField]
    private float rotationWeight;

    Vector3 initPos;
    float degree;
    float moveUp;
    float moveSide;
    float moveForward;

    private void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moveUp += Input.GetAxis("Vertical") * Time.deltaTime * moveWeight;
            degree += Input.GetAxis("Horizontal") * Time.deltaTime * rotationWeight;
        }
        else
        {
            moveForward += Input.GetAxis("Vertical") * Time.deltaTime * moveWeight;
            moveSide += Input.GetAxis("Horizontal") * Time.deltaTime * moveWeight;
        }
        transform.rotation = Quaternion.AngleAxis(degree, transform.up);
        transform.position = initPos + moveForward * transform.forward + moveSide * transform.right + moveUp * transform.up;
    }
}
