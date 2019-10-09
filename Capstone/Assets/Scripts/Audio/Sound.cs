using UnityEngine.Audio;

using UnityEngine;

[System.Serializable]
public class Sound 
{
    public AudioClip clip; // This is the variable that holds the audio file
    public string name; // This is the name we use to find this object by
    [Range(0f, 5f)]  // A slider for the volume
    public float volume; 
    [Range(.1f,3f)] // A slider for the pitch
    public float pitch;
    public bool loop; // True if the sound has to loop otherwise false
    [Range(0f,1f)] 
    public float spatialBlend = 1.0f;

    public float length;
    [HideInInspector]
    public AudioSource source;// Where audio is played from

    /*
     * Plays the sound at the given position
     */
    public GameObject playSound(Vector3 pos)
    {
        if (clip == null) return null;
        GameObject g = new GameObject();
        g = MonoBehaviour.Instantiate(g, pos, Quaternion.identity);
        AudioSource newSource = g.AddComponent<AudioSource>();
        newSource.clip = clip;
        newSource.volume = volume;
        newSource.pitch = pitch;
        newSource.loop = loop;
        newSource.Play();
        newSource.spatialBlend = spatialBlend;
        newSource.rolloffMode = AudioRolloffMode.Logarithmic;
        newSource.maxDistance = 200.0f;
        newSource.minDistance = 1.0f;
        if(!loop && length <= 0)
            MonoBehaviour.Destroy(g, clip.length);
        else if(!loop && length > 0)
            MonoBehaviour.Destroy(g, length);
        return g;
    }
}
