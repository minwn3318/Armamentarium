using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsObject : MonoBehaviour
{
    //포탄 오브젝트의 리지드바디
    private Rigidbody objectRB;
    //포탄 오브젝트에 가할 힘
    [SerializeField]
    private float objectFireForce;

    // 초기화 함수
    public virtual void InitComp()
    {
        objectRB = GetComponent<Rigidbody>();
        if (objectRB == null)
        {
            Debug.LogError($"{gameObject.name}에 Rigidbody가 없습니다! Rigidbody를 추가하세요.");
            return;
        }
    }
    // 가할 힘 설정
    public virtual void SetForce(float force)
    {
        objectFireForce = force;
    }

    // 가할 힘 구하기
    public virtual float GetForce()
    {
        return objectFireForce;
    }
    // 포탄 발사 -> 힘을 가해 발사
    public virtual void Launch()
    {
        Debug.Log("Fire!!");
        // 탄환의 forward 방향으로 ForceMode.Impulse 적용
        objectRB.AddForce(transform.forward * objectFireForce, ForceMode.Impulse);
    }

}
