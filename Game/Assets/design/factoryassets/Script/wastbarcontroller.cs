using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public int totalObjects;
    private int objectsCollected = 0;

    void Start()
    {
        // Initialize slider
        slider.maxValue = totalObjects;
        slider.value = 0;
        UpdateSliderColor();
    }

    public void ObjectCollected()
    {
        objectsCollected++;
        slider.value = objectsCollected;
        UpdateSliderColor();

        if (objectsCollected >= totalObjects)
        {
            Debug.Log("All objects collected! Moving to Level 2.");
            // Code to move to level 2
        }
    }

    private void UpdateSliderColor()
    {
        ColorBlock cb = slider.colors;
        cb.disabledColor = Color.Lerp(Color.red, Color.green, slider.value / slider.maxValue);
        slider.colors = cb;
    }
}
