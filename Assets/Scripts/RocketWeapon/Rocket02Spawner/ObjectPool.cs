using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, InterfaceObjectPool
{
    public GameObject myObject;
    private int poolSize;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public virtual void CreatePool(int size)
    {
        poolSize = size;
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject obj = Instantiate(myObject);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public virtual GameObject PopObject()
    {
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public virtual void PushObject(GameObject obj)
    {
        pool.Enqueue(obj);
        obj.SetActive(false);
    }
}
