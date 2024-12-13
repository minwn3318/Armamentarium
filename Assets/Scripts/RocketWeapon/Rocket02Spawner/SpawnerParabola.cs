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
        SetLifeTime(3f);
        SetDistance(2.5f);
        CreatePool();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0) & GetFireBool())
        {
            Fire();
        }
    }

    // 오브제의 위치 및 방향 오버라이딩 -> 포물선 궤도에 맞게 위치 및 방향, 초기 속도 설정
    public override void SetObjVec(GameObject obj)
    {
        ParabolaObject parabol = obj.GetComponent<ParabolaObject>();

        obj.SetActive(true);
        obj.transform.position = transform.position + transform.forward * GetDistance();

        // forward 벡터와 월드 up 벡터 사이의 각도 계산
        float angle = Vector3.SignedAngle(transform.forward, Vector3.ProjectOnPlane(transform.forward, Vector3.up), Vector3.up);
        // 각도를 라디안으로 변환
        float radian = angle * Mathf.Deg2Rad;

        // 오브젝트의 발사 방향
        Vector3 forwardDirection = transform.forward;
        Debug.Log("forwarddirection : " + forwardDirection);

        // 초기 속도 설정
        float horizontalSpeed = Mathf.Cos(radian); // 수평 성분
        float verticalSpeed = Mathf.Sin(radian);   // 수직 성분;

        // 속도 벡터 계산
        Vector3 vel = forwardDirection * horizontalSpeed * verticalSpeed * parabol.GetForce() * parabol.GetForce() ;

        parabol.SetVelocity(vel); 

        // 운동 플래그 활성화
        parabol.SetMovBool(false);
    }

    // 오브제를 발사해서 움직임 오버라이딩 -> 오브젝트가 포물선 운동하는 동안 방향 조정
    public override void MoveObj(GameObject obj)
    {
        ParabolaObject parabol = obj.GetComponent<ParabolaObject>();
        StartCoroutine(parabol.ParabolicUpdate());

    }

}

