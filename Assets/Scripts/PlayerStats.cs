using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;

    void Awake()
    {
        Money = 0;
    }

    public static void addReward(int reward)
    {
        Money += reward;
    }
}
