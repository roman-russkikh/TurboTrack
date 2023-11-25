using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField]
    private int maxLives = 0;
    private int lives = 0;
    private int coins = 0;

    public GameObject coinPrefab = null;

    public GameObject obstaclePrefab = null;

    [SerializeField]
    private float initialGameSpeed = 0;

    [HideInInspector]
    public float gameSpeed = 0;

    public Transform topLeft = null;
    public Transform topRight = null;

    [SerializeField]
    private float timeToSpawnObstacles = 0;

    private float timerSpawnObstacles = 0;

    [SerializeField]
    private float timeToSpawnCoins = 0;

    private float timerSpawnCoins = 0;

    [SerializeField]
    private float timeToIncreaseSpeed = 0;

    [SerializeField]
    private float increaseOfSpeed = 0;

    [SerializeField]
    private float maxSpeed = 0;

    private float timerSpeed = 0;

    private bool stopIncreasingSpeed = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerSpawnCoins = timeToSpawnCoins + Time.time;
        timerSpawnObstacles = timeToSpawnObstacles + Time.time;
        timerSpeed = timeToIncreaseSpeed + Time.time;
        gameSpeed = initialGameSpeed;
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSpawnObstacles < Time.time)
        {
            Vector3 positionToInstantiate = Vector3.zero;
            positionToInstantiate.x = Random.Range(topLeft.position.x, topRight.position.x);
            positionToInstantiate.y = topRight.position.y;
            positionToInstantiate.z = -0.1f;
            Instantiate(obstaclePrefab, positionToInstantiate, Quaternion.identity);
            timerSpawnObstacles = timeToSpawnObstacles * (initialGameSpeed / gameSpeed);
            timerSpawnObstacles += Time.time;
        }
        else if (timerSpawnCoins < Time.time)
        {
            Vector3 positionToInstantiate = Vector3.zero;
            positionToInstantiate.x = Random.Range(topLeft.position.x, topRight.position.x);
            positionToInstantiate.y = topRight.position.y;
            positionToInstantiate.z = -0.1f;
            Instantiate(coinPrefab, positionToInstantiate, Quaternion.identity);
            timerSpawnCoins = timeToSpawnCoins * (initialGameSpeed / gameSpeed);
            timerSpawnCoins += Time.time;
        }

        if (!stopIncreasingSpeed && timerSpeed < Time.time)
        {
            gameSpeed *= increaseOfSpeed;
            timerSpeed = timeToIncreaseSpeed + Time.time;
            if(gameSpeed >= maxSpeed)
            {
                stopIncreasingSpeed = true;
            }
            Debug.Log(gameSpeed);
        }
    }

    public void GetCoin()
    {
        coins++;
        Debug.Log("Coins: " + coins);
    }

    public void LoseLife()
    {
        lives--;
        stopIncreasingSpeed = false;
        gameSpeed = initialGameSpeed;
        timerSpeed = timeToIncreaseSpeed + Time.time;
        Debug.Log("Lives: " + lives);
        if (lives <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player Dead");
        gameSpeed = initialGameSpeed;
        lives = maxLives;
    }
}
