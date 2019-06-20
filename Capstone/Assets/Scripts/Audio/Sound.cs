using UnityEngine.Audio;

using UnityEngine;

[System.Serializable]
public class Sound 
{
    public AudioClip clip; // This is the variable that holds the audio file
    public string name; // This is the name we use to find this object by
    [Range(0f, 1f)]  // A slider for the volume
    public float volume; 
    [Range(.1f,3f)] // A slider for the pitch
    public float pitch;
    public bool loop; // True if the sound has to loop otherwise false

    [HideInInspector]
    public AudioSource source; // Where audio is played from
}
