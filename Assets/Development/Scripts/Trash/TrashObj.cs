﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObj : MonoBehaviour
{
    bool grabbed;
    Rigidbody2D rb;
    float baseGravityScale;
    [SerializeField] RigidbodyConstraints2D freeConstraints;
    [SerializeField] RigidbodyConstraints2D grabbedConstraints;
    [SerializeField] TrashType trashType;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        baseGravityScale = rb.gravityScale;
        rb.constraints = freeConstraints;
    }

    void OnEnable()
    {
        Release();
    }

    public void Grab()
    {
        gameObject.layer = LayerMask.NameToLayer("TrashGrabbed");
        rb.constraints = grabbedConstraints;
        grabbed = true;
        rb.gravityScale = 0f;
    }

    public void Release()
    {
        gameObject.layer = LayerMask.NameToLayer("Trash");
        rb.constraints = freeConstraints;
        grabbed = false;
        rb.gravityScale = baseGravityScale;
    }

    void FixedUpdate()
    {
        if (grabbed)
        {
            rb.position = Toolbox.Instance.grabPoint.position;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //print("trigger enter");
        if (coll.gameObject.CompareTag("Monster"))
        {
            Monster monster = coll.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.Feed(trashType);
                GetComponent<PoolRef>().pool.Deactivate(gameObject);
            }
        }
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        //print("trigger stay");
        if (coll.gameObject.CompareTag("Monster"))
        {
            //print("tag monster");
            Monster monster = coll.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                //print("got monster obj");
                monster.Feed(trashType);
                GetComponent<PoolRef>().pool.Deactivate(gameObject);
            }
        }
    }
}
