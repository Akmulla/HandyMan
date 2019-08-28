using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EddAttack : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;
    [SerializeField] Monster monster;
    [SerializeField] Pool normalBulletPool;
    [SerializeField] Pool angryBulletPool;
    [SerializeField] float startDelay;
    [SerializeField] float cdNormal;
    [SerializeField] float cdAngry;
    [SerializeField] BoxCollider2D collider;

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
            MathfFunc.RotateToPoint(Toolbox.Instance.handTransform.position, shotSpawn);
            if (monster.angry)
            {
                for (int i=0;i<10;i++)
                {
                    angryBulletPool.Activate(shotSpawn.position, shotSpawn.rotation);
                    yield return new WaitForSeconds(0.1f);
                }
                
                yield return new WaitForSeconds(cdAngry);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    normalBulletPool.Activate(shotSpawn.position, shotSpawn.rotation);
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(cdNormal);
            }
        }
    }
}
