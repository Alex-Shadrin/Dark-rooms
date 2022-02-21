using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public AudioClip[] snow_sounds;
    public AudioClip[] metall_sounds;
    private Transform ray_point;
    public Transform foot_L_point;
    public Transform foot_R_point;
    public LayerMask layerMask;
    private int random_audio_clip;
    private int previous_audio_clip;
    private float ray_dist = 1.2f;
    private AudioClip[] current_step_sounds;
    private AudioSource audioSource;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        current_step_sounds = snow_sounds;
    }
    public void Step_sound_play(int leg_ID)
    {
        if (leg_ID == 0) ray_point = foot_L_point;
        else ray_point = foot_R_point;
        if(Physics.Raycast (ray_point.position, -Vector3.up, out hit, ray_dist, layerMask))
        {
            if (hit.collider.tag == "Snow") current_step_sounds = snow_sounds;
            else if (hit.collider.tag == "Metall") current_step_sounds = metall_sounds;
        }
        random_audio_clip = Random.Range(0, current_step_sounds.Length);
        if (random_audio_clip == previous_audio_clip) random_audio_clip = random_audio_clip + 1;
        if (random_audio_clip == current_step_sounds.Length) random_audio_clip = 0;
        previous_audio_clip = random_audio_clip;
        audioSource.PlayOneShot(current_step_sounds[random_audio_clip]);
    }
}
