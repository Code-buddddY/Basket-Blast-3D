using UnityEngine;
using UnityEngine.UI;

public class UIForceControl : MonoBehaviour
{
    public Slider throwForceSlider;         // Reference to the UI slider controlling throw force
    public float scrollSensitivity = 1f;    // Multiplier for mouse scroll input sensitivity

    // Static property to allow other scripts to get the current throw force value
    public static float CurrentThrowForce { get; private set; }

    void Start()
    {
        // Initialize the current throw force based on the slider's initial value, if assigned
        if (throwForceSlider != null)
            CurrentThrowForce = throwForceSlider.value;
    }

    void Update()
    {
        if (throwForceSlider != null)
        {
            // Get mouse scroll wheel input (positive or negative float)
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            // If there is scroll input, adjust the slider's value accordingly
            if (scroll != 0f)
            {
                // Add scroll input multiplied by sensitivity to slider value,
                // then clamp it between slider's min and max values to prevent overflow
                throwForceSlider.value = Mathf.Clamp(
                    throwForceSlider.value + scroll * scrollSensitivity,
                    throwForceSlider.minValue,
                    throwForceSlider.maxValue
                );
            }

            // Update the static CurrentThrowForce property to reflect the slider's current value
            CurrentThrowForce = throwForceSlider.value;
        }
    }
}
