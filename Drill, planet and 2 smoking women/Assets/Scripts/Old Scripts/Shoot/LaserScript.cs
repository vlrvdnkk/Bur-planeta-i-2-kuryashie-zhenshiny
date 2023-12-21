using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private float lifetime = 2;
    [SerializeField] private float speed = 10;
    public int damage = 1;
    public int damageA = 1;
    public int damageB = 3;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}