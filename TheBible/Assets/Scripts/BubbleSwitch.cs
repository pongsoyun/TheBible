using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject Bubble;
    [SerializeField]
    string animationName;
    public bool isPlayerStop;

    bool isBubbleOnce;
    Animator animator;

    void Start()
    {
        isBubbleOnce = false;
        Bubble.SetActive(false);
    }

    private void Update()
    {
        if (Bubble.activeInHierarchy && isPlayerStop)
        {
            animator = Bubble.GetComponent<Animator>();
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {
                Bubble.GetComponentInParent<CharacterMove>().isPlayed = true;
                Debug.Log($"{animationName} is Playing!");
            }
            else
            {
                Bubble.GetComponentInParent<CharacterMove>().isPlayed = false;
                Debug.Log($"{animationName} Stop!");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isBubbleOnce && collision.CompareTag("Player"))
        {
            Bubble.SetActive(true);
            isBubbleOnce = true;
        }
    }
}
