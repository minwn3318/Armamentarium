using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnerObject : MonoBehaviour
{
    public GameObject _object;
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(_object, spawner.transform.position, spawner.transform.rotation);
        }
    }
}
