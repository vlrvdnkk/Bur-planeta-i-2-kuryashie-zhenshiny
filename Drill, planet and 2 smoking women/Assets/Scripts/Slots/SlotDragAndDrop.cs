using UnityEngine;

public class SlotDragAndDrop : MonoBehaviour
{
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tr sl ent");
            cannonDragAndDrop.isOverSlot = true;
            cannonDragAndDrop.UpdateCurrentSlot(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tr sl ex");
            cannonDragAndDrop.isOverSlot = false;
            cannonDragAndDrop.UpdateCurrentSlot(null);
        }
    }
}
