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
    bool activated;

    void Start()
    {
        activated = true;
        lineRend.startColor = attackColor;
        lineRend.endColor = attackColor;
    }

    public void Deactivate()
    {
        lineRend.enabled = false;
        activated = false;
    }

    void Update()
    {
        if (!activated)
            return;

        transform.Translate(Vector3.down * Time.deltaTime * speed);
        lineRend.SetPosition(0, left.position);
        var hit = Physics2D.Linecast(left.position, right.position, laserMask);
        if (hit)
        {
            //lineRend.SetPosition(1, hit.point);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Toolbox.Instance.hand.GetDamage(10000);
            }
        }
        else
        {
            lineRend.SetPosition(1, right.position);
            if (Toolbox.Instance.handTransform.position.y >= left.position.y)
            {
                Toolbox.Instance.hand.GetDamage(10000);
            }
        }
        lineRend.SetPosition(1, right.position);
    }
}
