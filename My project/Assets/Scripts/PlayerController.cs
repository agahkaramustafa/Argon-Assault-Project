using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xPower = 30f;
    [SerializeField] float yPower = 35f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 6f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2.5f;
    [SerializeField] float controlRollFactor = -15f;
    [SerializeField] GameObject[] lasers;

    float horizontalInput;
    float verticalInput;

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
