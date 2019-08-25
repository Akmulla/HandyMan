using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform tran { get; set; }
    [SerializeField] Transform spawnPos;
    GameObject activeMonster;

    void Start()
    {
        tran = GetComponent<Transform>();
    }

    void OnEnabled()
    {
        activeMonster = null;
    }

    public void Spawn(GameObject monsterObj)
    {
        monsterObj.transform.position = spawnPos.position;
        monsterObj.SetActive(true);
        activeMonster = monsterObj;
    }

    public void Close()
    {
        if (activeMonster!=null)
        {
            activeMonster.SetActive(false);
        }
        activeMonster = null;

    }
}