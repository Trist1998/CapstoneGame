using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amount; i++)
        {
            spawnObject();
        }
        
    }

    public void spawnObject()
    {
        Instantiate(objects[Random.Range(0, objects.Length)], transform.position, transform.rotation);
    }
}
