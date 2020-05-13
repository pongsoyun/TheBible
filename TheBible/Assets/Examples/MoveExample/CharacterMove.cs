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
    [SerializeField]
    private ParticleSystem[] particleSystems;

    private float moveWeight;
    public float jumpPower;
    float moveSide;
    Rigidbody2D CharacterBody;
    bool isGround;
    public bool isPlayed = false;
    private Animator animator;

    [Header("Sound"), Space(5)]
    public AudioSource jumpAudio;
    public AudioSource magicAudio;
    //public bool isMagicSound = false;

    private void OnEnable()
    {
        if (!TutorialManager.instance.tutorialEnd && TutorialManager.instance.tutorialPanel != null)
        {
            TutorialManager.instance.tutorialPanel.SetActive(true);
        }
        foreach (var particle in particleSystems)
        {
            particle.Stop();
        }
    }

    private void Start()
    {
        CharacterBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isPlayed)
        {
            MovingCharacter();
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
            jumpAudio.Play();
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
        if (Input.GetKey(KeyCode.E))
        {
            if (!magicAudio.isPlaying)
            {
                magicAudio.Play();
            }
            ActivateEvent?.Invoke();
        }
        else
        {
            magicAudio.Stop();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{collision.gameObject.tag}, Enter2d, {isGround}");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("isGround!");
            isGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"{collision.gameObject.tag}, Stay2d, {isGround}");
        if (collision.gameObject.CompareTag("Basket"))
        {
            Debug.Log("isBasket");
            isGround = true;
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("isGround!");
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"{collision.gameObject.tag}, Exit2d, {isGround}");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("NotGround!");
            isGround = false;
        }
        else if (collision.gameObject.CompareTag("Basket"))
        {
            Debug.Log("NotBaket");
            isGround = false;
            gameObject.transform.SetParent(null);
        }
    }

    public void eventClear()
    {
        ActivateEvent = null;
    }
}
