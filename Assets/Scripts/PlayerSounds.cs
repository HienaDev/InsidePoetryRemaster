using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] teleport;
    private AudioSource audioSourceTeleport;
    [SerializeField] private AudioMixerGroup teleportMixer;

    [SerializeField] private AudioClip[] walk;
    private AudioSource audioSourceWalk;
    [SerializeField] private AudioMixerGroup walkMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceTeleport = gameObject.AddComponent<AudioSource>();
        audioSourceTeleport.outputAudioMixerGroup = teleportMixer;

        audioSourceWalk = gameObject.AddComponent<AudioSource>();
        audioSourceWalk.outputAudioMixerGroup = walkMixer;
    }

    public void PlayTeleportSound()
    {
        audioSourceTeleport.clip = teleport[Random.Range(0, teleport.Length)];

        audioSourceTeleport.pitch = Random.Range(0.90f, 1.10f);

        audioSourceTeleport.Play();
    }

    public void PlayWalkSound()
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity.y);
        if (GetComponent<Rigidbody2D>().velocity.y < 0.1 && GetComponent<Rigidbody2D>().velocity.y > -0.1)
        {
            audioSourceWalk.clip = walk[Random.Range(0, walk.Length)];

            audioSourceWalk.pitch = Random.Range(0.90f, 1.10f);

            audioSourceWalk.Play();
        }
    }
}
