using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRocket : ParentSpawner
{
    public void Awake()
    {
        SetPoolSize(10);
        SetCoolTime(0.5f);
        SetFireAva();
        SetLifeTime(1f);
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

    // 오브제 움직임 오버라이딩 -> 자신의 오브제 클래스에서 움직임 함수를 호출하도록 함(부모 클래스 아님)
    public override void MoveObj(GameObject obj)
    {
        RocketObject shootedObj = obj.GetComponent<RocketObject>();
        shootedObj.Launch();
    }

}
