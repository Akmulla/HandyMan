using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour, IGrabbable
{
    [SerializeField] LaserTrap trap;
    bool grabbed;
    Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRend;
    [SerializeField] Sprite rippedWire;
    Vector3 startPos;
    bool ripped;
    float speed = 10f;

    void OnEnable()
    {
        ripped = false;
        startPos = transform.position;
    }

    public void Grab()
    {
        if (!ripped)
        {
            grabbed = true;
        }
        
    }

    public void Release()
    {
        grabbed = false;
    }

    void Update()
    {
        if (ripped)
        {
            return;
        }
        if (grabbed)
        {
            if ((Toolbox.Instance.grabPoint.position - transform.position).magnitude>0.1f)
            {
                transform.Translate((Toolbox.Instance.grabPoint.position - transform.position).normalized * Time.deltaTime * speed);
            }
            
            //rb.position = Toolbox.Instance.grabPoint.position;
            if ((transform.position - startPos).magnitude > 0.5f)
            {
                Release();
                spriteRend.sprite = rippedWire;
                ripped = true;
                speed = 0;
                trap.Deactivate();
            }
        }
        else
        {
            
            //if (Mathf.Abs(rb.position.x) > 12f)
            //{
            //    GetComponent<PoolRef>().pool.Deactivate(gameObject);
            //}
        }
    }

}
