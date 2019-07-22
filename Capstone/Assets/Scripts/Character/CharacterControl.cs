using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    public AbstractCharacterInput characterInput;
    public MovementControl movement;
    public InteractControl interact;
    public Camera playerCamera;

    void Start()
    {
        movement = GetComponent<MovementControl>();
        movement?.setValues(playerCamera, characterInput);
        interact = GetComponent<InteractControl>();
        interact?.setValues(playerCamera, characterInput);
    }
    void Update()
    {
        if (!PauseMenu.paused)
        {
            movement.control();
            interact.control();
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }
}
