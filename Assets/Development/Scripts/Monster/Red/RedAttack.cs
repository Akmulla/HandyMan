using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAttack : MonoBehaviour
{
    [SerializeField] Transform[] shotSpawns;
    [SerializeField] Monster monster;
    [SerializeField] Pool normalBulletPool;
    [SerializeField] Pool angryBulletPool;
    [SerializeField] float startDelay;
    [SerializeField] float cdNormal;
    [SerializeField] float cdAngry;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip attackSound;

    void OnAwake()
    {
        //source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(AttackCor());
    }

    IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(startDelay);
        while (collider.enabled)
        {
            if (monster.angry)
            {
                for (int i = 0; i < shotSpawns.Length; i++)
                {
                    source.PlayOneShot(attackSound);
                    angryBulletPool.Activate(shotSpawns[i].position, shotSpawns[i].rotation);
                    yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));
                }
                    
                yield return new WaitForSeconds(cdAngry);
            }
            else
            {
                source.PlayOneShot(attackSound);
                angryBulletPool.Activate(shotSpawns[1].position, shotSpawns[1].rotation);
                //normalBulletPool.Activate(shotSpawn.position, shotSpawn.rotation);
                //normalBulletPool.Activate(shotSpawn.position, Quaternion.Euler(shotSpawn.rotation.eulerAngles + new Vector3(0f, 0f, -15f)));
                //normalBulletPool.Activate(shotSpawn.position, Quaternion.Euler(shotSpawn.rotation.eulerAngles + new Vector3(0f, 0f, 15f)));

                yield return new WaitForSeconds(cdNormal);
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < shotSpawns.Length; i++)
        {
            MathfFunc.RotateToPoint(Toolbox.Instance.handTransform.position, shotSpawns[i]);
        }
    }
}
