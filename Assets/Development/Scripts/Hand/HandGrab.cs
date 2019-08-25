using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandState { Free, Grab}

public class HandGrab : MonoBehaviour
{
    [SerializeField] float grabRadius;
    HandState handState;
    Rigidbody2D rb;
    TrashObj grabbedObj;
    Animator anim;


    void Start()
    {
        handState = HandState.Free;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (handState == HandState.Free)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Grab();
            }
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                Release();
            }
        }
    }

    void Grab()
    {
        anim.SetBool("Grab", true);
        handState = HandState.Grab;
        gameObject.layer = LayerMask.NameToLayer("HandGrabbed");
    }

    void Release()
    {
        anim.SetBool("Grab", false);
        handState = HandState.Free;
        gameObject.layer = LayerMask.NameToLayer("HandFree");
    }
}
