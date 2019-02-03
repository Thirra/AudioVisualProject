using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnPress : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip note;

    public void PlayKey()
    {
        audioSource.PlayOneShot(note);
    }
}
