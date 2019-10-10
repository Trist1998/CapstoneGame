using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacterInput : ScriptableObject
{
    /*
     * Input class for characters
     */
    public abstract float getHorizontalInput();
    public abstract float getVerticalInput();
    public abstract bool getJump();
    public abstract bool getJumpDown();
    public abstract float getCrouchAxis();
    public abstract float getMouseX();
    public abstract float getMouseY();
    public abstract bool getPrimaryFireDown();
    public abstract bool getPrimaryFireUp();
    public abstract bool getSecondaryFireDown();
    public abstract bool getSecondaryFireUp();
    public abstract bool getInteract();
    public abstract bool getDropPrimary();
    public abstract bool getPrevItem();
    public abstract bool getSprintDown();
    public abstract bool getNextItem();
    public abstract bool getReload();

}
