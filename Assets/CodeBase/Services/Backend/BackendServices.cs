using System.Collections;
using System.Diagnostics;
using CodeBase.Data;
using CodeBase.Infrastructure;
using Cysharp.Threading.Tasks;
using Openfort;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;

namespace CodeBase.Services.Backend
{
    public class BackendServices : IService
    {
        private const string JsonUrl = "https://api.openfort.xyz/v1/players"; // add id to update the data

        private const string PostData = "{ \"name\": \"Roman Ru\" }";
        //private const string PostData = "{ \"name\": \"Roman Ru\", \"metadata\": \"json\" }";

        private const string RequestContentType = "application/json";
        private const string _playerId = "sk_test_67a85e48-566f-5485-9679-77c8cd1b5be6";

        public BackendServices()
        {
            InitTask();
        }
        async UniTask InitTask()
        {
            var player = Player.Load();
            if (player == null)
            {
                // Create new player
                var request =
                    UnityWebRequest.Post(JsonUrl, PostData,
                        RequestContentType); // use get to get some specific player of all of them if requested with id

                request.SetRequestHeader("Authorization", $"Bearer {_playerId}");
                //request.SetRequestHeader("Content-Type", "application/json");

                await request.SendWebRequest();

                Game.Player = new Player(_playerId);
                Game.Player.Save();
            }
            else
            {
                Game.Player = player;
            }
        }

        private void CreatePlayer()
        {
            
        }

        private  IEnumerator Test()
        {
            string url = "https://api.openfort.xyz/v1/players";

            // Create a new UnityWebRequest object
            UnityWebRequest www = new UnityWebRequest(url, "POST");

            // Create the payload JSON
            var payload = "{ \"name\": Roman Ru }";

            // Add the header for Authentication
            www.SetRequestHeader("Authentication", _playerId);
            www.SetRequestHeader("Content-Type", "application/json");

            // Send the request and wait for a response
            yield return www.SendWebRequest();

            // Check for errors
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log("Response: " + www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
        
    }
}