using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 120f; // 2 minutes in seconds
    public TextMeshProUGUI timerText;  // Use TextMeshProUGUI for UI text
    private float currentTime;
    private bool isPaused = false;

    void Start()
    {
        currentTime = totalTime;
        Time.timeScale = 1f; // Ensure game runs normally at start
    }

    void Update()
    {
        if (!isPaused)
        {
            currentTime -= Time.deltaTime;

            // Update UI
            DisplayTime(currentTime);

            // Check if time is up
            if (currentTime <= 0)
            {
                PauseGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Freeze game
        isPaused = true;
    }

    public void ResumeGame()
    {
        currentTime = totalTime; // Reset timer if necessary
        Time.timeScale = 1f;     // Unfreeze game
        isPaused = false;
    }
}