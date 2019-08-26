using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static Toolbox Instance { get; set; }

    public Transform grabPoint;
    public PoolManager poolManager;
    public Transform handTransform;

    void Awake()
    {
        Instance = this;
    }
}
