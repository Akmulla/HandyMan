using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;

    void OnEnable()
    {
        rb.rotation = rb.rotation + Random.Range(-45f, 45f);
        rb.AddForce(rb.transform.forward * 10f, ForceMode2D.Impulse);
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Walls"))
        {
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }

        if (coll.gameObject.CompareTag("Head"))
        {
            Toolbox.Instance.hand.GetDamage(1);
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }
    }
}
