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

    private Animator animator;

    [Header("Sound"), Space(5)]
    public AudioSource jumpAudio;
    public AudioClip jumpSound;
    public AudioSource magicAudio;
    public AudioClip magicSound;
    public bool isMagicSound = false;

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
        MovingCharacter();
        if (Input.GetKey(KeyCode.E))
        {
            if (!isMagicSound)
            {
                Invoke("magicAudioPlay", 1f);
                isMagicSound = true;
            }
            ActivateEvent?.Invoke();
        }
    }

    void magicAudioPlay()
    {
        magicAudio.Play();
        isMagicSound = false;
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
