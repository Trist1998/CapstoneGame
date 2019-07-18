using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedObjectEffect : MonoBehaviour
{

    private GenericTimer tickTimer;//Determines the rate at which the effect is applied
    private GenericTimer lifeTimer;//Determines how long the effect lives

    /**
     * Affect object is called once per tick of the effect.
     * Umimplemented affectObjects() may be used to maintain a state on the object
     */
    public virtual void affectObject()
    {}

    /**
     * Used to check the state of the object this is affecting and react accordingly.
     * e.g. an attached fire effect will check for wet state on the object and will be destroyed
     */
    protected virtual void checkState()
    {}

    public void attachEffect(float tickTime)
    {
        tickTimer = new GenericTimer(tickTime, true);
    }

    public virtual void attachEffect(float tickTime, float lifeTime)
    {
        if(tickTime > 0)
            tickTimer = new GenericTimer(tickTime, true);
        lifeTimer = new GenericTimer(lifeTime, false);
    }

    public virtual void endEffect()
    {
        Destroy(this);          
    }

    /**
     * Checks if a tick must occur. If tickTimer is null returns false.
     */
    private bool tick()
    {
        return tickTimer == null || tickTimer.isTimeout(Time.deltaTime);
    }

    /**
     * Update is called once per frame
     */
    void Update()
    {
        checkState();
        if (lifeTimer != null && lifeTimer.isTimeout(Time.deltaTime))
        {
            endEffect();
        }
        if(tick())
        {
            affectObject();
        }   
    }

}
