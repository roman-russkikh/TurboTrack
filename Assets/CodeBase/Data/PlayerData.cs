using System;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private PlayerInventory _playerInventory;
        
        [JsonIgnore]
        public PlayerInventory PlayerInventory => _playerInventory;

        public PlayerData()
        {
            _playerInventory = new PlayerInventory();
        }
    }
}