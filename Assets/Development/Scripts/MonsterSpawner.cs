using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Portal[] portals;
    [SerializeField] Monster[] monsters;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float startDelay;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator SpawnCor()
    {
        
        yield return null;
    }

    void SpawnPortal()
    {
        List<Portal> availPortals = new List<Portal>();
        List<Monster> availMonsters = new List<Monster>();

        for (int i=0;i<portals.Length;i++)
        {
            if (portals[i].gameObject.activeSelf)
            {
                availPortals.Add(portals[i]);
            }
        }

        for (int i = 0; i < portals.Length; i++)
        {
            if (portals[i].gameObject.activeSelf)
            {
                availPortals.Add(portals[i]);
            }
        }
    }
}