using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ThrowType
{
    Carrot,
    Stone
}
public class GamePlayerMove : Singleton<GamePlayerMove>
{
    //Add Force로 프리팹 던지기
    //프리팹 선정기준은 랜덤? 확률로 결정
    //웨이브1 일땐 100% 2일땐 80 3일땐 70
    //던지는 키는 E? 마우스? 마우스가 조작감이 훨씬 나을거 같음 어차피 마우스 관련된 것도 있고
    [SerializeField]
    private GameObject[] throwObjects;
    [SerializeField]
    private GameObject TargetObject;

    public Vector3 rotateAngle;
    static public Vector2 throwPower;
    public MemoryPool[] throwObjectPool;
    void Awake()
    {
        throwObjectPool = new MemoryPool[throwObjects.Length];
        for (int index = 0; index < throwObjects.Length; index++)
        {
            throwObjectPool[index] = new MemoryPool(throwObjects[index], 5, 15);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            throwPower = TargetObject.transform.position - gameObject.transform.position;
            throwPower.Normalize();
            //Debug.Log($"Normalize Power : {throwPower}");
            Instantiate(throwObjectPool[Random.Range(0, throwObjects.Length)].Respawn(gameObject.transform.position, gameObject.transform.rotation), gameObject.transform);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(rotateAngle * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(rotateAngle * Time.deltaTime * -1);
        }
    }
}
