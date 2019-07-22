using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health;
    public GameObject player;
    public GameObject playerTwo;

    public float damaage = 10f;
    public float range = 100f;

    public GameObject gunOne;
    public GameObject gunTwo;

    
    // Start is called before the first frame update
    void Start()
    {
        //get the players
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.GetComponent<NavMeshAgent>().SetDestination(
            player.transform.position);
    }

    void shoot()
    {
        //shoot gun
        RaycastHit hitOne;
        if(Physics.Raycast(gunOne.transform.position, gunOne.transform.forward, out hitOne, range))
        {
            //something got hit, check if its the player
        }

        RaycastHit hitTwo;

        if (Physics.Raycast(gunTwo.transform.position, gunTwo.transform.forward, out hitTwo, range))
        {
            //something got hit, check if its the player
        }

    }
}
