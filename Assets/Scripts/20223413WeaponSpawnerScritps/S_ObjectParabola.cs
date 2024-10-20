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
        Destroy(gameObject, 3f);
    }

    void LaunchProjectile()
    {
        // �߻� ������ �������� ��ȯ
        float launchAngleRad = launchAngle * Mathf.Deg2Rad;

        // �ʱ� �ӵ��� X�� Y ���� ���
        float zVelocity = initialSpeed * Mathf.Cos(launchAngleRad);
        float yVelocity = initialSpeed * Mathf.Sin(launchAngleRad);

        // Rigidbody�� �ʱ� �ӵ� ����
        velocity = new Vector3(0, yVelocity, zVelocity);
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
            rb.velocity = new Vector3(0, velocity.y, velocity.z);

            // �߻�ü�� ���� ������Ʈ
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.z) * Mathf.Rad2Deg; // ���� ���
            transform.rotation = Quaternion.Euler(-angle, 0, 0); // Y���� �������� ȸ��

            initTime += Time.deltaTime;

            yield return null;
        }
        Debug.Log("end");
    }

}
