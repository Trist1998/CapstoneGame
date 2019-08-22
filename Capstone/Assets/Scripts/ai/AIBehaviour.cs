using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehaviour
{
    public abstract bool checkCondition(AICharacter character);
    public abstract void update(AICharacter character);
}
