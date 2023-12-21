using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public GameObject panelToDisplay;
    private bool panelActive = false;
    void Start()
    {
        panelToDisplay.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") && !panelActive)
        {
            // Display the panel when the projectile enters the trigger zone
            panelToDisplay.SetActive(true);
            panelActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            // Deactivate the panel when the projectile exits the trigger zone
            panelToDisplay.SetActive(false);
            panelActive = false;
        }
    }
}
