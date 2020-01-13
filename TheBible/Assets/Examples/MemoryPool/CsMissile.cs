using UnityEngine;
using System.Collections;

public class CsMissile : MonoBehaviour {

    int speed = 10;
    
	// Update is called once per frame
	void Update () {
        float amtMove = speed * Time.smoothDeltaTime;
        transform.Translate(Vector3.forward * amtMove); 
	}
}
