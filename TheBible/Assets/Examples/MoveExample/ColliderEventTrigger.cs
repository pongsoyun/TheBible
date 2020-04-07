using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderEventTrigger : MonoBehaviour
{
    CharacterMove Player;
    [SerializeField]
    private Image FilledImage;

    public ParticleSystem Aura;
    public ParticleSystem ActionParticle;

    public Animator MiniRbAnim;
    public Animator PlayerAnim;

    bool isPet = false;
    // Start is called before the first frame update
    void Awake()
    {
        Player = FindObjectOfType<CharacterMove>();
        //  animator = GetComponent<Animator>();
    }

    void Start()
    {
        Aura.Stop();
        ActionParticle.Stop();
    }

    void Update()
    {
        if (isPet)
        {
            transform.position = new Vector3(Player.transform.position.x - 1f, Player.transform.position.y, transform.transform.position.z);
        }
    }

    void DebugEvent()
    {
        Debug.Log("EventTriggerON");
        if (Input.GetKey(KeyCode.E))
        {
            FilledImage.fillAmount += 0.01f;
            Aura.Emit(1);
            ActionParticle.Emit(1);
            Debug.Log("isMagicTrue");
            isMagicTrue();
        }
        else
        {
            Aura.Stop();
            ActionParticle.Stop();
        }

        if (FilledImage.fillAmount >= 1.0f)
        {
            Debug.Log("FilledImage Reset 1.0 to 0!");
            FilledImage.fillAmount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EventEnter");
        MiniRbAnim.SetBool("Cure", true);
        Player.eventClear();
        Player.ActivateEvent += DebugEvent;
        Invoke("isPetTrue", 1f);
        // isPet = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("EventExit");
        //Player.ActivateEvent -= DebugEvent;
        FilledImage.fillAmount = 1f;
    }

    void isPetTrue()
    {
        isPet = true;
    }

    void isMagicTrue()
    {
        PlayerAnim.SetBool("magic", true);
        Invoke("isMagicFalse", 1f);
    }

    void isMagicFalse()
    {
        Debug.Log("magic 멈춰!!");
        PlayerAnim.SetBool("magic", false);
    }
}
