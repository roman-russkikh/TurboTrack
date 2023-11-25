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
        private const string JsonUrlWallet = "https://api.openfort.xyz/v1/accounts"; 
        private const string JsonUrlTransaction = "https://api.openfort.xyz/v1/transaction_intents"; 

        private const string PostData = "{ \"name\": \"Roman Ru\" }";
        private const string PostDataWallet = "{ \"chainId\": 421613, \"player\": \"pla_ddea48d1-0539-44a9-b13a-d681d0358b07\" }";

        private const string CoinMasterPlayerId = "pla_ddea48d1-0539-44a9-b13a-d681d0358b07";
        private const string CoinContractId = "con_79fdf2f2-2f56-41eb-b3ae-eb5a0b2b7e2e";
        private const string CoinPolicyId = "pol_e33eb4d4-012c-4771-9e72-cbb50c711de7";
        
        
        //private const string PostData = "{ \"name\": \"Roman Ru\", \"metadata\": \"json\" }";

        private const string RequestContentType = "application/json";
        private const string _authToken = "sk_test_67a85e48-566f-5485-9679-77c8cd1b5be6";

        public void AddCoinsToWallet(int coinsToAdd)
        {
            
        }
        
        public void AddCarToCollection(int carIdToAdd)
        {
            
        }
        public BackendServices()
        {
            InitTask();
            //InitWallet();
        }
        async UniTask InitTask()
        {
            var player = Player.Load();
            if (player == null)
            {
                // Create new player
                var request =
                    UnityWebRequest.Post(JsonUrl, PostDataWallet,
                        RequestContentType); // use get to get some specific player of all of them if requested with id

                request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
                //request.SetRequestHeader("Content-Type", "application/json");

                var registrationRequest = await request.SendWebRequest(); // Update my id
                
                //var playerId = registrationRequest.

                Game.Player = new Player(_authToken);
                Game.Player.Save();
            }
            else
            {
                Game.Player = player;
            }
        }

        private async UniTask AddCoinsTask(int coinsToAdd)
        {
            var coinsToAssRequest = "{ \"player\": \"pla_ddea48d1-0539-44a9-b13a-d681d0358b07\", " +
                                    "\"chainId\": 421613," +
                                    "\"policy\": \"pol_e33eb4d4-012c-4771-9e72-cbb50c711de7\", " +
                                    "\"optimistic\": false, " +
                                    "\"interactions\": \"pla_ddea48d1-0539-44a9-b13a-d681d0358b07\",}";
            
            /*"interactions": [
            {
                "contract" : "con_79fdf2f2-2f56-41eb-b3ae-eb5a0b2b7e2e",
                "functionName": "transfer",
                "contract": "0x0576...1B57",
                "functionArgs": [
                "con_79fdf2f2-2f56-41eb-b3ae-eb5a0b2b7e2e", // US my player id
                40,
                    ]
            }*/
            
            var request =
                UnityWebRequest.Post(JsonUrlTransaction, PostDataWallet,
                    RequestContentType); // use get to get some specific player of all of them if requested with id

            request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
            //request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();
        }
        

        private async UniTask InitWallet()
        {
            // Create new player
            var request =
                UnityWebRequest.Post(JsonUrlWallet, PostDataWallet,
                    RequestContentType); // use get to get some specific player of all of them if requested with id

            request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
            //request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();
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
            www.SetRequestHeader("Authentication", _authToken);
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