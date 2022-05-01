using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI.Utility;
using EmeraldAI;
using EmeraldAI.Example;
using UnityEngine.UI;
using TMPro;

public class OnDeath : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public PlayerPoints playerPoint;
    public GameObject character;
    
    public void DeathEvent()
    {
        WaveSpawner.instance.EnemyDeath();
        Destroy(gameObject, 10);
    }

    public void Points()
    {
        PlayerPoints.instance.AddPoints();
    }

    public void CritPoints()
    {
        PlayerPoints.instance.AddCriticalPoints();
    }

    public void DeathPoints()
    {
        PlayerPoints.instance.AddDeathPoints();
    }    
}
