using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnLaser : ParentSpawner
{
    private GameObject shootedLaser;
    public void Awake()
    {
        shootedLaser = Instantiate(prefabObj, transform.position, transform.rotation);
        SetCoolTime(2f);
        SetFireAva();
        SetLifeTime(1.5f);
        shootedLaser.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0) & GetFireBool())
        {
            Debug.Log("turn");
            Fire();
        }
    }

    public override void Fire()
    {
        SetObjVec(shootedLaser);
        StartCoroutine(ReturnObj(shootedLaser));
        StartCoroutine(FireCooldown());
    }

    public override IEnumerator ReturnObj(GameObject obj)
    {
        yield return new WaitForSeconds(GetLifeTime());
        obj.SetActive(false);
    }
}

