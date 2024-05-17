using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sloofbar : MonoBehaviour
{
    public Image filledImage;  // Reference to the filled Image component
    public float fillTime = 5f;  // Time in seconds to fill the image from 0 to 1
    public float drainTime = 3f;  // Time in seconds to drain the image from 1 to 0

    private float targetValue = 1f;  // Target value for the image fill amount to approach
    private float currentValue;  // Current fill amount of the image

    void Start()
    {
        if (filledImage == null)
        {
            Debug.LogError("Filled Image component not assigned.");
            this.enabled = false;  // Disable script if filled image not assigned
            return;
        }

        // Ensure the image type is set to Filled
        if (filledImage.type != Image.Type.Filled)
        {
            Debug.LogError("Image type is not set to Filled. Please set the image type to Filled in the inspector.");
            this.enabled = false;
            return;
        }

        currentValue = filledImage.fillAmount;
    }

    void Update()
    {
        // Update the fill amount towards the target value
        if (targetValue == 1f)
        {
            // Increase the fill amount over time
            currentValue += Time.deltaTime / fillTime;
        }
        else if (targetValue == 0f)
        {
            // Decrease the fill amount over time
            currentValue -= Time.deltaTime / drainTime;
        }

        // Clamp the currentValue to ensure it stays within bounds
        currentValue = Mathf.Clamp(currentValue, 0, 1);

        // Apply the clamped value to the filled image
        filledImage.fillAmount = currentValue;
    }

    // Call this method to start decreasing the fill amount
    public void StartDraining()
    {
        targetValue = 0f;
    }

    // Call this method to resume filling the fill amount
    public void StartFilling()
    {
        targetValue = 1f;
    }
}
