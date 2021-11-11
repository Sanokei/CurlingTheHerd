using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GoalManager : MonoBehaviour
{   
    public static float playerNotSeenTime = 0f;
    public static readonly float playerNotSeenTimeMax = 10f;
    public static GoalManager instance{get; private set;}
    public static float goalSpeed = 3f;
    public static bool Tutorial = true;
    public static float goalAttackChance = 80f;
    public static int goalsScored = 0;
    public static int goalsTotal = 0;
    public static bool Dead = false;
    void Awake()
    {
        instance = this;
    }
    void Start(){
    }
}

