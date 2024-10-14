using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{

    public GameObject laserObject;
    public GameObject laserSpawner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Instantiate(laserObject, laserSpawner.transform.position, laserSpawner.transform.rotation);
        }
    }
}
