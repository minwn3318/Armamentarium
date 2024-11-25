using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsObject : MonoBehaviour, InterfaceObject
{
    private Rigidbody objectRB;
    private Transform objectDirect;
    private float objectFireForce;
    private float objectKeeping;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
        objectDirect = GetComponent<Transform>();

    }
    public virtual void SetForce(float force)
    {
        objectFireForce = force;
    }

    public virtual void SetTime(float time)
    {
        objectKeeping = time;
    }

    public virtual void MoveForce()
    {
        objectRB.AddForce(objectDirect.forward * objectFireForce);
    }

    public virtual void Extinction()
    {
        Destroy(this.gameObject, objectKeeping);

    }
}
