using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSpawner : MonoBehaviour, InterfaceSpawner
{
    public GameObject bodyRotate;
    protected ObjectPool myPool;
    private float fireTime;

    private void Awake()
    {
        myPool = GetComponent<ObjectPool>();
    }

    public void SetFireTime(float time)
    {
        fireTime = time;
    }

    public void Fire()
    {
        ParentsObject popObject = myPool.PopObject().GetComponent<ParentsObject>();
        popObject.MoveForce();
    }
}
