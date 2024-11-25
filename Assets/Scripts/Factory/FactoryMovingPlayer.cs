using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMovingPlayer : MonoBehaviour
{
    Transform tr;
    Vector3 m_Movement;
    private float moveSpeed = 10;
    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetInput()
    {
        // аб©Л
        h = Input.GetAxisRaw("Horizontal");
        // ╬у╣з
        v = Input.GetAxisRaw("Vertical");

        m_Movement = new Vector3(h, 0, v);
        tr.position += m_Movement * moveSpeed * Time.deltaTime;

    }
}
