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

    // ������ ������ �������̵� -> �ڽ��� ������ Ŭ�������� ������ �Լ��� ȣ���ϵ��� ��(�θ� Ŭ���� �ƴ�)
    public override void MoveObj(GameObject obj)
    {
        RocketObject shootedObj = obj.GetComponent<RocketObject>();
        shootedObj.Launch();
    }

}
