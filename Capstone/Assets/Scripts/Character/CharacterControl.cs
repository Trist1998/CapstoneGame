using UnityEngine;
using System.Collections;

public class CharacterControl : AbstractCharacterControl
{
    public AbstractCharacterInput characterInput;
    public FPSMovementControl movement;
    public InteractControl interactControl;
    public Camera playerCamera;

    void Start()
    {
        movement = GetComponent<FPSMovementControl>();
        movement?.setValues(playerCamera, characterInput);
        interactControl = GetComponent<InteractControl>();
        interactControl?.setValues(playerCamera, characterInput);
    }
    
}
