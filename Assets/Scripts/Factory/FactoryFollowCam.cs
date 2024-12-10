using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryFollowCam : MonoBehaviour
{
    public Transform target; //카메라가 따라다니는 대상
    public float moveDamping = 15f; //카메라가 움직이는 속도
    public float rotateDamping = 10f; //회전할 때 회전하는 속도
    public float pitchSensitivity = 2f; // 마우스 Pitch 감도

    private float currentPitch = 0f; // 현재 Pitch 각도

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); //자기자신의 위치정보를 가져옴
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

        tr.position = Vector3.Slerp(tr.position, cmaPos, moveDamping * Time.deltaTime); // 캐릭터의 움직임을 따라감
        Quaternion targetRotation = Quaternion.Euler(currentPitch, target.eulerAngles.y, 0f); // Pitch 반영
        tr.rotation = Quaternion.Slerp(tr.rotation, targetRotation, rotateDamping * Time.deltaTime); // 캐릭터의 회전에 따라 회전함
    }

    void HandleMouseInput()
    {
        float mouseY = Input.GetAxis("Mouse Y") * pitchSensitivity;
        currentPitch -= mouseY; // 마우스 Y축 입력으로 Pitch 변경
        currentPitch = Mathf.Clamp(currentPitch, -30f, 60f); // Pitch 각도 제한
    }
}
