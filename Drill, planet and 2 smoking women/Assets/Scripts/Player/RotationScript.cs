using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float a = 1f; // ������� �� ����������� (�������� �������)
    [SerializeField] private float b = 3f; // ������� �� ��������� (�������� �������);
    [SerializeField] private float maxRotationSpeed = 575f; // ������������ �������� ��������

    private Vector3 targetPosition;
    private float currentAngle;

    void Update()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(worldPos.x, worldPos.y, 10f)); // ��������� Z, ����� ������ ��������� ����� ����������

        // ������� ��������� ����� �� ������� ������� � ������� �������
        Vector3 nearestPoint = FindNearestPointOnEllipse(worldPos);

        // ������������ ������ ���, ����� �� ������� �� ������� �������
        Vector3 lookPos = worldPos - nearestPoint;
        float targetAngle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg - 90f; // �������� 90 ��������, ����� �������� �����
        currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, maxRotationSpeed * Time.deltaTime);

        // ������������� ����� ������� � �������� �������
        transform.position = nearestPoint;
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }

    Vector3 FindNearestPointOnEllipse(Vector3 target)
    {
        float angle = Mathf.Atan2(target.y, target.x);
        float x = a * Mathf.Cos(angle);
        float y = b * Mathf.Sin(angle);
        return new Vector3(x, y, transform.position.z);
    }
}

