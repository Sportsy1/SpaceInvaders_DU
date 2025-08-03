using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Pool de proyectiles para evitar instanciar y destruir objetos constantemente, mejora el rendimiento del juego al reutilizar objetos.
/// Se pueden crear varias listas para distintas facciones con diferentes tipos de proyectiles y cantidades.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private List<FactionPool> availablePools = new List<FactionPool>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < availablePools.Count; i++)
        {
            for (int j = 0; j < availablePools[i].poolAmount; j++)
            {
                GameObject obj = Instantiate(availablePools[i].poolPrefab);
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                availablePools[i].objectPool.Add(obj);
            }
        }
    }

    /// <summary>
    /// Busca un objeto inactivo en la lista de la faccion especificada.
    /// </summary>
    public GameObject GetObjectFromPool(FactionsList faction)
    {
        for (int i = 0; i < availablePools.Count; i++)
        {
            if (availablePools[i].factionClass == faction)
            {
                for (int j = 0; j < availablePools[i].objectPool.Count; j++)
                {
                    if (!availablePools[i].objectPool[j].activeInHierarchy)
                    {
                        return availablePools[i].objectPool[j];
                    }
                }
                break;
            }
        }

        return null;
    }


}


/// <summary>
/// Se categoriza por facciones, cada faccion tiene su propia lista de objetos y pool propia.
/// </summary>
[Serializable]
public struct FactionPool
{
    public FactionsList factionClass;
    public int poolAmount;
    public GameObject poolPrefab;
    [HideInInspector]
    public List<GameObject> objectPool;
}
