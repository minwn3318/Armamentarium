using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPlayerCtrl : MonoBehaviour
{
    float h = 0f;
    float v = 0f;

    Transform tr;
    private float moveSpeed = 10f;
    private float verticalSpeed = 5f;

    //마우스
    float x = 0f;
    float sensitivity = 1f;
    private float rotSpeed = 300f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        //키보드
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //마우스
        x = Input.GetAxis("Mouse X") * sensitivity;

        //키보드
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); //움직임을 담은 벡터
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self); //움직임을 줌
                                                                                   //상하 이동
        if (Input.GetKey(KeyCode.Space))
        {
            tr.Translate(Vector3.up * verticalSpeed * Time.deltaTime, Space.World); // 위로 이동
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tr.Translate(Vector3.down * verticalSpeed * Time.deltaTime, Space.World); // 아래로 이동
        }

        //마우스
        tr.Rotate(Vector3.up * rotSpeed * x * Time.deltaTime); // 좌우 회전

    }
}
