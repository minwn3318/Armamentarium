using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{

    public GameObject rocketObject;
    public GameObject rocketSpawner;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) 
        { 
            Instantiate(rocketObject, rocketSpawner.transform.position, rocketSpawner.transform.rotation);
        }
    }
}
