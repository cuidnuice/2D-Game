using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    public static AudioManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Sound(AudioClip audioClip)
    {
        effectSource.PlayOneShot(audioClip);
    }
}
