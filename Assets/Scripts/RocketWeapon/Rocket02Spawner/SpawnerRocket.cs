using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRocket : ParentSpawner
{
    public void Start()
    {
        SetFireTime(0.5f);
        myPool.CreatePool(10);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

        }
    }
}
