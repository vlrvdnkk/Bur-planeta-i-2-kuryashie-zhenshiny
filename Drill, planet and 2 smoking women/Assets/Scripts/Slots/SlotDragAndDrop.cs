using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDragAndDrop : MonoBehaviour
{
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("tr ent");
        if (other.CompareTag("Player"))
        {
            Debug.Log("tr ent sl");
            cannonDragAndDrop.isOverSlot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("tr ex");
        if (other.CompareTag("Player"))
        {
            Debug.Log("tr ex sl");
            cannonDragAndDrop.isOverSlot = false;
        }
    }
}
