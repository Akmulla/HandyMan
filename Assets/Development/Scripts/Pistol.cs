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

    void OnEnable()
    {
        StopAllCoroutines();
        //StartAttack();
    }

    IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            MathfFunc.RotateToPoint(Toolbox.Instance.head.transform.position, pistol);

            //MathfFunc.RotateToPoint(Toolbox.Instance.handTransform.position, pistol);
            //yield return null;
            var obj = bulletPool.Activate(shotSpawn.position, shotSpawn.rotation);
            yield return new WaitForSeconds(spawnCd);
        }
    }

    public void StartAttack()
    {
        StartCoroutine(AttackCor());
    }
}
