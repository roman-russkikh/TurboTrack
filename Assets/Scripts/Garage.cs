using CodeBase.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Garage : MonoBehaviour
{
    [SerializeField]
    private GameObject rightButton = null;

    [SerializeField]
    private GameObject leftButton = null;

    [SerializeField]
    private Image carImage = null;

    [SerializeField]
    private TextMeshProUGUI controlText = null;

    [SerializeField]
    private TextMeshProUGUI maxLivesText = null;

    [SerializeField]
    private TextMeshProUGUI velocityText = null;

    [SerializeField]
    private TextMeshProUGUI maxSpeedText = null;

    [SerializeField]
    private TextMeshProUGUI nameText = null;

    [SerializeField]
    private TextMeshProUGUI costText = null;

    [SerializeField]
    private TextMeshProUGUI coinsText = null;

    [SerializeField]
    private GameObject buyButton = null;

    [SerializeField]
    private GameObject selectButton = null;

    public SpriteRenderer carRenderer = null;

    private List<Car> cars = null;


    private int selectedCarIndex = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Initialize();
        gameObject.SetActive(false);
    }

    private void Initialize()
    {
        cars = Game.CarsStorage.Cars;
        selectedCarIndex = 0;

        if (cars.Count <= 1)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
        }

        if (Game.Player.PlayerData.PlayerInventory._ownedCarIds.Count == 0)
        {
            carRenderer.gameObject.SetActive(false);
        }
        else
        {
            int idCarSelected = Game.Player.PlayerData.PlayerInventory._idleSelectedCar;
            if (idCarSelected == -1)
            {
                return;
            }
            selectedCarIndex = cars.IndexOf(Game.CarsStorage.GetCarById(idCarSelected));
            UpdateSpriteCar(carRenderer);
        }
    }

    public void SelectCar()
    {
        Game.Player.PlayerData.PlayerInventory._idleSelectedCar = cars[selectedCarIndex].Id;
        Game.Player.Save();
    }

    private void OnEnable()
    {
        if (cars == null)
        {
            Initialize();
        }
        LoadCarStartMenu();
    }

    public void UpdateSpriteCar(SpriteRenderer spriteToUpdate)
    {
        spriteToUpdate.sprite = cars[selectedCarIndex].Sprite;
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
        LoadCarStartMenu();
    }

    public void BuyCar()
    {
        if (Game.Player.PlayerData.PlayerInventory._coinsAmount >= cars[selectedCarIndex].Cost)
        {
            Game.Player.PlayerData.PlayerInventory._coinsAmount -= cars[selectedCarIndex].Cost;
            Game.Player.PlayerData.PlayerInventory.AddCarToCollection(cars[selectedCarIndex].Id);
            UpdateCoins();
            buyButton.SetActive(false);
            selectButton.SetActive(true);
        }
    }

    public void UpdateCoins()
    {
        coinsText.text = Game.Player.PlayerData.PlayerInventory._coinsAmount.ToString();
    }

    public void LoadCarStartMenu()
    {
        Car car = cars[selectedCarIndex];

        if (car == null)
        {
            return;
        }

        if (!carRenderer.gameObject.activeInHierarchy)
        {
            carRenderer.gameObject.SetActive(true);
        }

        nameText.text = car.Name;

        maxSpeedText.text = car.MaxSpeed.ToString();

        velocityText.text = car.Velocity.ToString();

        carImage.sprite = car.Sprite;

        controlText.text = car.Control.ToString();

        maxLivesText.text = car.MaxLives.ToString();

        UpdateCoins();

        if (Game.Player.PlayerData.PlayerInventory._ownedCarIds.Contains(car.Id))
        {
            buyButton.SetActive(false);
            selectButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            costText.text = "Buy: " + car.Cost.ToString() + " C";
        }
    }

}
