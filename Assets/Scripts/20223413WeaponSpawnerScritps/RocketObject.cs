using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : MonoBehaviour
{
    Rigidbody rocketRb;
    float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
        rocketRb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
