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

    private Animator animator;

    private void OnEnable()
    {
        if (!TutorialManager.instance.tutorialEnd)
        {
            TutorialManager.instance.tutorialPanel.SetActive(true);
        }
    }

    private void Start()
    {
        CharacterBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

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

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            Debug.Log("CanJump!");
            CharacterBody.AddForce(Vector3.up * jumpPower, ForceMode2D.Force);
        }
        else if (isGround)
        {
            if (Input.GetAxis("Horizontal") < 0)
                chracter.flipX = true;
            else if (Input.GetAxis("Horizontal") > 0)
                chracter.flipX = false;

            moveSide = Input.GetAxis("Horizontal") * moveWeight;
            CharacterBody.velocity = moveSide * transform.right;

            animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
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

    public void eventClear()
    {
        ActivateEvent = null;
    }
}
