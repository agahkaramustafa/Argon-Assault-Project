using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("The speed of player movement on horizontal axis")] [SerializeField] float xPower = 30f;
    [Tooltip("The speed of player movement on vertical axis")] [SerializeField] float yPower = 35f;
    [Tooltip("Determine the constraints of player movement on horizontal axis")] [SerializeField] float xRange = 10f;
    [Tooltip("Determine the constraints of player movement on vertical axis")] [SerializeField] float yRange = 6f;
    AudioSource audioSource;

    [Header("Laser Gun Array")]
    [Tooltip("Add all the lasers here")] [SerializeField] GameObject[] lasers;

    [Header("Screen Position Based Tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2.5f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -15f;


    float horizontalInput;
    float verticalInput;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessShooting();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalInput * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = horizontalInput * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float xValue = horizontalInput * Time.deltaTime * xPower;
        float newXPos = transform.localPosition.x + xValue;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yValue = verticalInput * Time.deltaTime * yPower;
        float newYPos = transform.localPosition.y + yValue;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessShooting()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
