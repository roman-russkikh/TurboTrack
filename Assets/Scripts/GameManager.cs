using CodeBase.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [HideInInspector]
    public  int maxLives = 0;
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

    public float minTimeToIncreaseSpeed = 0;

    [HideInInspector]
    public float timeToIncreaseSpeed = 0;

    [SerializeField]
    private float increaseOfSpeed = 0;

    [SerializeField]
    private float maxSpeed = 0;

    private float timerSpeed = 0;

    private bool stopIncreasingSpeed = false;

    [SerializeField]
    private int timesNeededSpeedIncreaseToIncreaseInstantiations = 0;

    private int timesSpeedIncreased = 0;

    private int timesInstantiateAtTheSameTime = 0;

    [SerializeField]
    private TextMeshProUGUI coinsText = null;

    [SerializeField]
    private TextMeshProUGUI livesText = null;

    [SerializeField]
    private TextMeshProUGUI finalCoinsText = null;

    [SerializeField]
    private GameObject pauseMenu = null;

    [SerializeField]
    private GameObject pauseButton = null;

    [SerializeField]
    private GameObject rightButton = null;

    [SerializeField]
    private GameObject leftButton = null;


    [SerializeField]
    private TextMeshProUGUI controlText = null;

    [SerializeField]
    private TextMeshProUGUI maxLivesText = null;

    private Car selectedCar = null;

    private List<int> cars = null;

    private int selectedCarIndex = 0;

    public Player player = null;

    private void Awake()
    {
        instance = this;
        PauseGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO
        //var cars = Game.Player.PlayerData.PlayerInventory._ownedCarIds;
        cars = new List<int>() { 2525, 3636 };

        selectedCarIndex = 0;
        selectedCar = LoadCarStartMenu();

        if (cars.Count <= 1)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
        }
    }

    public void ChangeCarStartMenu(int indexAdditive)
    {
        selectedCarIndex += indexAdditive;

        if (selectedCarIndex >= cars.Count)
        {
            selectedCarIndex = 0;
        }
        else if (selectedCarIndex < 0)
        {
            selectedCarIndex = cars.Count - 1;
        }

        selectedCar = LoadCarStartMenu();
    }

    public Car LoadCarStartMenu()
    {
        Car carToReturn = Game.CarsStorage.GetCarById(cars[selectedCarIndex]);
        Debug.Log(carToReturn.Name);

        controlText.text = carToReturn.Control.ToString();

        maxLivesText.text = carToReturn.MaxLives.ToString();

        return carToReturn;
    }

    public void StartRace()
    {
        player.carID = cars[selectedCarIndex];
        player.gameObject.SetActive(true);
        timerSpawnCoins = timeToSpawnCoins + Time.time;
        timerSpawnObstacles = timeToSpawnObstacles + Time.time;
        timerSpeed = timeToIncreaseSpeed + Time.time;
        gameSpeed = initialGameSpeed;
        lives = maxLives;
        timesSpeedIncreased = 0;
        timesInstantiateAtTheSameTime = 1;
        coins = 0;
        UpdateCoinsText();
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSpawnObstacles < Time.time)
        {
            for(int i = 0; i < timesInstantiateAtTheSameTime; i++)
            {
                Spawn(obstaclePrefab);
            }
            timerSpawnObstacles = timeToSpawnObstacles * (initialGameSpeed / gameSpeed);
            timerSpawnObstacles += Time.time;
        }
        else if (timerSpawnCoins < Time.time)
        {
            Spawn(coinPrefab);
            timerSpawnCoins = timeToSpawnCoins * (initialGameSpeed / gameSpeed);
            timerSpawnCoins += Time.time;
        }

        if (!stopIncreasingSpeed && timerSpeed < Time.time)
        {
            gameSpeed *= increaseOfSpeed;
            timesSpeedIncreased++;
            if(timesSpeedIncreased >=timesNeededSpeedIncreaseToIncreaseInstantiations)
            {
                timesSpeedIncreased = 0;
                timesInstantiateAtTheSameTime++;
            }
            timerSpeed = timeToIncreaseSpeed + Time.time;
            if(gameSpeed >= maxSpeed)
            {
                stopIncreasingSpeed = true;
            }
            Debug.Log(gameSpeed);
        }
    }

    void Spawn(GameObject prefab)
    {
        Vector3 positionToInstantiate = Vector3.zero;
        positionToInstantiate.x = Random.Range(topLeft.position.x, topRight.position.x);
        positionToInstantiate.y = topRight.position.y;
        positionToInstantiate.z = -0.1f;
        Instantiate(prefab, positionToInstantiate, Quaternion.identity);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("QUIT");
    }

    public void GetCoin()
    {
        coins++;
        UpdateCoinsText();
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();
        stopIncreasingSpeed = false;
        gameSpeed = initialGameSpeed;
        timesInstantiateAtTheSameTime = 1;
        timesSpeedIncreased = 0;
        timerSpeed = timeToIncreaseSpeed + Time.time;
        if (lives <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        PauseGame();
        pauseButton.SetActive(false);
        finalCoinsText.text = "You got: ";
        finalCoinsText.text += coins.ToString();
        finalCoinsText.text += " coins";
        pauseMenu.SetActive(true);
        //gameSpeed = initialGameSpeed;
        //lives = maxLives;
    }

    public void UpdateLives()
    {
        lives = maxLives;
        UpdateLivesText();
    }

    void UpdateLivesText()
    {
        livesText.text = lives.ToString();
    }

    void UpdateCoinsText()
    {
        coinsText.text = coins.ToString();
    }
}
