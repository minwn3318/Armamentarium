using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaObject : ParentsObject
{
    private float gravity = -9.8f;    // 중력 값
    private Vector3 velocity;        // 현재 속도
    private bool isMoving = false;   // 운동 상태 플래그

    private void Awake()
    {
        SetForce(10f);
        SetMovBool(false);
        StartCoroutine(ParabolicUpdate());
    }

    public void SetVelocity(Vector3 vel) 
    { 
        velocity = vel; 
    }

    public void SetMovBool(bool b)
    {
        isMoving = b;
    }

    public IEnumerator ParabolicUpdate()
    {
        Vector3 position = transform.position;

        while (position.y >= 0) // 오브젝트가 지면에 도달할 때까지
        {
            // 중력 적용
            velocity += Vector3.up * gravity * Time.deltaTime;

            // 위치 업데이트
            Vector3 previousPosition = position; // 이전 위치 저장
            position += velocity * Time.deltaTime;
            transform.position = position;

            // 포물선 경로를 따라 회전
            Vector3 direction = position - previousPosition; // 이동 방향 계산
            if (direction != Vector3.zero) // 방향 벡터가 0이 아니면 회전 적용
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            yield return null; // 다음 프레임 대기

        }

        // 운동 종료
        isMoving = false;
        gameObject.SetActive(false);
    }
}
