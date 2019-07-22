using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedObjectEffect : MonoBehaviour
{
    public static readonly string STATE_WET = "WET";
    public static readonly string STATE_FIRE = "FIRE";
    
    protected static readonly string END_EFFECT_TIME_OUT = "END_TIMEOUT";

    private GenericTimer tickTimer;//Determines the rate at which the effect is applied
    private GenericTimer lifeTimer;//Determines how long the effect lives
    protected Dictionary<string, int> appliedStates = new Dictionary<string, int>();
    protected Dictionary<string, int> negatingStates = new Dictionary<string, int>();

    /**
     * Affect object is called once per tick of the effect.
     * Unimplemented affectObjects() may be used to maintain a state on the object
     */
    public virtual void affectObject()
    {}

    /**
     * Used to check the state of the object this is affecting and react accordingly.
     * e.g. an attached fire effect will check for wet state on the object and will be destroyed
     */
    protected virtual void checkState()
    {
        AttachedObjectEffect[] effects = GetComponents<AttachedObjectEffect>();
        foreach (var effect in effects)
        {
            if (effect.compareStates(this))
            {
                break;
            }
        }
        
    }

    /**
     * Compares the states of the objects
     */
    public bool compareStates(AttachedObjectEffect effect)
    {
        foreach (var state in effect.getNegationStates())
        {
            
            if (!appliedStates.ContainsKey(state.Key)) 
                continue;
            int stateStrength = appliedStates[state.Key];
            if (stateStrength >= state.Value)
            {
                effect.endEffect(state.Key);
                break;
            }
        }
        
        foreach (var state in effect.getAppliedStates())
        {
            if (!negatingStates.ContainsKey(state.Key)) 
                continue;
            int stateStrength = negatingStates[state.Key];
            if (stateStrength <= state.Value)
            {
                endEffect(state.Key);
                return false;
            }
        }

        return true;
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
     *     lifeTime determines how long(in seconds) the effect will last
     */
    public virtual void startEffect(float lifeTime)
    {
        lifeTimer = new GenericTimer(lifeTime, true);
        checkState();
    }
    /**
     * Used to set up and start effect once attached
     *      lifeTime determines how long(in seconds) the effect will last
     *      tickTime determines how often affectObject() is called
     */
    public virtual void startEffect(float tickTime, float lifeTime)
    {
        tickTimer = new GenericTimer(tickTime, true);
        lifeTimer = new GenericTimer(lifeTime, false);
        checkState();
    }

    /**
     * Used to clean up effect to remove lingering effects on the object
     */
    public virtual void endEffect()
    {
        Destroy(this);          
    }
    
    /**
     * Used to end effect in different ways
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
        if (lifeTimer != null && lifeTimer.isTimeout())
        {
            endEffect(END_EFFECT_TIME_OUT);
        }
        if(tick())
        {
            affectObject();
        }   
    }
    
    protected bool isMovableObject()
    {
        return GetComponent<Rigidbody>() != null && !GetComponent<Rigidbody>().isKinematic;
    }

}
