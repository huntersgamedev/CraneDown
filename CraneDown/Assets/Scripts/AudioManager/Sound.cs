using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]

public class Audio
{

    public string Name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3)]
    public float Pitch;
    [Range(0, 1)]
    public float Spatial;
    public bool Loop;

    [HideInInspector]
    public AudioSource source;


}