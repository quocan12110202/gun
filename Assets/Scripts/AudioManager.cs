using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
    public AudioSource BGSource;
    public AudioSource sfxSource;
    public AudioClip shootClip;
    public AudioClip deadClip;
    public AudioClip BGClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Nhacnen();
    }
    void Nhacnen()
    {
        BGSource.clip = BGClip;
        BGSource.Play();
    }
    public void PlayShootClip()
    {
        sfxSource.PlayOneShot(shootClip);
    }
    public void PlayDeadClip()
    {
        sfxSource.PlayOneShot(deadClip);
    }

}
