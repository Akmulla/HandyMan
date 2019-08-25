using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static Toolbox Instance { get; set; }

    public PoolManager poolManager;

    void Awake()
    {
        Instance = this;
    }
}
