using UnityEngine;

public class CannonDragAndDrop : MonoBehaviour
{
    [SerializeField] private CannonRotation cannonRotation;
    [SerializeField] private CannonShooting cannonShooting;

    public bool Xmore = false;
    public bool IsOverSlot;
    private bool isDragging = false;
    private Vector3 offsetMouse;
    private SlotDragAndDrop lastSlot;
    private SlotDragAndDrop currentSlot;


    public void MouseDown()
    {
        isDragging = true;
        DeactivateCannon();
        offsetMouse = transform.position - GetMouseWorldPos();
    }

    public void MouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPos() + offsetMouse;
            if (newPosition.x > 0 && !Xmore)
            {
                transform.Rotate(Vector3.forward, 180f);
                Xmore = true;
            }
            else if (newPosition.x < 0 && Xmore)
            {
                transform.Rotate(Vector3.forward, 180f);
                Xmore = false;
            }
            transform.position = newPosition;
        }
    }

    public void MouseUp()
    {
        isDragging = false;
        if (currentSlot != null)
        {
            transform.position = currentSlot.transform.position + new Vector3(0, 0, -0.01f);
            lastSlot = currentSlot;
        }
        else
        {
            transform.position = lastSlot.transform.position + new Vector3(0, 0, -0.01f);
            Vector3 newPosition = GetMouseWorldPos() + offsetMouse;
            if (lastSlot.transform.position.x < 0 && newPosition.x > 0)
            {
                transform.Rotate(Vector3.forward, 180f);
                Xmore = false;
            }
            else if (lastSlot.transform.position.x > 0 && newPosition.x < 0)
            {
                transform.Rotate(Vector3.forward, 180f);
                Xmore = true;
            }
        }
        ActivateCannon();
    }

    public void UpdateCurrentSlot(SlotDragAndDrop slot)
    {
        currentSlot = slot;
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

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
