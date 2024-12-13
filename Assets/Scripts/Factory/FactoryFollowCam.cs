using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryFollowCam : MonoBehaviour
{
    public Transform target; //ī�޶� ����ٴϴ� ���
    public float moveDamping = 15f; //ī�޶� �����̴� �ӵ�
    public float rotateDamping = 10f; //ȸ���� �� ȸ���ϴ� �ӵ�
    public float pitchSensitivity = 2f; // ���콺 Pitch ����

    private float currentPitch = 0f; // ���� Pitch ����

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); //�ڱ��ڽ��� ��ġ������ ������
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleCameraMovement();
        HandleMouseInput();
    }

    void HandleCameraMovement()
    {
        var cmaPos = target.position;

        tr.position = Vector3.Slerp(tr.position, cmaPos, moveDamping * Time.deltaTime); // ĳ������ �������� ����
        Quaternion targetRotation = Quaternion.Euler(currentPitch, target.eulerAngles.y, 0f); // Pitch �ݿ�
        tr.rotation = Quaternion.Slerp(tr.rotation, targetRotation, rotateDamping * Time.deltaTime); // ĳ������ ȸ���� ���� ȸ����
    }

    void HandleMouseInput()
    {
        float mouseY = Input.GetAxis("Mouse Y") * pitchSensitivity;
        currentPitch -= mouseY; // ���콺 Y�� �Է����� Pitch ����
        currentPitch = Mathf.Clamp(currentPitch, -30f, 60f); // Pitch ���� ����
    }
}
