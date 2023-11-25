using System;
using CodeBase.Infrastructure;
using CodeBase.Services.Backend;
using CodeBase.Services.PersistentProgress;
using Cysharp.Threading.Tasks.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.Shop
{
  public class MainMenuWindow : MonoBehaviour
  {
    [SerializeField] private Button _startMiniGameButton;
    [SerializeField] private Button _openGarageButton;
    [SerializeField] private GameObject _garagePanel;
    [SerializeField] private GameObject _popUpNoCars;

    [SerializeField] private Button _claimCoinsButton;
    [SerializeField] private CoinAdd _coinController;
    
        private void OnEnable()
    {
      Initialize();
    }

    private void OnDisable()
    {
      Cleanup();
    }

    private void Initialize()
    {
      SetClaimButtonActivity(true);
      InitSubscriptions();
    }

    private  void InitSubscriptions()
    {
      _startMiniGameButton.onClick.AddListener(StartMiniGame);
      _openGarageButton.onClick.AddListener(OpenGaragePopUp);
      _claimCoinsButton.onClick.AddListener(GiveIdleCoinsToPlayer);
      BackendServices.OnCoinsAddedToWallet += () => SetClaimButtonActivity(true);
    }

    private void Cleanup()
    {
      BackendServices.OnCoinsAddedToWallet -= () => SetClaimButtonActivity(true);
      _claimCoinsButton.onClick.RemoveAllListeners();
      _startMiniGameButton.onClick.RemoveAllListeners();
      _openGarageButton.onClick.RemoveAllListeners();
    }

    private void StartMiniGame()
    {
            if (Game.Player.PlayerData.PlayerInventory._ownedCarIds.Count > 0)
            {
                SceneManager.LoadScene("Minigame");
            }
            else
            {
                _openGarageButton.transform.parent.gameObject.SetActive(false);
                _startMiniGameButton.transform.parent.gameObject.SetActive(false);
                _popUpNoCars.SetActive(true);
            }
    }
    
    private void OpenGaragePopUp()
    {
            _openGarageButton.transform.parent.gameObject.SetActive(false);
            _startMiniGameButton.transform.parent.gameObject.SetActive(false);
            _garagePanel.SetActive(true);
    }

    private void GiveIdleCoinsToPlayer()
    {
      Game.Player.PlayerData.PlayerInventory.IncrementCoins(_coinController.coins);
      SetClaimButtonActivity(false);
      _coinController.coins = 0;
    }

    private void SetClaimButtonActivity(bool state)
    {
      _claimCoinsButton.interactable = state;
    }
  }
}