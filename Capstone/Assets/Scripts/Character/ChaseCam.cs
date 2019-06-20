using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCam : MonoBehaviour
{
    public GameObject chasePoint;
    public float speed = 0.5f;
    public float maxDist = 5;
    Quaternion rot;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        rot = transform.localRotation;
        parent = transform.parent.gameObject;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused == false)
        {
            transform.rotation = rot;
            Vector3 flyTo = chasePoint.transform.position;
            Vector3 heading = flyTo - transform.position;
            float dist = Vector3.Distance(transform.position, flyTo);

            Vector3 dir = heading / dist;
            this.GetComponent<Rigidbody>().velocity = dir * dist * dist * speed;

            transform.LookAt(parent.transform.position, Vector3.up);
        }

    }
}
