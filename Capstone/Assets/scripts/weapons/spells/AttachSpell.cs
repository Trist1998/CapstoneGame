using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSpell : MonoBehaviour
{
    ObjectPickup shooter;
    GenericTimer tickTimer;
    GenericTimer lifeTimer;
    bool eWasUp = false;
    public float speed = 2f;
    public float MaxSpeed = 5;
    public float distance = 0;
    public float maxDist = 0.05f;
    Quaternion rot;

    public void processEffect()
    {
        InteractControl player = shooter.player;
        transform.rotation = rot;
        GetComponent<Rigidbody>().useGravity = false;
        Vector3 flyTo = player.cam.transform.position + player.cam.transform.forward * distance;
        Vector3 heading = flyTo - transform.position;
        float dist = Vector3.Distance(transform.position, flyTo);
        if (Input.GetAxis("Push") == 1 && Input.GetAxis("Fire1") == 1)
        {
            distance += 0.05f;
        }
        if (Input.GetAxis("Push") == 1 && Input.GetAxis("Fire2") == 1)
        {
            distance -= 0.05f;
        }
        Vector3 dir = heading / dist;
        if (dist > 0.05f)
        {
            if (dist > maxDist)
            {
                dist = 1;
            }
            GetComponent<Rigidbody>().velocity = dir * speed * dist;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = dir * 0;
        }

        if (Input.GetButtonUp("Interact"))//Do this in InteractControl??
        {
            eWasUp = true;
        }
    }
    public void startSpell(ObjectPickup shooter, GameObject toAttach, float tickTime, float lifeTime)
    {
        this.shooter = shooter;
        tickTimer = new GenericTimer(tickTime, true);
        lifeTimer = new GenericTimer(tickTime, false);
        lev((toAttach.transform.position - shooter.transform.position).magnitude);
    }

    public void lev(float dist)
    {
        rot = transform.localRotation;
        distance = dist;
    }

    // Update is called once per frame
    void Update()
    {
        if (tickTimer != null && tickTimer.isTimeout(Time.deltaTime))
        {
            processEffect();
        }
        else if(lifeTimer != null && lifeTimer.isTimeout(Time.deltaTime))
        {
            Destroy(gameObject);
        }
    }
}
