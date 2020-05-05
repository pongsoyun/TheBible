using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickRabbit : MonoBehaviour
{
    //CharacterMove Player;
    [SerializeField]
    private Image FilledImage;

    public ParticleSystem Aura;
    public ParticleSystem ActionParticle;
    public Animator CureKingAnim;
    public Animator PlayerAnim;
    public bool isAbleCure;
    public bool isFirstEvent = true;  // 일단.. 긴급 처방.. 

    public Animator MiniRbAnim;
    public bool isMiniRbAnimPlay = false;

    // public GameObject BubbleKingCure;
    public GameObject BubbleTogether;

    void Start()
    {
        Aura.Stop();
        ActionParticle.Stop();

        // BubbleKingCure.SetActive(false);
        BubbleTogether.SetActive(false);
    }

    void Update()
    {
        DebugEvent();
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
            // 애기 놀람 
            if(!isMiniRbAnimPlay){
            MiniRbAnim.SetBool("shock", true);
            isMiniRbAnimPlay = true;
            }
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
                CureKingAnim.SetBool("cure", true);
                Invoke("PlayBubbleTogether", 1f);
            }
            FilledImage.fillAmount = 0;

        }
    }

    private void PlayBubbleTogether() {
        BubbleTogether.SetActive(true);
    }
}
