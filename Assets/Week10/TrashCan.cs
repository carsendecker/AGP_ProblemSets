using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (!Input.GetMouseButton(0))
        {
            Week10.objectPool.Despawn(other.gameObject);
        }
    }
}
