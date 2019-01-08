using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitSound : MonoBehaviour {

    public AudioSource source;
    public AudioClip clip;

	public void playSound()
    {
        source.clip = clip;
        source.Play();
    }
}
