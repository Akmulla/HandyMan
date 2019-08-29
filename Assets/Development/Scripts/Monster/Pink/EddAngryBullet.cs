using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EddAngryBullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Cor());
    }

    IEnumerator Cor()
    {
        yield return new WaitForSeconds(1.0f);
        rb.SetRotation(rb.rotation + Random.Range(-25f, 25f));
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Head"))
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
