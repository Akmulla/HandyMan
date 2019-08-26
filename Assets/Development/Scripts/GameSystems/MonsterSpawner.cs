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
        //StartCoroutine(SpawnCor());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnCor()
    {
        while (Time.time<20f)
        {
            SpawnPortal();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        yield return null;
    }

    void SpawnPortal()
    {
        List<Portal> availPortals = new List<Portal>();
        List<Monster> availMonsters = new List<Monster>();

        for (int i=0;i<portals.Length;i++)
        {
            if (!portals[i].gameObject.activeSelf)
            {
                availPortals.Add(portals[i]);
            }
        }

        for (int i = 0; i < monsters.Length; i++)
        {
            if (!monsters[i].gameObject.activeSelf)
            {
                availMonsters.Add(monsters[i]);
            }
        }
        if (availMonsters.Count>0 && availPortals.Count>0)
        {
            int portalInd = Random.Range(0, availPortals.Count);
            availPortals[portalInd].gameObject.SetActive(true);
            availPortals[portalInd].Spawn(availMonsters[Random.Range(0, availMonsters.Count)].gameObject);
        }
        
    }
}