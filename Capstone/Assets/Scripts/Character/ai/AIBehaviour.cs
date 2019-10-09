using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AIBehaviour
{
    protected AICharacter character;
    protected AIBehaviour[] behaviours;
    public AIBehaviour(AICharacter character)
    {
        this.character = character;
    }
    
    public AIBehaviour(AICharacter character, AIBehaviour[] behaviours)
    {
        this.character = character;
        this.behaviours = behaviours;
    }

    
    /*
     * Returns true if the behaviour is executable
     */
    protected virtual bool isExecutable()
    {
        return false;
    }
    
    /**
     * Returns the highest behaviour in the tree that is executable.
     */
    public AIBehaviour getBehaviourToExecute()
    {
        if (isExecutable())
            return this;
        if (behaviours == null) 
            return null;
        
        foreach (var behaviour in behaviours)
        {
            if (behaviour.isExecutable())
            {
                return behaviour;
            }
        }
        
        foreach (var behaviour in behaviours)
        {
            AIBehaviour b = behaviour.getBehaviourToExecute();
            if (b != null && !b.isLeaf())
            {
                return b;
            }
        }

        return null;
    }
    
    /**
     * Used to perform AI actions
     * Returns true if still executing
     */

    public virtual bool update()
    {
        bool running = false;
        foreach (var b in behaviours)
        {
            if(b.isLeaf())
                running = running || b.update();
        }

        return running;
    }

    public bool isLeaf()
    {
        return behaviours == null;
    }
    
}
