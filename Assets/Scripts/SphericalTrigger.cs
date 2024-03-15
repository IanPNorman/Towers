using UnityEngine;

public class SphericalTrigger : MonoBehaviour
{
    public float radius = 1f; // Radius of the trigger sphere
    public LayerMask targetLayers; // Layers of objects that trigger the event
    private ItemCountDisplay itemCountDisplay; // Reference to itemCountDisplay
    private BoxResources boxResource; // Reference to boxResource

    private void Start()
    {
        // Get the ItemCountDisplay and boxResource script components
        itemCountDisplay = FindObjectOfType<ItemCountDisplay>();
        boxResource = FindObjectOfType<BoxResources>();

        if (itemCountDisplay == null)
        {
            Debug.LogWarning("ItemCountDisplay script not found in the scene.");
        }

        if(boxResource == null)
        {
            Debug.LogWarning("boxResource script not found in the scene.");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & targetLayers) != 0)
        {
            // Check if the object has a Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Check if the object's position is within the trigger sphere
                Vector3 offset = other.transform.position - transform.position;
                if (offset.magnitude < radius)
                {
                    Debug.Log(other.name + " entered the trigger sphere.");

                    if(itemCountDisplay != null)
                    {
                        itemCountDisplay.incrementItemCount();
                    }
                    if(boxResource != null)
                    {
                        boxResource.StoreItem(other.gameObject); 
                    }            
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw wireframe representation of the trigger sphere in editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
