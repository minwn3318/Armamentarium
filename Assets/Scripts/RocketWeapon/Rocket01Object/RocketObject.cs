using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : ParentsObject
{
    private void Awake()
    {
        InitComp();
        SetForce(200);
    }
}
