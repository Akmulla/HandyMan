using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] int baseHp;
    [SerializeField] int maxHp;
   // [SerializeField] float shieldDuration;
    [SerializeField] Animator anim;
    [SerializeField] Image hpBar;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip damageSound;

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
            source.PlayOneShot(damageSound);
            StartCoroutine(GetShield());
        }
    }

    public void Heal(int amount)
    {
        Hp += amount;
    }

    void Die()
    {
        //Destroy(gameObject);
        Toolbox.Instance.gameController.GameOver();
    }

    IEnumerator GetShield()
    {
        shield = true;
        for (int i=0;i<5;i++)
        {
            rend.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            rend.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        //yield return new WaitForSeconds(shieldDuration);
        shield = false;
    }
}
