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

    bool isPet = false; // position을 위함. Player따라다닐 RB
    bool isFirstEvent = true;  // 일단.. 긴급 처방.. 
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
        // miniRB position
        if (isPet)
        {
            transform.position = new Vector3(Player.transform.position.x - 1f, Player.transform.position.y + 0.2f, transform.transform.position.z);
        }

        // Animation - magic
        if (!Input.GetKey(KeyCode.E))
        {
            PlayerAnim.SetBool("magic", false);
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
            PlayerAnim.SetBool("magic", true);
        }

        if (FilledImage.fillAmount >= 1.0f)
        {
            // 이게 최초에 한번 호출이 되네요..
            Debug.Log("FilledImage Reset 1.0 to 0!");
            if (isFirstEvent)
            {
                isFirstEvent = false;
            }
            else
            {
                Debug.Log("isPet True!");
                isPet = true; // 따라다니기
                MiniRbAnim.SetBool("Cure", true); // animation 변경(Cured RB으로)
            }
            FilledImage.fillAmount = 0;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EventEnter");
        Player.eventClear();
        Player.ActivateEvent += DebugEvent;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("EventExit");
        //Player.ActivateEvent -= DebugEvent;
        FilledImage.fillAmount = 1f;
    }
}
