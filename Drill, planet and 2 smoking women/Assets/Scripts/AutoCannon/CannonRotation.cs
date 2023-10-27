using System.Collections;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f; // Скорость поворота пушки

    private float currentRotation = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        RotateCannon();
    }

    void RotateCannon()
    {
        // Поворот пушки из стороны в сторону
        float rotationAmount = rotationSpeed * Time.deltaTime;

        if (rotatingRight)
        {
            currentRotation += rotationAmount;
            if (currentRotation >= 30.0f) // Половина угла конуса
            {
                rotatingRight = false;
            }
        }
        else
        {
            currentRotation -= rotationAmount;
            if (currentRotation <= -30.0f) // Половина угла конуса в обратную сторону
            {
                rotatingRight = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, currentRotation + 90f);
    }
}
