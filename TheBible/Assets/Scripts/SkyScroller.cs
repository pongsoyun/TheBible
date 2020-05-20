using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScroller : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer render;
    public float speed;
    private float offset;

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed / 120;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
