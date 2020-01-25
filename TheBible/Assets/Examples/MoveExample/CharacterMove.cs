using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public SpriteRenderer chracter;

    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float walkSpeed;

    private float moveWeight;
    Vector3 initPos;
    float moveSide;
    float moveForward;

    public delegate void TestEvent();
    public event TestEvent ActivateEvent;

    private void Start()
    {
        initPos = transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        MovingCharacter();
        if(Input.GetKey(KeyCode.E))
        {
            ActivateEvent?.Invoke();
        }
    }

    void MovingCharacter()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moveWeight = runSpeed;
        }
        else
        {
            moveWeight = walkSpeed;
        }
        moveForward += Input.GetAxis("Vertical") * Time.deltaTime * moveWeight;
        moveSide += Input.GetAxis("Horizontal") * Time.deltaTime * moveWeight;

        if(Input.GetAxis("Horizontal") < 0)
        {
            chracter.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
             chracter.flipX = false;
        }

        transform.position = initPos + moveForward * transform.up + moveSide * transform.right;
    }
}
