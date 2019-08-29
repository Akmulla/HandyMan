using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAttack : MonoBehaviour
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
                angryBulletPool.Activate(shotSpawn.position, shotSpawn.rotation);

                yield return new WaitForSeconds(cdAngry);
            }
            else
            {
                normalBulletPool.Activate(shotSpawn.position, shotSpawn.rotation);
                
                yield return new WaitForSeconds(cdNormal);
            }
        }
    }
}
