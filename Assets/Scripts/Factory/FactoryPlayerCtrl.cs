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

    //���콺
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
        //Ű����
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //���콺
        x = Input.GetAxis("Mouse X") * sensitivity;

        //Ű����
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); //�������� ���� ����
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self); //�������� ��
                                                                                   //���� �̵�
        if (Input.GetKey(KeyCode.Space))
        {
            tr.Translate(Vector3.up * verticalSpeed * Time.deltaTime, Space.World); // ���� �̵�
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tr.Translate(Vector3.down * verticalSpeed * Time.deltaTime, Space.World); // �Ʒ��� �̵�
        }

        //���콺
        tr.Rotate(Vector3.up * rotSpeed * x * Time.deltaTime); // �¿� ȸ��

    }
}
