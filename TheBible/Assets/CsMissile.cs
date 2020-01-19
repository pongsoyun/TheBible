using UnityEngine;
using System.Collections;

public class CsMissile : MonoBehaviour {

    int speed = 10;
    public void init()
    {
        transform.position = new Vector3(0, 0, 0);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float amtMove = speed * Time.smoothDeltaTime;
        transform.Translate(Vector3.forward * amtMove); 
	}
}
