using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioClip menu;
    public AudioClip normal;
    private bool menuPlaying;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = menu;
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = normal;
            audioSource.Play();
        }

    }
}
