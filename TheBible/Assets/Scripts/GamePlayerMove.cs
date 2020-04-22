using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ThrowType
{
    Carrot,
    Stone
}
public enum RabbitType
{
    SmallRabbit,
    BigRabbit
}
public class GamePlayerMove : Singleton<GamePlayerMove>
{
    [SerializeField, Header("About Throw")]
    private GameObject[] throwObjects;
    [SerializeField]
    private GameObject TargetObject;

    [SerializeField, Header("About Preview")]
    private Image PreviewObject;
    [SerializeField]
    private Sprite[] PreviewSprites;

    [Header("ETC")]
    public MemoryPool[] throwObjectPool;
    public Vector3 rotateAngle;
    public int playerHP = 10;
    static public Vector2 throwPower;

    int throwIndex = 0;

    public ParticleSystem ActionParticle;

    public Animator MainCharAnim;
    void Awake()
    {
        throwObjectPool = new MemoryPool[throwObjects.Length];
        for (int index = 0; index < throwObjects.Length; index++)
        {
            throwObjectPool[index] = new MemoryPool(throwObjects[index], 5, 15);
        }
        ActionParticle.Stop();
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        PreviewObject.sprite = PreviewSprites[throwIndex];

        if (Input.GetMouseButtonDown(0))
        {
            MainCharAnim.SetBool("throw", true);

            throwPower = TargetObject.transform.position - gameObject.transform.position;
            throwPower.Normalize();
            //Debug.Log($"Normalize Power : {throwPower}");
            throwObjectPool[throwIndex].Respawn(gameObject.transform.position, gameObject.transform.rotation);
            throwIndex = Random.Range(0, throwObjects.Length);

            ActionParticle.Emit(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Index 재설정 던지기
            throwIndex = 0;
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
