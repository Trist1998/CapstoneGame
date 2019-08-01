using UnityEngine;
using System.Collections;

public class CharacterControl : AbstractCharacterControl
{
    public AbstractCharacterInput characterInput;
    public FPSMovementControl movement;
    public InteractControl interact;
    public Camera playerCamera;

    void Start()
    {
        movement = GetComponent<FPSMovementControl>();
        movement?.setValues(playerCamera, characterInput);
        interact = GetComponent<InteractControl>();
        interact?.setValues(playerCamera, characterInput);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }
}
