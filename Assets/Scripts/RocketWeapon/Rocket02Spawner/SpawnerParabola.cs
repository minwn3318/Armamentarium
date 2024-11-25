using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerParabola : ParentSpawner
{
    public void Awake()
    {
        SetPoolSize(10);
        SetCoolTime(2f);
        SetFireAva();
        SetLifeTime(1f);
        CreatePool();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0) & GetFireBool())
        {
            Fire();
        }
    }

    public override void SetObjVec(GameObject obj)
    {
        ParabolaObject parabol = obj.GetComponent<ParabolaObject>();
        obj.SetActive(true);

        // forward 벡터와 월드 up 벡터 사이의 각도 계산
        float angle = Vector3.Angle(transform.forward, Vector3.ProjectOnPlane(transform.forward, Vector3.up));

        // 각도를 라디안으로 변환
        float radian = angle * Mathf.Deg2Rad;

        // 초기 속도 설정
        float horizontalSpeed = parabol.GetForce() * Mathf.Cos(radian); // 수평 성분
        float verticalSpeed = parabol.GetForce() * Mathf.Sin(radian);   // 수직 성분

        // 속도 벡터 계산
        Vector3 vel = transform.forward.normalized * horizontalSpeed
            + transform.up.normalized * verticalSpeed;
        parabol.SetVelocity(vel); // 수평 속도     // 수직 속도

        // 운동 플래그 활성화
        parabol.SetMovBool(false);
    }
    public override void MoveObj(GameObject obj)
    {
        ParabolaObject parabol = obj.GetComponent<ParabolaObject>();
        StartCoroutine(parabol.ParabolicUpdate());

    }

}

