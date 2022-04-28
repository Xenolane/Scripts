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
    public WaveSpawner gameManager;
    public PlayerPoints playerPoint;
    public GameObject character;
    private void Awake()
    {
        FindObjectOfType<PlayerPoints>();
    }
    public void DeathEvent()
    {
        gameManager.enemiesAlive--;
        playerPoint.currentPoints += 50;
    }
}
