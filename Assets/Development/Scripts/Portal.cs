using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform tran { get; set; }
    [SerializeField] Transform spawnPos;
    [SerializeField] Animator anim;
    GameObject activeMonster;

    void Start()
    {
        tran = GetComponent<Transform>();
    }

    void Update()
    {
        if (activeMonster != null)
        {
            if (!activeMonster.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
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
        //if (activeMonster!=null)
        //{
        //    activeMonster.SetActive(false);
        //}
        //activeMonster = null;
        gameObject.SetActive(false);
    }
}