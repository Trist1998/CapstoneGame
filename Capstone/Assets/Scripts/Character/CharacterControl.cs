using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    public AbstractCharacterInput characterInput;
    public MovementControl movement;
    public InteractControl interact;

    void Start()
    {
        movement = GetComponent<MovementControl>();
        interact = GetComponent<InteractControl>();
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
