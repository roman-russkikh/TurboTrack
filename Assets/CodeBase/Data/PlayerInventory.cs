using System;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Services;
using CodeBase.Services.Backend;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerInventory
    {
        [SerializeField] public List<int> _ownedCarIds;
        [SerializeField] public int _coinsAmount;
        [SerializeField] public int _miniGameSelectedCar;
        [SerializeField] public int _idleSelectedCar;

       
        public PlayerInventory()
        {
            var carAmountInCollection = Game.CarsStorage.Cars.Count;
            _ownedCarIds = new List<int>(carAmountInCollection);

            _coinsAmount = 50;
            _miniGameSelectedCar = -1;
            _idleSelectedCar = -1;
        }

        public void IncrementCoins(int coinsToAdd)
        {
            _coinsAmount += coinsToAdd;
            var backendServices = AllServices.Container.Single<BackendServices>();
            backendServices.AddCoinsToWallet(coinsToAdd);
            Game.Player.Save();
        }
        
        public void DecrementCoins(int coinsToRemove)
        {
            var tempCoinsAmount = _coinsAmount;
            tempCoinsAmount -= coinsToRemove;
            
            if (tempCoinsAmount < 0)
            {
                Debug.Log("Not enough coins");
                return;
            }
            
            _coinsAmount = tempCoinsAmount;
            var backendServices = AllServices.Container.Single<BackendServices>();
            backendServices.AddCoinsToWallet(coinsToRemove);
            Game.Player.Save();
        }
        
        public void AddCarToCollection(int carIdToAdd)
        {
            _ownedCarIds.Add(carIdToAdd);
            var backendServices = AllServices.Container.Single<BackendServices>();
            backendServices.AddCarToCollection(carIdToAdd);
            Game.Player.Save();
        }
    }
}