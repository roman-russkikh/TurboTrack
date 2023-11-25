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

        public PlayerInventory()
        {
            //var carAmountInCollection = Game.CarsStorage
            _ownedCarIds = new List<int>();
        }
    }
}