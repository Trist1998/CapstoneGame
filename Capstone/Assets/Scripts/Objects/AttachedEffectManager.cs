using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Priority_Queue;

public class AttachedEffectManager : MonoBehaviour
{
    public const string STATE_WET = "WET";
    public const string STATE_FIRE = "FIRE";
    public static readonly string STATE_IGNITION = "IGNITION";
    public static readonly string STATE_IGNITABLE = "IGNITABLE";
    public bool stateChanged;
    
    private Dictionary<string, SimplePriorityQueue<AttachedEffect>> attachedEffectStates = new Dictionary<string, SimplePriorityQueue<AttachedEffect>>();

    /*
     * Manages the states of an object.
     */
    
    /*
     * Returns the attachedStates Dictionary
     */
    public Dictionary<string, SimplePriorityQueue<AttachedEffect>> getAttachedStates()
    {
        return attachedEffectStates;
    }

    /*
     * Adds a state to the manager
     */
    public void addState(string stateKey, AttachedEffect attachedEffect)
    {
        stateChanged = true;
        if(!attachedEffectStates.ContainsKey(stateKey))
            attachedEffectStates[stateKey] = new SimplePriorityQueue<AttachedEffect>();
        
        attachedEffectStates[stateKey].Enqueue(attachedEffect, attachedEffect.getAppliedStates()[stateKey]);
    }

    /*
     * Returns true if manager contains the state
     */
    public bool hasState(string stateKey)
    {
        return attachedEffectStates.ContainsKey(stateKey) && attachedEffectStates[stateKey].Any() && attachedEffectStates[stateKey].First != null;
    }
    
    public bool checkState(string stateKey, int stateValue)
    {
        if (!attachedEffectStates.ContainsKey(stateKey) || attachedEffectStates[stateKey].First == null)
            return true;
        print(stateKey);
        int state2Value = attachedEffectStates[stateKey].First.getAppliedStates()[stateKey];

        if (stateValue > state2Value)
            while(attachedEffectStates[stateKey].Count != 0)
            {
                AttachedEffect effect = attachedEffectStates[stateKey].Dequeue();
                effect.endEffect(stateKey);
            }

        return stateValue > state2Value; //Because ties negate everything;
    }

    public void removeEffect(AttachedEffect attachedEffect)
    {
        foreach (var state in attachedEffect.getAppliedStates())
        {
            if(!attachedEffectStates.ContainsKey(state.Key) || attachedEffectStates[state.Key] == null || !attachedEffectStates[state.Key].Contains(attachedEffect))
                continue;
            attachedEffectStates[state.Key].Remove(attachedEffect);
        }
    }

    private void Update()
    {
        stateChanged = false;
    }
}
