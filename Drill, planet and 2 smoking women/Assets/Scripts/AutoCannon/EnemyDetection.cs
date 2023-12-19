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
        // Определяем направление, в котором направлен треугольник
        Vector3 forwardDirection = transform.forward;

        // Определяем левое и правое направление треугольника
        Vector3 leftDirection = Quaternion.AngleAxis(-detectionAngle / 2, Vector3.up) * forwardDirection;
        Vector3 rightDirection = Quaternion.AngleAxis(detectionAngle / 2, Vector3.up) * forwardDirection;
        Debug.DrawRay(transform.position, leftDirection * detectionRange, Color.green);
        Debug.DrawRay(transform.position, rightDirection * detectionRange, Color.blue);
        Debug.DrawRay(transform.position, forwardDirection * detectionRange, Color.red);

        // Пускаем лучи в направлениях треугольника
        RaycastHit hit;

        // Левый луч
        if (Physics.Raycast(transform.position, leftDirection, out hit, detectionRange) && hit.collider.CompareTag("Enemy"))
        {
            HandleDetection(hit.collider.gameObject);
            Debug.DrawRay(transform.position, leftDirection * detectionRange, Color.green);
        }

        // Правый луч
        if (Physics.Raycast(transform.position, rightDirection, out hit, detectionRange) && hit.collider.CompareTag("Enemy"))
        {
            HandleDetection(hit.collider.gameObject);
            Debug.DrawRay(transform.position, rightDirection * detectionRange, Color.blue);
        }

        // Центральный луч
        if (Physics.Raycast(transform.position, forwardDirection, out hit, detectionRange) && hit.collider.CompareTag("Enemy"))
        {
            HandleDetection(hit.collider.gameObject);
            Debug.DrawRay(transform.position, forwardDirection * detectionRange, Color.red);
        }
    }

    void HandleDetection(GameObject enemy)
    {
        // Ваш код для обработки обнаружения врага
        Debug.Log("Враг обнаружен: " + enemy.name);
    }
}