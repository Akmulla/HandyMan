using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] int baseHp;
    [SerializeField] int maxHp;
    [SerializeField] float shieldDuration;
    [SerializeField] Animator anim;
    [SerializeField] Image hpBar;

    public int hp;
    int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            hp = Mathf.Clamp(Hp, 0, maxHp);

            if (hp <= 0)
            {
                Die();
            }

            hpBar.fillAmount = (float)hp / (float)maxHp;
        }
    }

    bool shield;

    void Start()
    {
        //anim = GetComponent<Animator>();
        Hp = baseHp;
        shield = false;
    }

    public void GetDamage(int amount)
    {
        if (shield)
            return;

        Hp -= amount;
        
        if (Hp>0)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(GetShield());
        }
    }

    public void Heal(int amount)
    {
        Hp += amount;
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
