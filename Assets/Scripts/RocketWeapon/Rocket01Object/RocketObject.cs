using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : ParentsObject
{
    private void Awake()
    {
        try
        {
            if (spawnerObj == null)
            {
                throw new NullReferenceException("someObject is not assigned in the Inspector!");
            }

            InitComp();
            SetForce(200);
            SetLifeTime(1f);

        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("Exception occurred: " + ex.Message);
            Application.Quit(); // 강제 종료
        }

    }
}
