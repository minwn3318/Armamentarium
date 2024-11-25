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
