using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTimer
{
    private float timeout;
    private bool reload;
    private bool done;
    private float referenceTime;
    private Time time;

    public GenericTimer(float timeout, bool reload)
    {
        referenceTime = Time.time;
        this.timeout = timeout;
        this.reload = reload;
        done = false;
    }

    public bool isTimeout()
    {
        if (done || Time.time - referenceTime >= timeout)
        {
            if (!reload) 
                done = true;
            else 
                referenceTime = Time.time;
            return true;
        }
        return false;
    }

}
