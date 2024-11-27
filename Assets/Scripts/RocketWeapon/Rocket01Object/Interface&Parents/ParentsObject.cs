using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsObject : MonoBehaviour
{
    //��ź ������Ʈ�� ������ٵ�
    private Rigidbody objectRB;
    //��ź ������Ʈ�� ���� ��
    [SerializeField]
    private float objectFireForce;

    // �ʱ�ȭ �Լ�
    public virtual void InitComp()
    {
        objectRB = GetComponent<Rigidbody>();
        if (objectRB == null)
        {
            Debug.LogError($"{gameObject.name}�� Rigidbody�� �����ϴ�! Rigidbody�� �߰��ϼ���.");
            return;
        }
    }
    // ���� �� ����
    public virtual void SetForce(float force)
    {
        objectFireForce = force;
    }

    // ���� �� ���ϱ�
    public virtual float GetForce()
    {
        return objectFireForce;
    }
    // ��ź �߻� -> ���� ���� �߻�
    public virtual void Launch()
    {
        Debug.Log("Fire!!");
        // źȯ�� forward �������� ForceMode.Impulse ����
        objectRB.AddForce(transform.forward * objectFireForce, ForceMode.Impulse);
    }

}
