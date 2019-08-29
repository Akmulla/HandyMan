using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convayer : MonoBehaviour
{
    public bool moving;
    public float speed;
    public SurfaceEffector2D effector;
    public AudioSource source;

    public void On()
    {
        moving = true;
        effector.speed = speed;
        source.Play();
    }

    public void Off()
    {
        moving = false;
        effector.speed = 0f;
        source.Stop();
    }
}
