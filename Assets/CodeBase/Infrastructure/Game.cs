using CodeBase.Cars;
using CodeBase.Data;
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
    public static CarStorage CarsStorage;
    public static Player Player;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, CarStorage carsStorage)
    {
      CarsStorage = carsStorage;
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
    }
  }
}