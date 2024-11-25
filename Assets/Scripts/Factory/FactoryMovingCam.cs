using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FactoryMovingCam : MonoBehaviour
{
    public Transform target;
    Transform tr;

    public float targetOffset = 2f;
    public float moveDamping = 15f;
    public float rotateDamping = 10f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        LookAt();
    }

    void LookAt()
    {
        var camPos = target.position;
        tr.position = Vector3.Slerp(tr.position, camPos, moveDamping * Time.deltaTime);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, rotateDamping * Time.deltaTime);
        tr.LookAt(target.position + (target.up * targetOffset));
    }
}
