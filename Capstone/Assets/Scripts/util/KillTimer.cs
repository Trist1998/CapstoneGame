using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTimer : MonoBehaviour
{
    public float timeToKill;
    private GenericTimer killTimer;
    // Start is called before the first frame update
    void Start()
    {
        killTimer = new GenericTimer(timeToKill, false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(killTimer.isTimeout())
            Destroy(gameObject);
    }
}
