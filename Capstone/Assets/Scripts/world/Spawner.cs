using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public int startAmount = 0;
    public GameManager manager;
    public int noToSpawn;
    public int maxSpawn;

    // Start is called before the first frame update
    void Start()
    {
        manager = transform.root.GetComponent<GameManager>();
        for(int i = 0; i < startAmount; i++)
        {
            spawnObject();
        }
        
    }

    public void spawnObjects(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            spawnObject();
        }
    }
    
    public void spawnObjects(int amount, GameObject[] toSpawn)
    {
        objects = toSpawn;
        noToSpawn = amount;
        for(int i = 0; i < amount%maxSpawn; i++)
        {
            spawnObject(objects[Random.Range(0, objects.Length)]);
        }
    }

    private void spawnObject()
    {
        spawnObject(objects[Random.Range(0, objects.Length)]);
    }
    
    public void spawnObject(GameObject toSpawn)
    {
        noToSpawn--;
        GameObject obj = Instantiate(toSpawn, transform.position + new Vector3(Random.Range(0, 3.0f),0, Random.Range(0, 3.0f)), transform.rotation);
        WorldObject wObj = obj.GetComponent<WorldObject>();
        if (wObj != null)
            wObj.setSpawner(this);

    }

    public void objectDestroyed()
    {
        if(manager != null)
            manager.recordDeath();
        if (noToSpawn > 0)
        {
            spawnObject();
        }
            
    }
}
