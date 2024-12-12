using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{

    [Header("Init Status")]
    // 풀 사이즈
    [SerializeField]
    private int poolSize;
    // 발사 쿨타임
    [SerializeField]
    private float coolTime;
    //발사 가능 여부
    [SerializeField]
    private bool canFire;
    // 오브젝트 생존 시간
    [SerializeField]
    private float objectLife;

    // 스폰할 프리팹
    [Header("Shooting Object")]
    public GameObject prefabObj;

    // 프리팹 스폰 위치 조정 값
    [Header("Shooting Distance")]
    [SerializeField]
    private float distance;

    // 오브젝트 풀링 큐
    private Queue<GameObject> pool;

    // 오브젝트 풀 사이즈 설정
    public virtual void SetPoolSize(int size) { poolSize = size; }
    // 발사 쿨타임 설정
    public virtual void SetCoolTime(float CoolTime) { coolTime = CoolTime; }
    // 발사 가능 여부 설정
    public virtual void SetFireAva() { canFire = true; }
    // 오브젝트 생존 시간 설정
    public virtual void SetLifeTime(float time) { objectLife = time; }
    // 발사 위치 설정
    public virtual void SetDistance(float dist) { distance = dist; }

    // 발사 가능 여부 확인
    public virtual bool GetFireBool() { return canFire; }
    // 오브젝트 생존 시간 확인
    public virtual float GetLifeTime() { return objectLife; }
    // 발사 쿨타임 시간 확인
    public virtual float GetCoolTime() { return coolTime; }
    // 발사 위치 확인
    public virtual float GetDistance() { return distance; }

    // 큐 생성
    public virtual void CreatePool()
    {
        // 풀 생성
        pool = new Queue<GameObject>(poolSize);
        // 풀에 프리팹 인스턴스 생성후 삽입
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabObj);
            pool.Enqueue(obj);
            obj.SetActive(false);

        }
    }

    // 오브젝트 풀링에서 프리팹을 꺼내 발사하는 행위 
    public virtual void Fire()
    {
        // 풀에서 꺼내기
        GameObject popObj = GetPoolObj();
        // 오브제의 위치 및 방향을 현재 스포너의 벡터에 맞게 설정
        SetObjVec(popObj);
        // 오브제를 움직이게 함
        MoveObj(popObj);
        // 오브제를 다시 풀에 넣기
        StartCoroutine(ReturnObj(popObj));
        // 오브제 발사 쿨 돌리기
        StartCoroutine(FireCooldown());
    }

    // 큐에서 꺼내기
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

    // 오브제의 위치 및 방향을 현재 스포너의 벡터에 맞게 설정
    public virtual void SetObjVec(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = transform.position + transform.forward * GetDistance();
        obj.transform.rotation = transform.rotation;
    }
    // 오브제를 발사해서 움직임
    public virtual void MoveObj(GameObject obj)
    {
        ParentsObject shootedObj = obj.GetComponent<ParentsObject>();
        shootedObj.Launch();
    }

    // 조건에 맞추어 다시 큐 풀링(넣기)
    public virtual IEnumerator ReturnObj(GameObject obj)
    {
        yield return new WaitForSeconds(GetLifeTime());
        PushPoolObj(obj);
        obj.SetActive(false);
    }

    //발사 쿨타임
    public virtual IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(GetCoolTime());
        canFire = true;
    }

}
