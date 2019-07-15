using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class AbstractCharacterInput : ScriptableObject
{
    public abstract float getHorizontalInput();
    public abstract float getVerticalInput();
    public abstract float getJumpInput();
    public abstract float getMouseX();
    public abstract float getMouseY();
}
