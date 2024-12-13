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

    private GameObject selectedBlock; //선택된 블록

    public Camera theCamera; //레이케스트

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        // Player 태그를 가진 게임오브젝트를 찾음
        player = GameObject.FindWithTag("Player").transform;
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
        // 마우스 좌클릭 (설치)
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
                
                // 설치될 블럭의 부모를 player로 설정
                curblock.transform.SetParent(player);

                // 위치 정보 -> 삭제하고 조인트를 이용하여 연결하는 방식으로 변경해야함
                RegisterConnection(hitInfo.collider.gameObject, curblock);
            }

        }
        // 마우스 우클릭 (삭제)
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = theCamera.ScreenPointToRay (Input.mousePosition);
            RaycastHit hitinfo;

            if(Physics.Raycast(ray,out hitinfo))
            {
                Destroy(hitinfo.collider.gameObject); 
            }
        }
    }

    // 연결 정보를 관리하는 함수
    void RegisterConnection(GameObject parent, GameObject child)
    {
        // 두 오브젝트 간의 상대 위치/회전 정보 저장
        Vector3 localPosition = parent.transform.InverseTransformPoint(child.transform.position);
        Quaternion localRotation = Quaternion.Inverse(parent.transform.rotation) * child.transform.rotation;

        // 연결 정보를 저장하거나 UI에 표시
        Debug.Log($"Connected {parent.name} to {child.name} at relative position {localPosition}");
    }

    void BlockSelection()
    {
        // 1번키 누르면 기본블럭
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBlock = blockNormal;
            Debug.Log("Normal block selected");
        }
        // 2번키 누르면 나무블럭
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBlock = blockWoodden;
            Debug.Log("Wooden block selected");
        }
        // 2번키 누르면 철블럭
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