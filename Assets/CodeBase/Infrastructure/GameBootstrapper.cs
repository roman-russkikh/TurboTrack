using CodeBase.Cars;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingCurtain CurtainPrefab;
    public CarStorage CarsStorage;
    
    private Game _game;

    private void Awake()
    {
      _game = new Game(this, Instantiate(CurtainPrefab), CarsStorage);
      _game.StateMachine.Enter<BootstrapState>();

      DontDestroyOnLoad(this);
    }
  }
}