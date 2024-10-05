using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class MissionManager : MonoBehaviour
{
    public GameObject missionPanel; // Reference to the mission panel UI
    public Button goButton;         // Reference to the "Go" button
    public PlayerMovement playerMovement; // Reference to the player movement script

    private void Start()
    {
        // Initially show the mission panel and disable player movement
        missionPanel.SetActive(true);

        // Attach the OnGoButtonClicked method to the button's onClick event
        goButton.onClick.AddListener(OnGoButtonClicked);
    }

    private void OnGoButtonClicked()
    {

        // Hide the mission panel
        missionPanel.SetActive(false);

        // Enable player movement by calling the EnableMovement method in the PlayerMovement script
        playerMovement.EnableMovement();
    }
}