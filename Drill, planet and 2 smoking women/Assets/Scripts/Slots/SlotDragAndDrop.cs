using UnityEngine;

public class SlotDragAndDrop : MonoBehaviour
{
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tr ent sl");
            cannonDragAndDrop.isOverSlot = true;
            cannonDragAndDrop.UpdateCurrentSlot(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tr ex sl");
            cannonDragAndDrop.isOverSlot = false;
            cannonDragAndDrop.UpdateCurrentSlot(null);
        }
    }
}
