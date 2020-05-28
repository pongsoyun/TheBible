using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSignActive : MonoBehaviour
{
    [SerializeField]
    GameObject backSign;
    // Start is called before the first frame update
    void Start()
    {
        backSign.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isBeforeCpt)
        {
            backSign.SetActive(true);
        }
    }
}
