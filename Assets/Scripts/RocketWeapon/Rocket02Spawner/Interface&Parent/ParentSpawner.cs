using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{
    public GameObject prefabObj;

    private Queue<GameObject> pool;

    private int poolSize;
    private float fireCoolTime;
    private bool canFire;

    private float objectLife;


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

    public virtual bool GetFireBool()
    {
        return canFire; 
    }
    public virtual void SetLifeTime(float time)
    {
        objectLife = time;
    }

    public virtual float GetLifeTime()
    {
        return objectLife;
    }

    // ť ����
    // ������ �߻�����
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
        GameObject popObj = GetPoolObj();

        SetObjVec(popObj);

        MoveObj(popObj);
        StartCoroutine(ReturnObj(popObj));
        StartCoroutine(FireCooldown());
    }

    // ������ ȸ��
    // ������ ������
    public virtual void SetObjVec(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
    }
    public virtual void MoveObj(GameObject obj)
    {
        ParentsObject shootedObj = obj.GetComponent<ParentsObject>();
        shootedObj.Launch();
    }

    // ť���� ������
    // ���ǿ� ���߾� �ٽ� ť Ǯ��(�ֱ�)
    public virtual GameObject GetPoolObj()
    {
        if (pool.Count > 0)
        {
            Debug.Log("get");
            return pool.Dequeue();
        }
        else
        {
            Debug.Log("create get");
            return Instantiate(prefabObj);
        }

    }
    public virtual IEnumerator ReturnObj(GameObject obj)
    {
        yield return new WaitForSeconds(objectLife);
        pool.Enqueue(obj);
        obj.SetActive(false);
    }

    //�߻� ��Ÿ��
    public virtual IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireCoolTime);
        canFire = true;
    }
}
