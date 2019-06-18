using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    public MovementControl movement;
    public InteractControl interact;
    public Camera cam;

    void Start()
    {
        movement = new MovementControl(this.gameObject, cam);
        interact = new InteractControl(this.gameObject, cam);
    }

    void Update()
    {
        movement.control();
        interact.control();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }
}
