using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static Toolbox Instance { get; set; }

    public Transform grabPoint;
    public PoolManager poolManager;
    public Transform handTransform;
    public Hand hand;

    void Awake()
    {
        Instance = this;
    }
}
