using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource source;
    [SerializeField] List<AudioClip> music = new List<AudioClip>();
    int currentTrack = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            if (currentTrack >= music.Count - 1)
            {
                currentTrack = 0;
            }
            else
            {
                ++currentTrack;
            }
            source.clip = music[currentTrack];
            source.Play();
        }
    }
}
