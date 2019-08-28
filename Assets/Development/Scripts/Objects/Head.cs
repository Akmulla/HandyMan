using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour, IGrabbable
{
    [SerializeField] Rigidbody2D rb;
    public float speed;
    public bool moving;
    bool moveRight;
    bool grabbed;
    [SerializeField] RigidbodyConstraints2D freeConstraints;
    [SerializeField] RigidbodyConstraints2D grabbedConstraints;
    float baseGravityScale;

    void Awake()
    {
        baseGravityScale = rb.gravityScale;
        rb.constraints = freeConstraints;
    }

    void OnEnable()
    {
        StopAllCoroutines();
        //StartCoroutine(StartCor());
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

    IEnumerator StartCor()
    {
        yield return new WaitForSeconds(3.0f);
        moving = true;
    }

    void FixedUpdate()
    {
        if (moving)
        {
            if (moveRight)
            {
                if (transform.position.x < 7.0f)
                {
                    rb.MovePosition(rb.position+Vector2.right * speed * Time.fixedDeltaTime);
                }
                else
                {
                    moveRight = false;
                }
            }
            else
            {
                if (transform.position.x > -7.0f)
                {
                    rb.MovePosition(rb.position - Vector2.right * speed * Time.fixedDeltaTime);
                }
                else
                {
                    moveRight = true;
                }
            }
        }
        else
        {
            if (grabbed)
            {
                rb.position = Toolbox.Instance.grabPoint.position;
            }
        }
    }
}
