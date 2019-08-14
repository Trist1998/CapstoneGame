using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public class AttachedEffectManager : MonoBehaviour
{
    public const string STATE_WET = "WET";
    public const string STATE_FIRE = "FIRE";
    public static readonly string STATE_FUEL = "FUEL";
    
    private Dictionary<string, SimplePriorityQueue<AttachedEffect>> attachedEffectStates = new Dictionary<string, SimplePriorityQueue<AttachedEffect>>();

    public Dictionary<string, SimplePriorityQueue<AttachedEffect>> getAttachedStates()
    {
        return attachedEffectStates;
    }

    public void addState(string stateKey, AttachedEffect attachedEffect)
    {
        if(attachedEffectStates.ContainsKey(stateKey))
            attachedEffectStates[stateKey].Enqueue(attachedEffect, attachedEffect.getAppliedStates()[stateKey]);
    }

    public bool checkState(string stateKey, int stateValue)
    {
        if (!attachedEffectStates.ContainsKey(stateKey) || attachedEffectStates[stateKey].First == null)
            return true;
        
        int state2Value = attachedEffectStates[stateKey].First.getAppliedStates()[stateKey];

        if (stateValue > state2Value)
            while(attachedEffectStates[stateKey].Count != 0)
            {
                AttachedEffect effect = attachedEffectStates[stateKey].Dequeue();
                effect.endEffect(stateKey);
            }

        return stateValue > state2Value; //Because ties negate everything;
    }
}
