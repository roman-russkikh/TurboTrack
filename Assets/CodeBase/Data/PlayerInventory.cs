using System;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerInventory
    {
        [SerializeField] public List<int> _ownedCarIds;
        [SerializeField] public int _coinsAmount;

        public PlayerInventory()
        {
            var carAmountInCollection = Game.CarsStorage.Cars.Count;
            _ownedCarIds = new List<int>(carAmountInCollection);

            _coinsAmount = 50;
        }
    }
}