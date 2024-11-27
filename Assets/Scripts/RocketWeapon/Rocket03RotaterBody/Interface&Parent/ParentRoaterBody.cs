using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRoaterBody : MonoBehaviour
{
    public float horizontalSpeed = 2f; // 좌우 회전 속도
    public float verticalSpeed = 2f;   // 위아래 회전 속도

    private float horizontalAngle = 0f; // 현재 수평 각도
    private float verticalAngle = 0f;   // 현재 수직 각도

    public float horizontalLimit = 60f; // 좌우 회전 제한 각도
    public float verticalLimit = 60f;   // 위 회전 제한 각도


    void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X"); // 좌우 마우스 움직임
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel"); // 마우스 휠 입력

        // 수평 각도 계산 및 범위 제한
        horizontalAngle += mouseX * horizontalSpeed;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -horizontalLimit, horizontalLimit);

        // 수직 각도 계산 및 범위 제한
        verticalAngle += mouseWheel * verticalSpeed * 10f;
        verticalAngle = Mathf.Clamp(verticalAngle, 0, verticalLimit);

        Quaternion horizontalRotation = Quaternion.Euler(0, horizontalAngle, 0); // Y축 회전
        Quaternion verticalRotation = Quaternion.Euler(-verticalAngle, 0, 0);   // X축 회전

        // 최종 회전 적용
        transform.rotation = horizontalRotation * verticalRotation;
    }
}

