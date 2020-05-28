using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 디스폰 가능한 GameObject에 쓰이는 인터페이스 반환값 없는 이벤트 Action을 이용한 함수구현 
/// </summary>
public interface IDespawnable
{
    event System.Action<GameObject> OnDespawn;
}
/// <summary>
/// Dispose에 관련된 것들은 메모리풀이 System.GC.Collect라는 가비지콜렉터에게 수집되지 않게 하기 위한 것들
/// GameObject들 쓰면 되니까 쓰시면 됨
/// </summary>
public class MemoryPool : IEnumerable, System.IDisposable 
{
    public GameObject[] Items { get => itemList.ToArray(); }

    private GameObject prefab;
    private int maxCount;

    private List<GameObject> itemList;
    private Queue<GameObject> itemQueue;
    private List<Rigidbody2D> rigidBodies;

    private bool isRigidBody = false;
    private bool isDispose = false;

    public GameObject this[int index]
    {
        get => itemList[index];
    }

    public MemoryPool(GameObject prefab, int count, int maxCount)
    {
        this.prefab = prefab;
        this.maxCount = maxCount;

        this.itemList = new List<GameObject>(maxCount);
        this.itemQueue = new Queue<GameObject>(maxCount);
        if(prefab.GetComponent<Rigidbody2D>() != null)
        {
            this.rigidBodies = new List<Rigidbody2D>(maxCount);
            isRigidBody = true;
        }
        
        for(int i = 0; i < count && i < maxCount; i++)
        {
            var newItem = GameObject.Instantiate(prefab);
            var newEvent = (IDespawnable)newItem.GetComponent(typeof(IDespawnable));
            if(newEvent != null)
            {
                newEvent.OnDespawn += Despawn;
            }
            newItem.SetActive(false);
            itemList.Add(newItem);
            itemQueue.Enqueue(newItem);
            if (isRigidBody)
            {
                var newRigid = newItem.GetComponent<Rigidbody2D>();
                rigidBodies.Add(newRigid);
            }
        }
    }

    ~MemoryPool()
    {
        Dispose(false);
    }

    public GameObject Respawn(Vector3 position, Quaternion quaternion)
    {
        if(itemQueue.Count > 0)
        {
            var item = itemQueue.Dequeue();
            item.transform.position = position;
            if (quaternion != null)
                item.transform.localRotation = quaternion;
            item.SetActive(true);
            return item;
        }
        else if(itemList.Count < maxCount)
        {
            var newItem = GameObject.Instantiate(prefab);
            newItem.transform.position = position;
            if (quaternion != null)
                newItem.transform.localRotation = quaternion;
            itemList.Add(newItem);
            return newItem;
        }
        else
        {
            return null;
        }
    }

    public void Despawn(GameObject item)
    {
        if (item == null) return;
        if (isRigidBody)
        {
            var index = itemList.IndexOf(item);
            rigidBodies[index].velocity = Vector3.zero;
        }
        item.SetActive(false);
        itemQueue.Enqueue(item);
    }

    public void AllDespawn()
    {
        foreach(var i in itemList)
        {
            if (i.activeSelf) Despawn(i);
        }
    }

    public void ClearItem()
    {
        foreach(var i in itemList)
        {
            i.SetActive(false);
        }
    }

    public IEnumerator GetEnumerator()
    {
        foreach(GameObject i in itemList)
        {
            yield return i;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (isDispose)
            return;
        if (disposing)
        {
            foreach(var i in itemList)
            {
                GameObject.Destroy(i);
            }

            itemList.Clear();
            itemQueue.Clear();
            if (isRigidBody)
            {
                rigidBodies.Clear();
            }

            itemList = null;
            itemQueue = null;
            rigidBodies = null;
        }

        isDispose = true;
    }
}
