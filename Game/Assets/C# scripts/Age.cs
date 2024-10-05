using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Age : MonoBehaviour
{
  
    public Slider slider;
    public TextMeshProUGUI valueText;
    public Button playButton;

    void Start()
    {
        slider.minValue = 3;
        slider.maxValue = 90;

        slider.onValueChanged.AddListener(UpdateValueText);

        playButton.onClick.AddListener(OnPlayButtonClick);

        UpdateValueText(slider.value);
    }
    void UpdateValueText(float value)
    {
        valueText.text = value.ToString("0");
    }

    void OnPlayButtonClick()
    {
        float sliderValue = slider.value;

        if (sliderValue <= 10)
        {
            SceneManager.LoadScene("Childs");
        }
        else
        {
            SceneManager.LoadScene("Home");
        }
    }
}