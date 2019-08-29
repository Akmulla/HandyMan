using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenNormalBullet : MonoBehaviour
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
        Vector2 dir = (Toolbox.Instance.handTransform.position - transform.position).normalized;

        rb.MovePosition(rb.position + dir * Time.fixedDeltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Toolbox.Instance.hand.GetDamage(damage);
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }
        else if (coll.gameObject.CompareTag("Walls"))
        {
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }
    }
}
