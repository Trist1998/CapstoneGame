using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTimer
{
    private float timer;
    private float timeout;
    private bool reload;
    private bool done;

    public GenericTimer(float timeout, bool reload)
    {
        this.timeout = timeout;
        this.reload = reload;
        done = false;
        timer = 0;
    }

    public void updateTimer(float deltaTime)
    {
        timer += deltaTime;
    }

    public void endTimer()
    {
        timer = 0;
        done = true;
    }
    
    public bool isTimeout()
    {
        if(done && !reload)
            return true;

        if (timer >= timeout)
        {
            endTimer();
            return true;
        }
        return false;
    }
    
    public bool isTimeout(float deltaTime)
    {
        if(done && !reload)
            return true;
        updateTimer(deltaTime);
        if(timer >= timeout)
        {
            endTimer();
            return true;
        }
        return false;
    }
}
