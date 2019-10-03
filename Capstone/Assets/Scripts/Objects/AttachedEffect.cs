using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedEffect : MonoBehaviour
{

    protected static readonly string END_EFFECT_TIME_OUT = "END_TIMEOUT";

    private GenericTimer tickTimer;//Determines the rate at which the effect is applied
    private GenericTimer lifeTimer;//Determines how long the effect lives
    protected Dictionary<string, int> appliedStates = new Dictionary<string, int>();
    protected Dictionary<string, int> negatingStates = new Dictionary<string, int>();
    private AttachedEffectManager manager;

    protected bool effectEnded;

    protected bool started = false;
    /**
     * Affect object is called once per tick of the effect.
     * Unimplemented affectObjects() may be used to maintain a state on the object
     */
    public virtual void affectObject()
    {}

    protected AttachedEffectManager getManager()
    {
        manager = transform.root.GetComponent<AttachedEffectManager>();
        return manager == null ? transform.root.gameObject.AddComponent<AttachedEffectManager>() : manager;
    }
    
    private void applyStates()
    {
        foreach (var state in getAppliedStates()) 
        { 
            manager.addState(state.Key,this);
        }
    }

    /**
     * Used to check the state of the object this is affecting and react accordingly.
     * e.g. an attached fire effect will check for wet state on the object and will be destroyed
     */
    private void compareState()
    {
        foreach (var state in getNegationStates())
        {
            if (!manager.hasState(state.Key)) continue;
            if (manager.checkState(state.Key, state.Value)) continue;
            
            endEffect(state.Key);
            return;
        }

    }
    
    
    /**
     * Returns a list of states that this effect applies to the object
     */
    public virtual Dictionary<string, int> getAppliedStates()
    {
        return appliedStates;
    }
    
    /**
     * Return a list of states that negate this effect
     */
    public virtual Dictionary<string, int> getNegationStates()
    {
        return negatingStates;
    }
    
    

    /**
     * Used to set up and start effect once attached
     *      lifeTime determines how long(in seconds) the effect will last
     *      tickTime determines how often affectObject() is called
     */
    public virtual void startEffect(GameObject obj, float tickTime, float lifeTime)
    {
        tickTimer = new GenericTimer(tickTime, true);
        startEffect(lifeTime);
    }
    
    /**
     * Used to set up and start effect once attached
     *     lifeTime determines how long(in seconds) the effect will last
     */
    public virtual void startEffect(float lifeTime)
    {
        
        if(lifeTime > -1.0f)
            lifeTimer = new GenericTimer(lifeTime, false);
        startEffect();
    }

    public virtual void startEffect()
    {
        manager = getManager();
        compareState();
        if (effectEnded) return;
        started = true;
        applyStates();
    }
    

    /**
     * Used to clean up effect to remove lingering effects on the object
     */
    public virtual void endEffect()
    {
        effectEnded = true;
        manager.removeEffect(this);
        Destroy(this);          
    }
    
    /**
     * Override to be used to end the effect in different ways or remove a state's effect while leaving others unaffected
     */
    public virtual void endEffect(string reason)
    {
        endEffect();
    }
    

    /**
     * Checks if a tick must occur. If tickTimer is null returns true for continuous affect.
     */
    private bool tick()
    {
        return tickTimer == null || tickTimer.isTimeout();
    }

    /**
     * Update is called once per frame
     */
    void Update()
    {
        if (!started) return;
        if (lifeTimer != null && lifeTimer.isTimeout())
        {
            endEffect(END_EFFECT_TIME_OUT);
        }
        if(!effectEnded && tick())
        {
            if(manager.stateChanged)
                compareState();
            affectObject();
        }   
    }
    
    protected bool isMovableObject()
    {
        return GetComponent<Rigidbody>() != null && !GetComponent<Rigidbody>().isKinematic;
    }

    public GenericTimer getLifeTimer()
    {
        return lifeTimer;
    }
    
    protected void setLifeTimer(GenericTimer timer)
    {
        lifeTimer = timer;
    }
    
    

}
