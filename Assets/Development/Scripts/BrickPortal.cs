using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPortal : MonoBehaviour
{
    public Animator anim;
    public Pool brickPool;
    public Transform shotSpawn;
    public float spawnCd;
    public float startDelay;


    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(AttackCor());
    }

    IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            var obj = brickPool.Activate(shotSpawn.position, shotSpawn.rotation);
            //obj.GetComponent<Rigidbody2D>().AddForce(obj.transform.right*5f,ForceMode2D.Impulse);
            yield return new WaitForSeconds(spawnCd+Random.Range(0f,1f));
        }
    }
}
