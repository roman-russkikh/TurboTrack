using CodeBase.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.Shop
{
  public class RewardedAdItem : MonoBehaviour
  {
    public Button ShowAdButton;
    public GameObject[] AdActiveObjects;
    public GameObject[] AdInactiveObjects;
    
    
    private IPersistentProgressService _progressService;

    public void Construct(IPersistentProgressService progresService)
    {
      _progressService = progresService;
    }

    public void Initialize()
    {
      ShowAdButton.onClick.AddListener(OnShowAdClicked);
      RefreshAvailableAd();
    }

    public void Subscribe()
    { }

    public void Cleanup() 
    { }

    private void OnShowAdClicked() 
    { }
    

    private void RefreshAvailableAd()
    {
      
    }
  }
}