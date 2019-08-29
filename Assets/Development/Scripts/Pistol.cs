using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Animator anim;
    public Pool bulletPool;
    public Transform shotSpawn;
    public Transform pistol;
    public float spawnCd;
    public float startDelay;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] shootSounds;

    void OnEnable()
    {
        StopAllCoroutines();
        StartAttack();
    }

    IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(startDelay);
        float lastAttackTime = Time.time;
        while (true)
        {
            MathfFunc.RotateToPoint(Toolbox.Instance.head.transform.position, pistol);
            if (Time.time > lastAttackTime+spawnCd)
            {
                source.PlayOneShot(shootSounds[Random.Range(0,shootSounds.Length)]);
                var obj = bulletPool.Activate(shotSpawn.position, shotSpawn.rotation);
                yield return new WaitForSeconds(spawnCd+Random.Range(0f,1f));
            }
            else
            {
                yield return null;
            }
            
        }
    }

    public void StartAttack()
    {
        StartCoroutine(AttackCor());
    }
}
