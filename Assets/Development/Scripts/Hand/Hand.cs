using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] int baseHp;
    [SerializeField] float shieldDuration;
    Animator anim;
    int hp;

    bool shield;

    void Start()
    {
        anim = GetComponent<Animator>();
        hp = baseHp;
        shield = false;
    }

    public void GetDamage(int amount)
    {
        if (shield)
            return;

        hp -= amount;
        if (hp<=0)
        {
            Die();
        }
        else
        {
            anim.SetTrigger("Damage");
            StartCoroutine(GetShield());
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator GetShield()
    {
        shield = true;
        yield return new WaitForSeconds(shieldDuration);
        shield = false;
    }
}
