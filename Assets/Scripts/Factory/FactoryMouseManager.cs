using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMouseManager : MonoBehaviour
{
    public GameObject block;
    public Camera theCamera;

    private Transform coreGearTransform;
    // Start is called before the first frame update
    void Start()
    {
        coreGearTransform = GameObject.FindWithTag("CoreGear").transform;
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
                Vector3 spawnspot = hitInfo.collider.transform.position + hitInfo.normal;
                Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);

                GameObject curblock = Instantiate(block, spawnspot, spawnRotation);

                curblock.transform.SetParent(coreGearTransform);

                RegisterConnection(hitInfo.collider.gameObject, curblock);
            }

        }
    }

    // ���� ������ �����ϴ� �Լ� (���� ����)
    void RegisterConnection(GameObject parent, GameObject child)
    {
        // �� ������Ʈ ���� ��� ��ġ/ȸ�� ���� ����
        Vector3 localPosition = parent.transform.InverseTransformPoint(child.transform.position);
        Quaternion localRotation = Quaternion.Inverse(parent.transform.rotation) * child.transform.rotation;

        // ���� ������ �����ϰų� UI�� ǥ��
        Debug.Log($"Connected {parent.name} to {child.name} at relative position {localPosition}");
    }
}