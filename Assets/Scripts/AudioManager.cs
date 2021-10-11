using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{  
    public Sound[] sounds; // det här är en lista som ska inehålla ljudfiler från det andra scriptet som heter sound, Johan.

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name) // Denna funktion är gjord så att när man kallar det så skriver man namnet på ljudfilen i arrayn som finns i detta skript nså spelas det ljudet, Johan.
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

}
