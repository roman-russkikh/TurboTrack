using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;
    public static ScriptableObject CarsStorage;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, ScriptableObject carsStorage)
    {
      CarsStorage = carsStorage;
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
    }
  }
}