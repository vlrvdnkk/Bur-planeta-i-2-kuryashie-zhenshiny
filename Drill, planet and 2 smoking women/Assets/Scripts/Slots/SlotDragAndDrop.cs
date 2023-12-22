using UnityEngine;

public class SlotDragAndDrop : MonoBehaviour
{
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cannonDragAndDrop.IsOverSlot = true;
            cannonDragAndDrop.UpdateCurrentSlot(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cannonDragAndDrop.IsOverSlot = false;
            cannonDragAndDrop.UpdateCurrentSlot(null);
        }
    }
}
