using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 0;

    [SerializeField]
    private Rigidbody2D rigidbody2D = null;

    private int haltMoving = 0;

    private float horizontalSpeed = 0;

    [SerializeField]
    private int control = 0;

    [SerializeField]
    private int controlToSeconds = 0;

    [SerializeField]
    private int maxLives = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerStats();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    void UpdatePlayerStats()
    {
        GameManager.instance.maxLives = maxLives;
        GameManager.instance.UpdateLives();
        GameManager.instance.timeToIncreaseSpeed = GameManager.instance.minTimeToIncreaseSpeed + ((control - 1) * controlToSeconds);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("III");
        if (context.started)
        {
            return;
        }
        horizontalSpeed = context.ReadValue<Vector2>().x;
        Vector3 velocity = Vector3.zero;
        velocity.x += horizontalSpeed * playerSpeed;
        if (haltMoving != 0 && velocity.x != 0)
        {
            if (haltMoving < 0 && velocity.x < 0)
            {
                velocity.x = 0;
            }
            else if (haltMoving > 0 && velocity.x > 0)
            {
                velocity.x = 0;
            }
        }
        rigidbody2D.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Road")
        {
            if (collision.transform.position.x > transform.position.x)
            {
                haltMoving = 1;
            }
            else
            {
                haltMoving = -1;
            }
            rigidbody2D.velocity = Vector2.zero;
        }
        else if (collision.tag == "Obstacle")
        {
            GameManager.instance.LoseLife();
        }
        else if (collision.tag == "Coin")
        {
            GameManager.instance.GetCoin();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Road")
        {
            haltMoving = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION");
    }
}
