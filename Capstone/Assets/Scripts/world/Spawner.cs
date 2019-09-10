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
        print("Spawning");
        GameObject obj = Instantiate(objects[Random.Range(0, objects.Length)], transform.position + new Vector3(Random.Range(0, 3.0f),0, Random.Range(0, 3.0f)), transform.rotation);
        WorldObject wObj = obj.GetComponent<WorldObject>();
        if (wObj != null)
            wObj.setSpawner(this);

    }

    public void objectDestroyed()
    {
        spawnObject();
    }
}
