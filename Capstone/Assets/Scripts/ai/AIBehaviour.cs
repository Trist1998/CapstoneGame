using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehaviour
{
    protected AICharacter character;

    public AIBehaviour(AICharacter character)
    {
        this.character = character;
    }
    
    public abstract bool checkConditionAndUpdate();
    protected abstract void update(AICharacter character);
}
