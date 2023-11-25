using CodeBase.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public int carID = 0;

    [SerializeField]
    private float playerSpeed = 0;

    [SerializeField]
    private Rigidbody2D rigidbody2D = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    public Sprite spriteCar = null;

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

    void UpdatePlayerStats()
    {
        var car = Game.CarsStorage.GetCarById(carID);
        GameManager.instance.maxLives = car.MaxLives;
        GameManager.instance.UpdateLives();
        GameManager.instance.timeToIncreaseSpeed = GameManager.instance.minTimeToIncreaseSpeed + ((car.Control - 1) * controlToSeconds);
        spriteRenderer.sprite = car.Sprite;
    }

    public void Move(InputAction.CallbackContext context)
    {
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
        if (velocity.x == 0)
        {
            rigidbody2D.rotation = 90;
        }
        else if (velocity.x < 0)
        {
            rigidbody2D.rotation = 100;
        }
        else
        {
            rigidbody2D.rotation = 80;
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

            if ((haltMoving < 0 && rigidbody2D.velocity.x > 0) || (haltMoving > 0 && rigidbody2D.velocity.x < 0)) 
            {
                return;
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
