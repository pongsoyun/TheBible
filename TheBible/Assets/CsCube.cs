using UnityEngine;
using System.Collections;

public class CsCube : MonoBehaviour {

    public float speed = 2.0f;
    public GameObject missilePrefab;

    //missile time
    float fireRate = 0.2f;
    float startTime;
    float shootTimeLeft;

    MemoryPool pool = new MemoryPool();
    GameObject[] missile;

    // Use this for initialization
	void Start () {
        startTime = Time.time;

        int poolCount = 10;
        pool.Create(missilePrefab, poolCount);//메모리 풀 사용
        missile = new GameObject[poolCount];
        for (int i = 0; i < missile.Length; i++)
        {
            missile[i] = null;
        }
	}
    void OnApplicationQuit()
    {
        pool.Dispose();//메모리 풀 삭제
    }

	// Update is called once per frame
	void Update () {

        float amtMove = speed * Time.deltaTime;
        float key = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * key * amtMove);


        shootTimeLeft = Time.time - startTime;
        //발사
        if (Input.GetMouseButtonDown(0))
        {
            if (shootTimeLeft > fireRate)
            {
                for (int i = 0; i < missile.Length; i++)
                {
                    if (missile[i] == null)
                    {
                        missile[i] = pool.NewItem();
                        missile[i].transform.position = transform.position;
                        break;
                    }
                }

                startTime = Time.time;
                shootTimeLeft = 0.0f;
            }
        }

        //미사일삭제
        for (int i = 0; i < missile.Length; i++)
        {
            if (missile[i])
            {
                if (missile[i].transform.position.z > 20)
                {
                    pool.RemoveItem(missile[i]);
                   // missile[i].GetComponent<CsMissile>().init();
                    missile[i] = null;
                }
            }
        }


	}



}
