using UnityEngine;

public class CannonDragAndDrop : MonoBehaviour
{
    [SerializeField] private CannonRotation cannonRotation;
    [SerializeField] private CannonShooting cannonShooting;

    public bool Xmore = false;
    public bool isOverSlot;
    private bool isDragging = false;
    private Vector3 initialPosition;
    private Vector3 offset;
    private SlotDragAndDrop lastSlot; // ����� ���������� ��� �������� ���������� �����

    // ����� ���������� ��� �������� �������� �����
    private SlotDragAndDrop currentSlot;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
        DeactivateCannon();
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPos() + offset;
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

    void OnMouseUp()
    {
        isDragging = false;
        Debug.Log(currentSlot);
        Debug.Log(lastSlot);
        // ���������, ���� �� ������� ����
        if (currentSlot != null)
        {
            // ���� ����, ������������ � ��� �������
            transform.position = currentSlot.transform.position;
            lastSlot = currentSlot; // ��������� ������� ���� ��� ��������� ����
        }
        else if (lastSlot != null)
        {
            // ���� ��� �������� �����, �� ���� ��������� ����, ������������ � ��� �������
            transform.position = lastSlot.transform.position;
        }

        ActivateCannon();
    }

    // ����� ��� ���������� �������� �����
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

    private void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
