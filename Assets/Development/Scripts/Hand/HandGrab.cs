using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandState { Free, Grab}

public class HandGrab : MonoBehaviour
{
    [SerializeField] float grabRadius;
    [SerializeField] Transform grabPosition;
    [SerializeField] LayerMask grabMask;
    [SerializeField] LayerMask interactionMask;
    HandState handState;
    Rigidbody2D rb;
    IGrabbable grabbedObj;
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

    bool TryInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay( Camera.main.WorldToScreenPoint(grabPosition.position));
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, interactionMask);

        if (hit)
        {
            IInteractable obj = hit.collider.gameObject.GetComponent<IInteractable>();
            if (obj!=null)
            {
                obj.Interact();
                return true;
            }
        }

        return false;
    }

    void Grab()
    {
        anim.SetBool("Grab", true);
        handState = HandState.Grab;
        gameObject.layer = LayerMask.NameToLayer("HandGrabbed");

        if (TryInteract())
        {
            return;
        }

        IGrabbable obj = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(grabPosition.position, grabRadius, grabMask);

        if (colliders.Length > 0)
        {
            obj = colliders[0].GetComponent<IGrabbable>();

            float min = (grabPosition.position - colliders[0].transform.position).magnitude;

            for (int i = 1; i < colliders.Length; i++)
            {
                float d = (grabPosition.position - colliders[i].transform.position).magnitude;
                if (d < min)
                {
                    min = d;
                    obj = colliders[i].GetComponent<IGrabbable>();
                }
            }
        }

        grabbedObj = obj;
        if (grabbedObj!=null)
        {
            grabbedObj.Grab();
        }
    }

    void Release()
    {
        anim.SetBool("Grab", false);
        handState = HandState.Free;
        gameObject.layer = LayerMask.NameToLayer("HandFree");

        if (grabbedObj != null)
        {
            grabbedObj.Release();
            Vector2 vel = rb.velocity;
            if (vel.magnitude > 15f)
            {
                vel = vel.normalized * 15f;
            }

            var grabbedMono = grabbedObj as MonoBehaviour;
            grabbedMono.gameObject.GetComponent<Rigidbody2D>().AddForce(vel, ForceMode2D.Impulse);
        }
    }
}
