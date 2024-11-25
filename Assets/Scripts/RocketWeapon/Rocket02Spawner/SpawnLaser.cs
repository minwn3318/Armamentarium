using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class SpawnLaser : ParentSpawner
{
    public void Awake()
    {
        SetPoolSize(1);
        SetCoolTime(2f);
        SetFireAva();
        CreatePool();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
    }
}

