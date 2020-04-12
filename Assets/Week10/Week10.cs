using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using SimpleJSON;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class Week10 : MonoBehaviour
{
    /*
     * Create an object pool implementation.
     *
     * Requirements:
     *     - When prefab is added, create multiples and set them inactive
     *     - When Spawn() is called, either turn an inactive object on, or if there isn't one, spawn another
     *     - When Despawn() is called on an object, return it to the object pool
     *
     * Extra Ideas:
     *     Make a class that inherits from monobehavior to replace Start and Destroy
     *         - Initialization to replace "Start()"
     *         - Despawn to replace "Destroy()"
     *     Add position and rotation to Spawn()
     *     Allow there to be multiple kinds of prefabs tracked in the pool
     *     Make Despawn track what type of object was spawned/despawned and return to the right pool
     */

    public GameObject prefabToPool;
    public static ObjectPool objectPool;
    public void Start()
    {
        objectPool = new ObjectPool();
        objectPool.Add(prefabToPool);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectPool.Spawn(prefabToPool);
        }
    }
}

public class ObjectPool
{
    public void Add(GameObject toPool)
    {
        
    }

    public void Spawn(GameObject pooledObject)
    {
        
    }

    public void Despawn(GameObject toDespawn)
    {
        Debug.Log("Despawning " + toDespawn.name);
    }
}