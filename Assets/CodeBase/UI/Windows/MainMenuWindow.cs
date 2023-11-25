using System;
using CodeBase.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.Shop
{
  public class MainMenuWindow : MonoBehaviour
  {
    [SerializeField] private Button _startMiniGameButton;
    [SerializeField] private Button _openGarageButton;
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
      Debug.Log("Start minigame");
    }
    
    private void OpenGaragePopUp()
    {
      
    }
  }
}