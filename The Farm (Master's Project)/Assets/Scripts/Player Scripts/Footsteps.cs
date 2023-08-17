using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepSoundsOutdoor;
    public AudioClip[] footstepSoundsIndoor;
    public float footstepInterval = 0.5f;
    private float footstepTimer = 0f;
    private bool isMoving = false;
    public bool isWood = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Assuming you have some way to detect player movement.
        // For example, you could use Unity's Input.GetAxis() for input.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        if (isMoving)
        {
            footstepTimer += Time.deltaTime;
            if (footstepTimer >= footstepInterval)
            {
                PlayFootstepSound();
                footstepTimer = 0f;
            }
        }
    }

    private void PlayFootstepSound()
    {
        if (isWood == false & footstepSoundsOutdoor.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSoundsOutdoor.Length);
            audioSource.PlayOneShot(footstepSoundsOutdoor[randomIndex]);
        }

        else if (isWood == true & footstepSoundsIndoor.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSoundsIndoor.Length);
            audioSource.PlayOneShot(footstepSoundsIndoor[randomIndex]);
        }
    }
}
