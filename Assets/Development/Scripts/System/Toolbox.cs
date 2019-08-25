using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static Toolbox Instance { get; set; }

    public Transform grabPoint;
    public PoolManager poolManager;

    void Awake()
    {
        Instance = this;
    }
}
