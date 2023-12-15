using System.Collections;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f; // �������� �������� �����
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;

    private float currentRotation = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        RotateCannon(cannonDragAndDrop.Xmore);
    }

    void RotateCannon(bool x)
    {
        if (x)
        {
            // ������� ����� �� ������� � �������
            float rotationAmount = rotationSpeed * Time.deltaTime;
            if (rotatingRight)
            {
                currentRotation += rotationAmount;
                if (currentRotation >= 30.0f + 180f) // �������� ���� ������
                {
                    rotatingRight = false;
                }
            }
            else
            {
                currentRotation -= rotationAmount;
                if (currentRotation <= -30.0f + 180f) // �������� ���� ������ � �������� �������
                {
                    rotatingRight = true;
                }
            }

            transform.rotation = Quaternion.Euler(0, 0, currentRotation + 90f);
        }
        else
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
}