using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 direction;

    private Transform player;

    public void SetPlayerTransform(Transform playerTransform)
    {
        player = playerTransform;
    }

    public void Shoot()
    {
        Vector2 playerPosition = player.position;
        Vector2 bulletPosition = transform.position;
        direction = (playerPosition - bulletPosition).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
