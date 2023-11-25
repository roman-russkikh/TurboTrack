using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2D = null;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 velocity = Vector2.down;
        velocity.y *= GameManager.instance.gameSpeed;
        rigidbody2D.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy" || collision.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Coin")
        {
            IncreasePosition();
        }
        else if (collision.tag == tag)
        {
            Vector2 positionCollision = collision.transform.position;
            if (positionCollision.x < transform.position.x || (positionCollision.x==transform.position.x && positionCollision.y > transform.position.y))
            {
                IncreasePosition();
            }
        }
    }

    void IncreasePosition()
    {
        Vector2 newPosition = rigidbody2D.position;
        newPosition.y++;
        rigidbody2D.position = newPosition;
    }
}
