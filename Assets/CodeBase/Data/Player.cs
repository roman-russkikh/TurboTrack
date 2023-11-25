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
        
        // Save the player data and ID to PlayerPrefs
        public void Save()
        {
            // Serialize the player data to JSON
            string playerDataJson = JsonUtility.ToJson(_playerData);

            // Save the player data and ID to PlayerPrefs
            PlayerPrefs.SetString("PlayerData_" + _id, playerDataJson);
            PlayerPrefs.SetString("PlayerID", _id);

            // Save the data to disk
            PlayerPrefs.Save();
        }

        // Load the player data from PlayerPrefs
        public static Player Load()
        {
            // Retrieve the player ID from PlayerPrefs
            string playerId = PlayerPrefs.GetString("PlayerID", "");

            if (!string.IsNullOrEmpty(playerId))
            {
                // Retrieve the player data JSON string from PlayerPrefs
                string playerDataJson = PlayerPrefs.GetString("PlayerData_" + playerId, "");

                if (!string.IsNullOrEmpty(playerDataJson))
                {
                    // Deserialize the player data JSON string to a PlayerData object
                    PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(playerDataJson);

                    // Create a new player instance with the loaded data
                    Player loadedPlayer = new Player(playerId);
                    loadedPlayer._playerData = loadedPlayerData;

                    return loadedPlayer;
                }
            }

            // If no saved data is found, return a new player with default values
            return null;
        }
    }
}