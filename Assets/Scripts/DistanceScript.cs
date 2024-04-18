using UnityEngine;

public class ArtInfoTrigger : MonoBehaviour
{
    public float triggerDistance = 2f; // Distance at which the art info is triggered
    public LayerMask artLayer; // Layer containing the art objects
    public GameObject artInfoDisplay; // GameObject to display art info

    private GameObject currentArt; // Reference to the current art object

    void Update()
    {
        // Cast a ray forward to detect art objects
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, triggerDistance, artLayer))
        {
            // Check if the hit object is different from the current art object
            if (hit.collider.gameObject != currentArt)
            {
                // Display art info
                DisplayArtInfo(hit.collider.gameObject);
                currentArt = hit.collider.gameObject;
            }
        }
        else
        {
            // Hide art info if no art object is in range
            HideArtInfo();
            currentArt = null;
        }
    }

    void DisplayArtInfo(GameObject artObject)
    {
        // Activate the art info display and position it beside the art object
        artInfoDisplay.SetActive(true);
        artInfoDisplay.transform.position = artObject.transform.position + artObject.transform.right * 1.5f; // Adjust the position as needed
        // You might want to set the art info text here based on the specific art object
    }

    void HideArtInfo()
    {
        // Deactivate the art info display
        artInfoDisplay.SetActive(false);
    }
}
