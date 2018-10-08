using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Audio[] sounds;


    private void Awake()
    {
        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.spatialBlend = s.Spatial;
            s.source.loop = s.Loop;

        }
    }

    private void Start()
    {

    }
    public void Play(string name)
    {
        Audio s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.Log("sound of the name" + name + "could not be found");
            return;
        }
        if (s.source.isPlaying == false)
        {
            s.source.Play();
        }

    }

    public void Stop(string name)
    {
        Audio s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.Log("sound of the name" + name + "could not be found");
            return;
        }
        s.source.Stop();
    }
}
