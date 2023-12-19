using System.Collections;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f;
    [SerializeField] private CannonDragAndDrop cannonDragAndDrop;

    private float currentRotation = 0f;
    private bool rotatingRight = true;
    private bool xFirst = false;

    //void Update()
    //{
    //    RotateCannon(cannonDragAndDrop.Xmore);
    //}

    public void RotateCannon(bool x, GameObject gameObject)
    {
        if (x)
        {
            if (!xFirst)
            {
                transform.eulerAngles = new Vector3(0, 0, -180);
                xFirst = true;
            }
        }
        else
        {
            if (xFirst)
            {
                transform.eulerAngles = Vector3.zero;
                xFirst = false;
            }
        }

        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, gameObject.transform.position - transform.position), step);
    }
}