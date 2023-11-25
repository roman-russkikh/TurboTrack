using System.Threading.Tasks;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows.Shop;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private const string UIRootPath = "UIRoot";
 
    private readonly IStaticDataService _staticData;
    
    private Transform _uiRoot;
    private readonly IPersistentProgressService _progressService;
   

    public UIFactory( IStaticDataService staticData, IPersistentProgressService progressService
      )
    {
      _staticData = staticData;
      _progressService = progressService;
    }

    public void CreateShop()
    {
      WindowConfig config = _staticData.ForWindow(WindowId.Shop);
      ShopWindow window = Object.Instantiate(config.Template, _uiRoot) as ShopWindow;
      window.Construct(_progressService);
    }

    public async Task CreateUIRoot()
    {
      /*GameObject root = await _assets.Instantiate(UIRootPath);
      _uiRoot = root.transform;*/
    }
  }
}