using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;
    [SerializeField] private int numberOfRays = 20;
    private float detectionRange = 10f;
    private float detectionAngle = 45f;
    private Vector2 forwardDirection;
    private Vector2 offset;
    private LayerMask enemyLayer;
    private LayerMask slotLayer;
    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()
    {
        if (cannonDragAndDrop.Xmore)
        {
            offset = new Vector2(0.205f, 0f);
        }
        else
            offset = new Vector2(-0.205f, 0f);
        Vector2 startPosition = (Vector2)transform.position + offset;

        forwardDirection = transform.up;

        float angleBetweenRays = detectionAngle / (numberOfRays - 1);

        for (int i = 0; i < numberOfRays; i++)
        {
            float currentAngle = -detectionAngle / 2 + i * angleBetweenRays;

            Vector2 rayDirection = Quaternion.Euler(0, 0, currentAngle) * forwardDirection;

            RaycastHit2D hit = Physics2D.Raycast(startPosition, rayDirection, detectionRange);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject);
                HandleDetection();
                Debug.DrawRay(startPosition, rayDirection * detectionRange, Color.red);
            }
            else
            {
                Debug.DrawRay(startPosition, rayDirection * detectionRange, Color.green);
            }
        }
    }

    void HandleDetection()
    {
        Debug.Log("Враг обнаружен");

        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            Debug.Log("Ближайший враг: " + closestEnemy.name);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        return closestEnemy;
    }
}