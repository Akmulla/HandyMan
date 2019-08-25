using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 movement = Vector2.zero;

    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(mousePos);
        touchPosition.z = 0;

        Vector3 moveDirection = touchPosition - transform.position;
        movement = moveDirection * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
    }
}