using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : ParentsObject
{
    // Start is called before the first frame update
    void Start()
    {
        SetForce(3000);
        SetTime(1f);
    }

}
