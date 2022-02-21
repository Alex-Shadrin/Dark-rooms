using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Flashlight : MonoBehaviour
{
    public KeyCode myKey = KeyCode.F;
    public AudioClip audioSource;

    void Update()
    {
        if (Input.GetKeyDown (myKey))
        {
            GetComponent<AudioSource>().PlayOneShot(audioSource);
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
    }
}
