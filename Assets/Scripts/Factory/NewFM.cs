using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFM : MonoBehaviour
{
    public GameObject block;
    public Camera theCamera;
    public Transform coreObject; // �ھ� ������Ʈ�� Transform ����

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
                Vector3 spawnspot = hitInfo.point + hitInfo.normal; // hit point �������� ���� ��ġ ����
                Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);

                GameObject curblock = Instantiate(block, spawnspot, spawnRotation);

                // �׻� coreObject �Ʒ��� �߰��ǵ��� ����
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

