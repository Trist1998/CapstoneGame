using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //Array of sounds

    public static AudioManager instance; //Refers to an instance of the game object

    //This method adds all the sounds that was loaded onto the audio manager in the inspector into an array
    // The if else block ensures that there aren't multiple instances of the audio manager object when a new scene is loaded
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;

        }
    }

    //Searches the array of sounds for a given name and plays it if found
    public void play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("No sound found");
        }
        else
        {
            s.source.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        play("Theme"); //Our main game music can be played her if applicable
    }

    
}
