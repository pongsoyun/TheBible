using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionExample : MonoBehaviour
{
    [SerializeField]
    private Image FilledImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            FilledImage.fillAmount += 0.01f;
        }
        if (FilledImage.fillAmount >= 1.0f)
        {
            Debug.Log("FilledImage Reset 1.0 to 0!");
            FilledImage.fillAmount = 0;
        }
    }
}
