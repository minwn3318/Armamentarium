using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{
    // ������ ������
    public GameObject prefabObj;

    // ������Ʈ Ǯ�� ť
    private Queue<GameObject> pool;

    // Ǯ ������
    private int poolSize;
    // �߻� ��Ÿ��
    private float fireCoolTime;
    //�߻� ���� ����
    private bool canFire;
    // ������Ʈ ���� �ð�
    private float objectLife;

    // ������Ʈ Ǯ ������ ����
    public virtual void SetPoolSize(int size)
    {
        poolSize = size;
    }

    // ������Ʈ ��Ÿ�� ����
    public virtual void SetCoolTime(float CoolTime)
    {
        fireCoolTime = CoolTime;
    }

    // �߻� ���� ���� ����
    public virtual void SetFireAva()
    {
        canFire = true;
    }

    // �߻� ���� ���� Ȯ��
    public virtual bool GetFireBool()
    {
        return canFire; 
    }

    // ������Ʈ ���� �ð� ����
    public virtual void SetLifeTime(float time)
    {
        objectLife = time;
    }

    //������Ʈ ���� �ð� Ȯ��
    public virtual float GetLifeTime()
    {
        return objectLife;
    }

    // ť ����
    public virtual void CreatePool()
    {
        // Ǯ ����
        pool = new Queue<GameObject>(poolSize);
        // Ǯ�� ������ �ν��Ͻ� ������ ����
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabObj);
            pool.Enqueue(obj);
            obj.SetActive(false);

        }
    }

    // ������Ʈ Ǯ������ �������� ���� �߻��ϴ� ���� 
    public virtual void Fire()
    {
        // Ǯ���� ������
        GameObject popObj = GetPoolObj();

        // �������� ��ġ �� ������ ���� �������� ���Ϳ� �°� ����
        SetObjVec(popObj);
        // �������� �����̰� ��
        MoveObj(popObj);
        // �������� �ٽ� Ǯ�� �ֱ�
        StartCoroutine(ReturnObj(popObj));
        // ������ �߻� �� ������
        StartCoroutine(FireCooldown());
    }

    // �������� ��ġ �� ������ ���� �������� ���Ϳ� �°� ����
    public virtual void SetObjVec(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
    }
    // �������� �߻��ؼ� ������
    public virtual void MoveObj(GameObject obj)
    {
        ParentsObject shootedObj = obj.GetComponent<ParentsObject>();
        shootedObj.Launch();
    }

    // ť���� ������
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
    // ���ǿ� ���߾� �ٽ� ť Ǯ��(�ֱ�)
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
