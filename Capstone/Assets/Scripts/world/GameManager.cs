using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Spawner[] spawners;
    public int waveNo;
    public float timeBetweenWaves;
    private GenericTimer timer;
    [SerializeField]
    private int numberSpawned;
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private Camera player1;
    [SerializeField]
    private Camera player2;
    public Texture Crosshair;
    public Text waveText;

    private int noDeaths;

    private void Start()
    {
        timer = new GenericTimer(10, false);
        if (player2 != null)
        {
            player1.rect = new Rect(0,0,0.5f,1);
            player2.rect = new Rect(0.5f,0,0.5f,1);
            player2.GetComponent<AudioListener>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (timer == null) return;
        if (timer.isTimeout())
        {
            noDeaths = 0;
            timer = null;
            
            numberSpawned += waveNo + waveNo/2;
            numberSpawned = (numberSpawned / spawners.Length);
            numberSpawned *= spawners.Length;
            foreach (var spawner in spawners)
            {
                spawner.spawnObjects(numberSpawned/spawners.Length, objects);
            }
        }
    }
    
    private void OnGUI()
    {
        float xMin = (Screen.width / (player2 != null?4:2)) - (Crosshair.width / 2);
        float yMin = (Screen.height / 2) - (Crosshair.height / 2);
        
        GUI.DrawTexture(new Rect(xMin, yMin, Crosshair.width, Crosshair.height), Crosshair);
        if(player2 != null)
            GUI.DrawTexture(new Rect(xMin + Screen.width/2.0f, yMin, Crosshair.width, Crosshair.height), Crosshair);
    }

    public void recordDeath()
    {
        noDeaths++;
        if(numberSpawned <= noDeaths)
            endWave();
    }

    private void endWave()
    {
        waveNo++;
        waveText.text = "Wave: " + waveNo;
        timer = new GenericTimer(timeBetweenWaves, false);
    }
    
    
}
