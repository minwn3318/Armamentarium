using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFM : MonoBehaviour
{
    public GameObject block;
    public Camera theCamera;
    public Transform coreObject; // 코어 오브젝트의 Transform 참조

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 spawnspot = hitInfo.point + hitInfo.normal; // hit point 기준으로 생성 위치 조정
                Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);

                GameObject curblock = Instantiate(block, spawnspot, spawnRotation);

                // 항상 coreObject 아래로 추가되도록 설정
                if (coreObject != null)
                {
                    curblock.transform.SetParent(coreObject);
                }
            }
        }
    }
}

//void FixedUpdate() {
//Vector3 direction = coreGear.transform.position - block.transform.position;
//Vector3 force = direction.normalized * connectionForce;
//blockRigidbody.AddForce(force);
//}

