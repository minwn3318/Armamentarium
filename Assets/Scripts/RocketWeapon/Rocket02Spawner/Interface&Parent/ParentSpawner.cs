using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{

    [Header("Init Status")]
    // Ǯ ������
    [SerializeField]
    private int poolSize;
    // �߻� ��Ÿ��
    [SerializeField]
    private float coolTime;
    //�߻� ���� ����
    [SerializeField]
    private bool canFire;
    // ������Ʈ ���� �ð�
    [SerializeField]
    private float objectLife;

    // ������ ������
    [Header("Shooting Object")]
    public GameObject prefabObj;

    // ������ ���� ��ġ ���� ��
    [Header("Shooting Distance")]
    [SerializeField]
    private float distance;

    // ������Ʈ Ǯ�� ť
    private Queue<GameObject> pool;

    // ������Ʈ Ǯ ������ ����
    public virtual void SetPoolSize(int size) { poolSize = size; }
    // �߻� ��Ÿ�� ����
    public virtual void SetCoolTime(float CoolTime) { coolTime = CoolTime; }
    // �߻� ���� ���� ����
    public virtual void SetFireAva() { canFire = true; }
    // ������Ʈ ���� �ð� ����
    public virtual void SetLifeTime(float time) { objectLife = time; }
    // �߻� ��ġ ����
    public virtual void SetDistance(float dist) { distance = dist; }

    // �߻� ���� ���� Ȯ��
    public virtual bool GetFireBool() { return canFire; }
    // ������Ʈ ���� �ð� Ȯ��
    public virtual float GetLifeTime() { return objectLife; }
    // �߻� ��Ÿ�� �ð� Ȯ��
    public virtual float GetCoolTime() { return coolTime; }
    // �߻� ��ġ Ȯ��
    public virtual float GetDistance() { return distance; }

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

    // ť���� ������
    public virtual GameObject GetPoolObj()
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }
        else
        {
            return Instantiate(prefabObj);
        }

    }

    public virtual void PushPoolObj(GameObject obj)
    {
        pool.Enqueue(obj);
    }

    // �������� ��ġ �� ������ ���� �������� ���Ϳ� �°� ����
    public virtual void SetObjVec(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = transform.position + transform.forward * GetDistance();
        obj.transform.rotation = transform.rotation;
    }
    // �������� �߻��ؼ� ������
    public virtual void MoveObj(GameObject obj)
    {
        ParentsObject shootedObj = obj.GetComponent<ParentsObject>();
        shootedObj.Launch();
    }

    // ���ǿ� ���߾� �ٽ� ť Ǯ��(�ֱ�)
    public virtual IEnumerator ReturnObj(GameObject obj)
    {
        yield return new WaitForSeconds(GetLifeTime());
        PushPoolObj(obj);
        obj.SetActive(false);
    }

    //�߻� ��Ÿ��
    public virtual IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(GetCoolTime());
        canFire = true;
    }

}
