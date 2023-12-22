using UnityEngine;

public class RotationScript : MonoBehaviour
{
    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}