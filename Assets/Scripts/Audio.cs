using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Audio : MonoBehaviour
{
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip wall;
    public AudioClip wind;

    private AudioSource _audioSource;
    private Input _input;
    private jumpKing2 _movement;
    private Dash _dash;

    private bool _canLand;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _input = GetComponent<Input>();
        _movement = GetComponent<jumpKing2>();
    }

    private void Update()
    {
        LandingAudio();
    }

    public void WalkingAudio()
    {
        _audioSource.PlayOneShot(walk);
    }

    private void JumpAudio()
    {
        _audioSource.pitch = Random.Range(0.5f, 1.5f);
        _audioSource.PlayOneShot(jump);
    }

    private void LandingAudio()
    {
        if (_movement.isGrounded && _canLand)
        {
            _audioSource.pitch = Random.Range(0.5f, 1.5f);
            _audioSource.PlayOneShot(land);
            _canLand = false;
            PlayerParticles.CreateDust();
        }
        else if (!_movement.isGrounded)
        {
            _canLand = true;
        }
    }
    
    private void WindAudio()
    {
        _audioSource.PlayOneShot(wind);
    }
    
    private void AudioShowCase(AudioClip audioClip)
    {
        _audioSource.Play(); // Play the Audio Clip attached to the AudioSource component
            _audioSource.clip = audioClip; // Set the attached audioclip to a different clip
        _audioSource.Pause(); // Pause the AudioClip being played (Only affects the clip attached to the audiosource)
        
        _audioSource.Stop(); // Stop the AudiClip being played  (Only affects the clip attached to the audiosource)

        _audioSource.PlayOneShot(audioClip); // Play an independent AudioClip using the AudioSource.
    }
}