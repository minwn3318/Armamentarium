using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRoaterBody : MonoBehaviour
{
    public float horizontalSpeed = 2f; // �¿� ȸ�� �ӵ�
    public float verticalSpeed = 2f;   // ���Ʒ� ȸ�� �ӵ�

    private float horizontalAngle = 0f; // ���� ���� ����
    private float verticalAngle = 0f;   // ���� ���� ����

    public float horizontalLimit = 60f; // �¿� ȸ�� ���� ����
    public float verticalLimit = 60f;   // �� ȸ�� ���� ����


    void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X"); // �¿� ���콺 ������
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel"); // ���콺 �� �Է�

        // ���� ���� ��� �� ���� ����
        horizontalAngle += mouseX * horizontalSpeed;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -horizontalLimit, horizontalLimit);

        // ���� ���� ��� �� ���� ����
        verticalAngle += mouseWheel * verticalSpeed * 10f;
        verticalAngle = Mathf.Clamp(verticalAngle, 0, verticalLimit);

        Quaternion horizontalRotation = Quaternion.Euler(0, horizontalAngle, 0); // Y�� ȸ��
        Quaternion verticalRotation = Quaternion.Euler(-verticalAngle, 0, 0);   // X�� ȸ��

        // ���� ȸ�� ����
        transform.rotation = horizontalRotation * verticalRotation;
    }
}

