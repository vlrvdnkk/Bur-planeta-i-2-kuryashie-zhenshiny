using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float a = 1f; // Полуось по горизонтали (мажорная полуось)
    [SerializeField] private float b = 3f; // Полуось по вертикали (минорная полуось);
    [SerializeField] private float maxRotationSpeed = 575f; // Максимальная скорость вращения

    private Vector3 targetPosition;
    private float currentAngle;

    void Update()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(worldPos.x, worldPos.y, 10f)); // Поднимаем Z, чтобы объект находился перед плоскостью

        // Находим ближайшую точку на границе эллипса к позиции курсора
        Vector3 nearestPoint = FindNearestPointOnEllipse(worldPos);

        // Поворачиваем объект так, чтобы он смотрел на позицию курсора
        Vector3 lookPos = worldPos - nearestPoint;
        float targetAngle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg - 90f; // Вычитаем 90 градусов, чтобы смотреть прямо
        currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, maxRotationSpeed * Time.deltaTime);

        // Устанавливаем новую позицию и вращение объекта
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

