using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    //[SerializeField] AudioSource source;
    [SerializeField] AudioClip breakSound;

    void OnEnable()
    {
        //rb.rotation = rb.rotation + Random.Range(-15f, 45f);
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, 0f, Random.Range(-45f, 45f)));
        rb.AddForce(rb.transform.right * 5f, ForceMode2D.Impulse);
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Walls"))
        {
            Toolbox.Instance.audioSource.PlayOneShot(breakSound);
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }

        if (coll.gameObject.CompareTag("Head"))
        {
            Toolbox.Instance.audioSource.PlayOneShot(breakSound);
            Toolbox.Instance.hand.GetDamage(1);
            GetComponent<PoolRef>().pool.Deactivate(gameObject);
        }
    }
}
