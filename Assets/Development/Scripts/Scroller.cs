using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    public Convayer conv;

    void Start()
    {
        startPosition = transform.localPosition;
        scrollSpeed = conv.speed;
    }

    void Update()
    {
        if (conv.moving)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            transform.localPosition = startPosition + Vector3.right * newPosition;
        }
        
    }
}
