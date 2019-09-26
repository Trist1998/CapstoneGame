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

    protected bool isExecutable()
    {
        return false;
    }
    
    public AIBehaviour getBehaviourToExecute()
    {
        if (isExecutable())
            return this;
        bool flag = false;
        if(behaviours != null)
            foreach (var behaviour in behaviours)
            {
                AIBehaviour b = behaviour.getBehaviourToExecute();
                if(b != null && !b.isLeaf());
            }
    }

    public virtual bool update()
    {
        bool finished = true;
        foreach (var b in behaviours)
        {
            if(b.isLeaf())
                finished = finished && b.update();
        }

        return finished;
    }

    public bool isLeaf()
    {
        return behaviours == null;
    }
    
}
