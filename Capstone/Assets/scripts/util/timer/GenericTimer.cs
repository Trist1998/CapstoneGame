using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

    public float getLifeTime()
    {
        return timeout;
    }

    public void setLifeTime(float lifeTime)
    {
        timeout = lifeTime;
    }

    public void addLifeTime(float lifeTime)
    {
        timeout += lifeTime;
    }

    public float getDisplayResetPercent()
    {

        return Mathf.Min( (Time.time - referenceTime)/timeout, 1);
    }
    
    public float getTimeLeft()
    {
        return timeout - (Time.time - referenceTime);
    }
    
    
}
