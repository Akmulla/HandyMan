using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAttack : MonoBehaviour
{
    [SerializeField] Transform shotSpawn;
    [SerializeField] Monster monster;
    [SerializeField] Pool normalBulletPool;
    [SerializeField] float startDelay;
    [SerializeField] float cdNormal;
    [SerializeField] float cdAngry;
    [SerializeField] LineRenderer lineRend;
    [SerializeField] LayerMask laserMask;
    [SerializeField] Color prepareColor;
    [SerializeField] Color attackColor;
    [SerializeField] ParticleSystem particle;
    [SerializeField] int damage;
    [SerializeField] BoxCollider2D collider;

    void OnEnable()
    {
        particle.Stop();
        StopAllCoroutines();
        StartCoroutine(AttackCor());
    }

    void OnDisable()
    {
        StopAllCoroutines();
        lineRend.enabled = false;
    }

    IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(startDelay);
        while (collider.enabled)
        {
            MathfFunc.RotateToPoint(Toolbox.Instance.handTransform.position, shotSpawn);
            if (monster.angry)
            {
                particle.Stop();
                lineRend.enabled = true;
                float startTime = Time.time;
                while(Time.time-startTime<2.5f)
                {
                    lineRend.SetPosition(0, shotSpawn.position);
                    lineRend.startColor = prepareColor;
                    lineRend.endColor = prepareColor;
                    var hit = Physics2D.Raycast(shotSpawn.position, shotSpawn.right, 25f, laserMask);
                    if (hit)
                    {
                        lineRend.SetPosition(1, hit.point + (Vector2)shotSpawn.right*0.1f);
                    }
                    else
                    {
                        lineRend.SetPosition(1, shotSpawn.position + shotSpawn.right * 35f);
                    }
                    yield return null;
                }

                startTime = Time.time;
                particle.Play();
                while (Time.time - startTime < 2.5f)
                {
                    lineRend.startColor = attackColor;
                    lineRend.endColor = attackColor;
                    var hit = Physics2D.Raycast(shotSpawn.position, shotSpawn.right, 25f, laserMask);
                    if (hit)
                    {
                        //lineRend.SetPosition(1, hit.point + (Vector2)shotSpawn.right * 0.1f);
                        lineRend.SetPosition(1, hit.point);
                        if (hit.collider.gameObject.CompareTag("Player"))
                        {
                            Toolbox.Instance.hand.GetDamage(damage);
                        }
                    }
                    else
                    {
                        lineRend.SetPosition(1, shotSpawn.position + shotSpawn.right * 35f);
                    }
                    particle.transform.position = lineRend.GetPosition(1);
                    //particle.transform.rotation =    Quaternion.Euler shotSpawn.rotation.eulerAngles;
                    
                    yield return null;
                }
                particle.Stop();
                lineRend.enabled = false;
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
