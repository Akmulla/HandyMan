using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Head"))
        {
            //coll.gameObject.GetComponent<Hand>().GetDamage(damage);
            Toolbox.Instance.hand.GetDamage(damage);
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }
        else if (coll.gameObject.CompareTag("Walls"))
        {
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }
    }
}
