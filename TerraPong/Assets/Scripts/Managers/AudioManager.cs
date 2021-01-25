using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Audio that will be played when the ball hits something")]
    public AudioSource sound;

    public void PlayBallSound()
    {
        sound.Play();
    }
}
