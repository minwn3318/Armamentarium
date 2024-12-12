using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMouseManager : MonoBehaviour
{
    public GameObject blockNormal;
    public GameObject blockWoodden;
    public GameObject blockMetalic;
    public GameObject wheelWooden;
    public GameObject weaponBallista;
    public GameObject weaponCannon;

    private GameObject selectedBlock; //���õ� ����

    public Camera theCamera; //�����ɽ�Ʈ

    private Transform coreGearTransform;
    // Start is called before the first frame update
    void Start()
    {
        coreGearTransform = GameObject.FindWithTag("CoreGear").transform;
        selectedBlock = blockNormal;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        BlockSelection();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.name.Contains("Wheel_Wooden_01"))
                {
                    Debug.Log("Cannot place blocks on Wooden Wheel");
                    return;
                }
                if (hitInfo.collider.gameObject.name.Contains("Weapon_Ballista_01"))
                {
                    Debug.Log("Cannot place blocks on Weapon Ballista");
                    return;
                }
                if (hitInfo.collider.gameObject.name.Contains("Weapon_Cannon_01"))
                {
                    Debug.Log("Cannot place blocks on Weapon Ballista");
                    return;
                }
                Vector3 spawnspot = hitInfo.collider.transform.position + hitInfo.normal;
                Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);

                GameObject curblock = Instantiate(selectedBlock, spawnspot, spawnRotation);

                curblock.transform.SetParent(coreGearTransform);

                RegisterConnection(hitInfo.collider.gameObject, curblock);
            }

        }
    }

    // ���� ������ �����ϴ� �Լ�
    void RegisterConnection(GameObject parent, GameObject child)
    {
        // �� ������Ʈ ���� ��� ��ġ/ȸ�� ���� ����
        Vector3 localPosition = parent.transform.InverseTransformPoint(child.transform.position);
        Quaternion localRotation = Quaternion.Inverse(parent.transform.rotation) * child.transform.rotation;

        // ���� ������ �����ϰų� UI�� ǥ��
        Debug.Log($"Connected {parent.name} to {child.name} at relative position {localPosition}");
    }

    void BlockSelection()
    {
        // 1��Ű ������ �⺻����
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBlock = blockNormal;
            Debug.Log("Normal block selected");
        }
        // 2��Ű ������ ��������
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBlock = blockWoodden;
            Debug.Log("Wooden block selected");
        }
        // 2��Ű ������ ö����
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedBlock = blockMetalic;
            Debug.Log("Metalic block selected");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedBlock = wheelWooden;
            Debug.Log("Wooden wheel selected");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedBlock = weaponBallista;
            Debug.Log("Weapon ballista selected");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            selectedBlock = weaponCannon;
            Debug.Log("Weapon cannon selected");
        }
    }
}