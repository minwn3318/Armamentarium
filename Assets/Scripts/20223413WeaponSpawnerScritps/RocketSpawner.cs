using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSpawner : MonoBehaviour
{

    public GameObject boomrocket;
    public GameObject boomspawner;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) 
        { 
            Instantiate(boomrocket, boomspawner.transform.position, boomspawner.transform.rotation);
        }
    }
}
