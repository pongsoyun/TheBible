using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public SpriteRenderer chracter;
    public delegate void TestEvent();
    public event TestEvent ActivateEvent;

    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float walkSpeed;

    private float moveWeight;
    public float jumpPower;
    float moveSide;
    Rigidbody2D CharacterBody;
    bool isGround;

    private void Start()
    {
        CharacterBody = GetComponent<Rigidbody2D>();
    }
<<<<<<< HEAD


    // Update is called once per frame
=======
    
>>>>>>> 0af24a65aa7d2fe19846ff18728ec4e41032fe79
    void Update()
    {
        MovingCharacter();
        if (Input.GetKey(KeyCode.E))
        {
            ActivateEvent?.Invoke();
        }
    }

    void MovingCharacter()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("SpeedUp");
            moveWeight = runSpeed;
        }
        else
        {
            moveWeight = walkSpeed;
        }

<<<<<<< HEAD
        if (Input.GetAxis("Horizontal") < 0)
=======
        if (Input.GetKey(KeyCode.Space) && isGround)
>>>>>>> 0af24a65aa7d2fe19846ff18728ec4e41032fe79
        {
            Debug.Log("CanJump!");
            CharacterBody.AddForce(Vector3.up * jumpPower, ForceMode2D.Force);
        }
<<<<<<< HEAD
        else if (Input.GetAxis("Horizontal") > 0)
        {
            chracter.flipX = false;
=======
        else if(isGround)
        {
            if (Input.GetAxis("Horizontal") < 0)
                chracter.flipX = true;
            else if (Input.GetAxis("Horizontal") > 0)
                chracter.flipX = false;
            moveSide = Input.GetAxis("Horizontal") * moveWeight;
            CharacterBody.velocity = moveSide * transform.right;
>>>>>>> 0af24a65aa7d2fe19846ff18728ec4e41032fe79
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("isGround!");
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("NotGround!");
            isGround = false;
        }
    }
}
