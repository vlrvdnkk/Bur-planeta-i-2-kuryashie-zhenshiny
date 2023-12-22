using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private float lifetime = 2;
    [SerializeField] private float speed = 10;
    public int Damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}