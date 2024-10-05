using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<SliderController>().ObjectCollected();
            Destroy(gameObject);
        }
    }
}
