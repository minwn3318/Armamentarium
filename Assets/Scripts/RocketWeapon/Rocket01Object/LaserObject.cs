using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObject : ParentsObject
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
            SetLifeTime(1.5f);

            Debug.Log("someObject is assigned and ready to use.");
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("Exception occurred: " + ex.Message);
            Application.Quit(); // 강제 종료
        }

    }

}
