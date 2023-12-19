using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRange = 10f;
    public float detectionAngle = 45f;

    // Update is called once per frame
    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()
    {
        // ���������� �����������, � ������� ��������� �����������
        Vector3 forwardDirection = transform.forward;

        // ���������� ����� � ������ ����������� ������������
        Vector3 leftDirection = Quaternion.AngleAxis(-detectionAngle / 2, Vector3.up) * forwardDirection;
        Vector3 rightDirection = Quaternion.AngleAxis(detectionAngle / 2, Vector3.up) * forwardDirection;
        Debug.DrawRay(transform.position, leftDirection * detectionRange, Color.green);
        Debug.DrawRay(transform.position, rightDirection * detectionRange, Color.blue);
        Debug.DrawRay(transform.position, forwardDirection * detectionRange, Color.red);

        // ������� ���� � ������������ ������������
        RaycastHit hit;

        // ����� ���
        if (Physics.Raycast(transform.position, leftDirection, out hit, detectionRange) && hit.collider.CompareTag("Enemy"))
        {
            HandleDetection(hit.collider.gameObject);
            Debug.DrawRay(transform.position, leftDirection * detectionRange, Color.green);
        }

        // ������ ���
        if (Physics.Raycast(transform.position, rightDirection, out hit, detectionRange) && hit.collider.CompareTag("Enemy"))
        {
            HandleDetection(hit.collider.gameObject);
            Debug.DrawRay(transform.position, rightDirection * detectionRange, Color.blue);
        }

        // ����������� ���
        if (Physics.Raycast(transform.position, forwardDirection, out hit, detectionRange) && hit.collider.CompareTag("Enemy"))
        {
            HandleDetection(hit.collider.gameObject);
            Debug.DrawRay(transform.position, forwardDirection * detectionRange, Color.red);
        }
    }

    void HandleDetection(GameObject enemy)
    {
        // ��� ��� ��� ��������� ����������� �����
        Debug.Log("���� ���������: " + enemy.name);
    }
}