using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjectParabola : MonoBehaviour
{
    public float initialSpeed = 10f; // ������ �ʱ� �ӵ�
    public float launchAngle = 45f;   // �߻� ����
    public float gravity = -9.81f;     // �߷� ��

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
        // �߻� ������ �������� ��ȯ
        float launchAngleRad = launchAngle * Mathf.Deg2Rad;

        // �ʱ� �ӵ��� X�� Y ���� ���
        float xVelocity = initialSpeed * Mathf.Cos(launchAngleRad);
        float yVelocity = initialSpeed * Mathf.Sin(launchAngleRad);

        // Rigidbody�� �ʱ� �ӵ� ����
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
            // �� ������ �߷� ����
            velocity.y += gravity * Time.deltaTime; // �߷� ȿ�� ����
            rb.velocity = new Vector3(velocity.x, velocity.y, 0);

            // �߻�ü�� ���� ������Ʈ
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle); // Y���� �������� ȸ��

            initTime += Time.deltaTime;

            yield return null;
        }
        Debug.Log("end");
    }

}
