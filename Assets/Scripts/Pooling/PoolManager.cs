using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PoolManager : TemporarySingleton<PoolManager>
{
    private Transform poolParent;
    
    private const int PoolCount = 10; //임시
    private List<GameObject> poolList = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
        poolParent = new GameObject("Pool Container").transform;
        poolParent.SetParent(transform);
        
        for (int i = 0; i < PoolCount; ++i)
        {
            GameObject poolObject = new GameObject("Free Object");
            poolList.Add(poolObject);
            poolObject.transform.SetParent(poolParent);
            poolObject.SetActive(false);
        }
    }

    private GameObject GetFreeObject()
    {
        for (int i = 0; i < poolList.Count; ++i)
        {
            if (!poolList[i].activeSelf)
            {
                return poolList[i];
            }
        }
        GameObject obj = new GameObject();
        poolList.Add(obj);
        return obj;
    }

    public void ReturnObject<T>(T returnObject) where T : Component, IPoolObject
    {
        returnObject.DeconstructObject();
        returnObject.gameObject.SetActive(false);
    }

    public T CreateObject<T>(Vector2 position) where T : Component, IPoolObject
    {
        GameObject poolObject = GetFreeObject();
        poolObject.transform.position = position;
        T component = poolObject.AddComponent<T>();
        component.ConstructObject();
        poolObject.name = typeof(T).Name;
        poolObject.SetActive(true);
        return component;
    }

}
