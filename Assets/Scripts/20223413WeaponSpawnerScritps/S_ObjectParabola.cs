using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjectParabola : MonoBehaviour
{
    public float initialSpeed = 10f; // 고정된 초기 속도
    public float launchAngle = 45f;   // 발사 각도
    public float gravity = -9.81f;     // 중력 값

    public float settingTime = 2.5f;

    private Rigidbody rb;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        // 발사 각도를 라디안으로 변환
        float launchAngleRad = launchAngle * Mathf.Deg2Rad;

        // 초기 속도의 X와 Y 성분 계산
        float xVelocity = initialSpeed * Mathf.Cos(launchAngleRad);
        float yVelocity = initialSpeed * Mathf.Sin(launchAngleRad);

        // Rigidbody에 초기 속도 적용
        velocity = new Vector3(xVelocity, yVelocity, 0);
        rb.velocity = velocity;
        Debug.Log("startlanch");
        StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        float initTime = 0f;
        while(initTime < settingTime)
        {
            // 매 프레임 중력 적용
            velocity.y += gravity * Time.deltaTime; // 중력 효과 적용
            rb.velocity = new Vector3(velocity.x, velocity.y, 0);

            // 발사체의 각도 업데이트
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle); // Y축을 기준으로 회전

            initTime += Time.deltaTime;

            yield return null;
        }
        Debug.Log("end");
    }

}
