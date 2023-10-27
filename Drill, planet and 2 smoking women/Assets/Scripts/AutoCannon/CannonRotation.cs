using System.Collections;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f; // �������� �������� �����

    private float currentRotation = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        RotateCannon();
    }

    void RotateCannon()
    {
        // ������� ����� �� ������� � �������
        float rotationAmount = rotationSpeed * Time.deltaTime;

        if (rotatingRight)
        {
            currentRotation += rotationAmount;
            if (currentRotation >= 30.0f) // �������� ���� ������
            {
                rotatingRight = false;
            }
        }
        else
        {
            currentRotation -= rotationAmount;
            if (currentRotation <= -30.0f) // �������� ���� ������ � �������� �������
            {
                rotatingRight = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, currentRotation + 90f);
    }
}
