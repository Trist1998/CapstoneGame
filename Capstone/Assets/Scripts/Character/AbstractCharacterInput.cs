using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacterInput : ScriptableObject
{
    public abstract float getHorizontalInput();
    public abstract float getVerticalInput();
    public abstract bool getJumpInput();
    public abstract float getMouseX();
    public abstract float getMouseY();
    public abstract bool getPrimaryFireDown();
    public abstract bool getPrimaryFireUp();
    public abstract bool getSecondaryFireDown();
    public abstract bool getSecondaryFireUp();
    public abstract bool getInteract();
    public abstract bool getDropPrimary();
    public abstract bool getSwapPrimary();

}
