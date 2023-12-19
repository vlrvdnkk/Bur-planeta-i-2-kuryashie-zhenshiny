using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 0.5f;

    void Start()
    {
        player = GameObject.Find("Drill").transform;
    }

    void Update()
    {
        Vector2 delta = player.position - transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = (Vector2)transform.position + delta * moveSpeed;
    }
}