using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void recordDeath()
    {
        noDeaths++;
        if(numberSpawned <= noDeaths)
            endWave();
    }

    private void endWave()
    {
        waveNo++;
        timer = new GenericTimer(timeBetweenWaves, false);
    }
    
    
}
