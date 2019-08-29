using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] LineRenderer lineRend;
    [SerializeField] LayerMask laserMask;
    [SerializeField] Color attackColor;
    [SerializeField] float speed;

    void Start()
    {
        lineRend.startColor = attackColor;
        lineRend.endColor = attackColor;
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        lineRend.SetPosition(0, left.transform.position);
        var hit = Physics2D.Linecast(left.position, right.position, laserMask);
        if (hit)
        {
            lineRend.SetPosition(1, hit.point);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Toolbox.Instance.hand.GetDamage(10000);
            }
        }
    }
}
