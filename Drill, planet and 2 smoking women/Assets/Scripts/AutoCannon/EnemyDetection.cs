using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;
    [SerializeField] private CannonRotation cannonRotation;
    [SerializeField] private CannonShooting cannonShooting;
    [SerializeField] private int numberOfRays = 20;
    [SerializeField] private float detectionRange = 10f;
    private float detectionAngle = 45f;
    private Vector2 forwardDirection;
    private Vector2 offset;
    [SerializeField] private LayerMask enemyLayerLeft;
    [SerializeField] private LayerMask enemyLayerRight;

    void Update()
    {
        if (cannonDragAndDrop.Xmore)
        {
            DetectEnemies(enemyLayerRight);
        }
        else
        {
            DetectEnemies(enemyLayerLeft);
        }
    }

    void DetectEnemies(int layerMask)
    {
        if (layerMask == enemyLayerRight)
        {
            offset = new Vector2(0.205f, 0f);
        }
        else
        {
            offset = new Vector2(-0.205f, 0f);
        }

        Vector2 startPosition = (Vector2)transform.position + offset;

        forwardDirection = transform.up;

        float angleBetweenRays = detectionAngle / (numberOfRays - 1);

        float closestDistance = float.MaxValue; // Добавлено для хранения ближайшего расстояния
        GameObject closestEnemy = null; // Добавлено для хранения ближайшего врага

        for (int i = 0; i < numberOfRays; i++)
        {
            float currentAngle = -detectionAngle / 2 + i * angleBetweenRays;

            Vector2 rayDirection = Quaternion.Euler(0, 0, currentAngle) * forwardDirection;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, detectionRange, layerMask);

            if (hit.collider != null)
            {
                float distance = Vector2.Distance(transform.position, hit.collider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = hit.collider.gameObject;
                }

                Debug.DrawRay(startPosition, rayDirection * detectionRange, Color.red);
            }
            else
            {
                Debug.DrawRay(startPosition, rayDirection * detectionRange, Color.green);
            }
        }

        if (closestEnemy != null)
        {
            cannonShooting.enabled = true;
            HandleDetection(closestEnemy);
        }
        else
        {
            cannonShooting.enabled = false;
        }
    }

    void HandleDetection(GameObject closestEnemy)
    {
        cannonRotation.RotateCannon(cannonDragAndDrop.Xmore, closestEnemy);
    }
}
