using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionTransition : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load

    // This function will be called when the player collides with the image
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with this is the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

