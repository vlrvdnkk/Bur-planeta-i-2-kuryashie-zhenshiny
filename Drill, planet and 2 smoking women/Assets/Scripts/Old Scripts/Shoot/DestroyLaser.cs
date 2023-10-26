using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("laser") | collision.gameObject.name.Contains("laserA") | collision.gameObject.name.Contains("laserB"))
        {
            Destroy(collision.gameObject);
        }
    }
}
