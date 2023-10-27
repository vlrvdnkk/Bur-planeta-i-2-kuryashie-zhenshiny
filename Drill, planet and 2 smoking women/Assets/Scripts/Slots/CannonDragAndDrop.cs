using UnityEngine;

public class CannonDragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Transform slot = null;

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (slot != null)
        {
            transform.position = slot.position;
            // Активируйте пушку, так как она прикреплена к ячейке.
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slot"))
        {
            slot = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slot"))
        {
            slot = null;
            // Деактивируйте пушку, так как она откреплена от ячейки.
        }
    }
}