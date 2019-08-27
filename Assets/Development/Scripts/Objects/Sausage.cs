using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour , IGrabbable
{
    bool grabbed;
    Rigidbody2D rb;
    float baseGravityScale;
    [SerializeField] RigidbodyConstraints2D freeConstraints;
    [SerializeField] RigidbodyConstraints2D grabbedConstraints;
    [SerializeField] TrashType trashType;
    [SerializeField] Animator anim;
    [SerializeField] Animator faceAnim;
    [SerializeField] int startResource;
    int resource;
    float spinPower;
    float SpinPower
    {
        get
        {
            return spinPower;
        }
        set
        {
            spinPower = Mathf.Clamp(value, 0f, 4f);
        }
    }
    Vector2 prevVel = Vector2.zero;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        baseGravityScale = rb.gravityScale;
        rb.constraints = freeConstraints;
        
    }

    void OnEnable()
    {
        resource = startResource;
        Release();
    }

    public void Grab()
    {
        gameObject.layer = LayerMask.NameToLayer("TrashGrabbed");
        rb.constraints = grabbedConstraints;
        grabbed = true;
        rb.gravityScale = 0f;
        faceAnim.SetBool("Grab", true);
        //anim.speed = 1f;
    }

    public void Release()
    {
        gameObject.layer = LayerMask.NameToLayer("Trash");
        rb.constraints = freeConstraints;
        grabbed = false;
        rb.gravityScale = baseGravityScale;
        SpinPower = 0f;
        anim.speed = 0f;
        prevVel = Vector2.zero;
        faceAnim.SetBool("Grab", false);
    }

    public void Heal()
    {
        if (resource>0)
        {
            Toolbox.Instance.hand.Heal(1);
            resource--;
        }
        else
        {
            faceAnim.SetBool("Dead", true);
            if (grabbed)
            {
                Release();
            }
        }
        
    }

    void Update()
    {
        if (grabbed)
        {
            Vector2 vel = Toolbox.Instance.hand.GetComponent<Rigidbody2D>().velocity;

            if (vel != Vector2.zero && prevVel != Vector2.zero)
            {
                float angle = Vector2.Angle(prevVel, vel);
                if (angle > 15f)
                {
                    SpinPower += 0.5f;
                }
            }

            anim.speed = SpinPower;
            prevVel = vel;
        }
            
    }

    void FixedUpdate()
    {
        if (grabbed)
        {
            rb.position = Toolbox.Instance.grabPoint.position;
            
            SpinPower -= 0.1f;
        }
        else
        {
            if (Mathf.Abs(rb.position.x) > 12f)
            {
                if (GetComponent<PoolRef>().pool!=null)
                {
                    GetComponent<PoolRef>().pool.Deactivate(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
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
}
