using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public Transform Player;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x + 3.5f, -19.5f, 0);
    }
}
