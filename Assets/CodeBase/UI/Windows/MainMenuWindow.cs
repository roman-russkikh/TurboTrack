using System;
using CodeBase.Services.PersistentProgress;
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
      InitSubscriptions();
    }

    private  void InitSubscriptions()
    {
      _startMiniGameButton.onClick.AddListener(StartMiniGame);
      _openGarageButton.onClick.AddListener(OpenGaragePopUp);
    }

    private void Cleanup()
    {
      _startMiniGameButton.onClick.RemoveAllListeners();
      _openGarageButton.onClick.RemoveAllListeners();
    }

    private void StartMiniGame()
    {
            SceneManager.LoadScene("Minigame");
    }
    
    private void OpenGaragePopUp()
    {
            _openGarageButton.gameObject.SetActive(false);
            _startMiniGameButton.gameObject.SetActive(false);
            _garagePanel.SetActive(true);
    }
  }
}