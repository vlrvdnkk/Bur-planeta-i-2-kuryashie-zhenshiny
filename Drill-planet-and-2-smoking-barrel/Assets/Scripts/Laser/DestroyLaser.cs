using UnityEngine;

public class DestroyLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("laser"))
        {
            Destroy(collision.gameObject);
        }
    }
}
