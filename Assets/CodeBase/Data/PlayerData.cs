using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private PlayerInventory _playerInventory;

        public PlayerData()
        {
            _playerInventory = new PlayerInventory();
        }
    }
}