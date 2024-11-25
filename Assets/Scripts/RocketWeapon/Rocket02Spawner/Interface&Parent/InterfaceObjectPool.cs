using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceObjectPool
{
    public void CreatePool(int size);

    public GameObject PopObject();

    public void PushObject(GameObject obj);

}
