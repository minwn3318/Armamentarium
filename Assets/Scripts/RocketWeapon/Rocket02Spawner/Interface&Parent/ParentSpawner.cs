using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{
    public GameObject prefabObj;
    public Queue<GameObject> pool;

    private int poolSize;
    private float fireCoolTime;
    private bool canFire;

    public virtual void SetPoolSize(int size)
    {
        poolSize = size;
    }

    public virtual void SetCoolTime(float CoolTime)
    {
        fireCoolTime = CoolTime;
    }

    public virtual void SetFireAva()
    {
        canFire = true;
    }

    public virtual void CreatePool()
    {
        pool = new Queue<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabObj);
            pool.Enqueue(obj);
            obj.SetActive(false);
            Debug.Log(pool.Count);

        }
        Debug.Log(pool);
        Debug.Log("end create");
    }
    public virtual void Fire()
    {
        if (canFire)
        {
            Debug.Log("can Fire");
            GameObject obj = GetPool();
            Debug.Log(obj);
            Debug.Log(pool.Count);

            obj.SetActive(true);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;

            ParentsObject shootedObj = obj.GetComponent<ParentsObject>();
            Debug.Log("right"+shootedObj);
            shootedObj.Launch();
            //StartCoroutine(FireCooldown());

        }
    }
    public virtual GameObject GetPool()
    {
        // Ǯ�� ��� ������ źȯ�� �ִ� ���
        if (pool.Count > 0)
        {
            Debug.Log("get");
            return pool.Dequeue();
        }
        else
        {
            Debug.Log("create get");
            // Ǯ�� ��� ������ �� źȯ ����
            GameObject bullet = Instantiate(prefabObj);
            return bullet;
        }
    }
    public virtual void ReturnPool(GameObject obj)
    {
        Debug.Log(pool);
        Debug.Log("bye");
        pool.Enqueue(obj);
        obj.SetActive(false);
        Debug.Log("now" + pool.Count);
    }

    public IEnumerator FireCooldown()
    {
        canFire = false;
        Debug.Log("cool"+canFire);
        yield return new WaitForSeconds(fireCoolTime);
        canFire = true;
        Debug.Log("cool"+canFire);
    }
}
