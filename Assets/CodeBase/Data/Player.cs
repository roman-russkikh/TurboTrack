using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class Player
    {
        [SerializeField] private string _id = "";
        [SerializeField] private PlayerData _playerData;

        public Player(string id)
        {
            _id = id;
            _playerData = new PlayerData();
        }
    }
}