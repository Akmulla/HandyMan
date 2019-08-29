﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour
{
    public static Toolbox Instance { get; set; }

    public Transform grabPoint;
    public PoolManager poolManager;
    public Transform handTransform;
    public Hand hand;
    public Progress progressBar;
    public Head head;
    public GameController gameController;
    public AudioSource audioSource;

    void Awake()
    {
        Instance = this;
    }
}
