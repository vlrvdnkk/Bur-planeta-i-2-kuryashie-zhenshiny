using UnityEngine;

public class CannonDragAndDrop: MonoBehaviour
{
    [SerializeField] private CannonRotation cannonRotation;
    [SerializeField] private CannonShooting cannonShooting;

    private bool isDragging = false;
    private Vector3 offset;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slot"))
        {
            SnapToSlot(other.transform.position);
            ActivateCannon();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slot"))
        {
            DeactivateCannon();
        }
    }

    private void SnapToSlot(Vector3 slotPosition)
    {
        transform.position = slotPosition;
    }

    private void ActivateCannon()
    {
        cannonRotation.enabled = true;
        cannonShooting.enabled = true;
    }

    private void DeactivateCannon()
    {
        cannonRotation.enabled = false;
        cannonShooting.enabled = false;
    }
}
