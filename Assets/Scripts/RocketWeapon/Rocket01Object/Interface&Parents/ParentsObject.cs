using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsObject : MonoBehaviour
{
    private Rigidbody objectRB;
    private float objectFireForce;

    public virtual void InitComp()
    {
        objectRB = GetComponent<Rigidbody>();
    }
    public virtual void SetForce(float force)
    {
        objectFireForce = force;
    }

    public virtual float GetForce()
    {
        return objectFireForce;
    }
    public virtual void Launch()
    {
        Debug.Log("Fire!!");
        // 탄환의 forward 방향으로 ForceMode.Impulse 적용
        objectRB.AddForce(transform.forward * objectFireForce, ForceMode.Impulse);
    }

}
