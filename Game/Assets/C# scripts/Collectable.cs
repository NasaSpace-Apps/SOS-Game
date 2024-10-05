using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public Image progressBar;  // Reference to the UI Image that represents the progress bar
    private int totalCollectibles;  // Total number of collectible objects in the scene
    private int collectedCount = 0;  // Number of objects collected by the player

    private void Start()
    {
        // Find all collectible objects and count them
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        // Ensure the progress bar is initially empty
        UpdateProgressBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as "Collectible"
        if (other.CompareTag("Collectible"))
        {
            // Increment the collected count
            collectedCount++;
            // Update the progress bar
            UpdateProgressBar();
            // Optionally, destroy the collected object
            Destroy(other.gameObject);
        }
    }

    private void UpdateProgressBar()
    {
        // Calculate the fill amount as a percentage of collected objects
        float fillAmount = (float)collectedCount / totalCollectibles;
        // Update the progress bar's fill amount
        progressBar.fillAmount = fillAmount;
    }
}
