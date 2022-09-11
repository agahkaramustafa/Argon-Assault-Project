using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xPower = 10f;
    [SerializeField] float yPower = 10f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float xValue = horizontalInput * Time.deltaTime * xPower;
        float newXPos = transform.localPosition.x + xValue;

        float yValue = verticalInput * Time.deltaTime * yPower;
        float newYPos = transform.localPosition.y + yValue;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
