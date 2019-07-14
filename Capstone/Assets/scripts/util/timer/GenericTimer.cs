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

    public bool isTimeout(float deltaTime)
    {
        if(done && !reload)
            return true;
        timer += deltaTime;
        if(timer >= timeout)
        {
            timer = 0;
            done = true;
            return true;
        }
        return false;
    }
}
