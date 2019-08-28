using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleAngryBullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damage;
    float timePassed;
    Vector2 forward;
    Vector2 up;
    Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        timePassed = 0f;
        startPos = transform.position;
        forward = transform.right;
        up = transform.up;
    }

    void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;
        Vector3 offset = Vector3.zero;
        Vector2 horiz = startPos + forward * timePassed * speed;
        Vector2 vert = up * Mathf.Sin(timePassed * 5f) * 1.0f;


        rb.MovePosition(horiz + vert);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
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
