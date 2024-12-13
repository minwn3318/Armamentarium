using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnLaser : ParentSpawner
{
    // 스포너 부모 클래스에 있는 프리팹을 하나 생성하여 저장하는 변수를 만듦
    private GameObject shootedLaser;
    public void Awake()
    {
        SetPoolSize(1);
        SetCoolTime(2f);
        SetFireAva();
        SetLifeTime(1.5f);
        SetDistance(32f);
        CreatePool();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0) & GetFireBool())
        {
            Debug.Log("turn");
            Fire();
        }
    }

    // 오브제를 풀에서 꺼내 발사하는 함수 오버라이딩 -> 레이저 발사로 활성화 후 조정하여 쿨과 다시 되돌리기 조정
    public override void Fire()
    {
        //큐에서 꺼내기
        GameObject popLaser = GetPoolObj();
        //활성화
        popLaser.SetActive(true);
        // 움직이면서 시간이 지나 비활성화
        StartCoroutine(ReturnObj(popLaser));
        //쿨 타임
        StartCoroutine(FireCooldown());
    }

    public override IEnumerator ReturnObj(GameObject obj)
    {
        float v_elapsedTime = 0f;
        float v_coolTime = GetCoolTime();
        float v_distance = GetDistance();

        while (v_elapsedTime < v_coolTime)
        {
            obj.transform.position = transform.position + transform.forward * v_distance;
            obj.transform.rotation = transform.rotation;
            v_elapsedTime += Time.deltaTime;
            yield return null;
        }
        PushPoolObj(obj);
        obj.SetActive(false);
    }
}

