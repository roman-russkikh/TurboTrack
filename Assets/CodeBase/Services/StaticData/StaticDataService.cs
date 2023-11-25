using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string MonstersDataPath = "Static Data/Monsters";
    private const string LevelsDataPath = "Static Data/Levels";
    private const string StaticDataWindowPath = "Static Data/UI/WindowStaticData";

    private Dictionary<WindowId, WindowConfig> _windowConfigs;


    public void Load()
    {
     
    }
   

    public WindowConfig ForWindow(WindowId windowId) =>
      _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
        ? windowConfig
        : null;
  }
}