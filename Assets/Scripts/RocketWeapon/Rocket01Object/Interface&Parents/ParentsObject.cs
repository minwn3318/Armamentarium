using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsObject : MonoBehaviour
{
    private Rigidbody objectRB;

    public GameObject spawnerObj;
    private ParentSpawner spawner;

    private float objectFireForce;
    private float objectLife;

    public virtual void InitComp()
    {
        objectRB = GetComponent<Rigidbody>();
        spawner = spawnerObj.GetComponent<ParentSpawner>();
    }
    public virtual void SetForce(float force)
    {
        objectFireForce = force;
    }

    public virtual void SetLifeTime(float time)
    {
        objectLife = time;
    }
    public virtual void Launch()
    {
        Debug.Log("Fire!!");
        // źȯ�� forward �������� ForceMode.Impulse ����
        objectRB.AddForce(transform.forward * objectFireForce, ForceMode.Impulse);

        // ���� �ð� �� ��Ȱ��ȭ
        StartCoroutine(Extinction());
    }
    public IEnumerator Extinction()
    {
        Debug.Log("Extinction");
        yield return new WaitForSeconds(objectLife);
        Debug.Log("Extinction ENd");

        spawner.ReturnPool(gameObject);

    }

}
