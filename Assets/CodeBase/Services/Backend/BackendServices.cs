using System;
using System.Collections;
using CodeBase.Infrastructure;
using Cysharp.Threading.Tasks;
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
        private const string CarContractId = "con_0e1e7591-904a-4fb5-8a4b-6c9bf89ecfbc";
        private const string CoinPolicyId = "pol_e33eb4d4-012c-4771-9e72-cbb50c711de7";
        private const string CarPolicyId = "pol_3780249a-c087-4c1d-805c-4b9126456e5e";

        private const int ChainId = 421613;
        
        
        //private const string PostData = "{ \"name\": \"Roman Ru\", \"metadata\": \"json\" }";

        private const string RequestContentType = "application/json";
        private const string _authToken = "sk_test_67a85e48-566f-5485-9679-77c8cd1b5be6";

        public static Action OnCoinsAddedToWallet;

        public void AddCoinsToWallet(int coinsToAdd)
        {
            AddCoinsTask(coinsToAdd);
        }
        
        public void RemoveCoinsFromWallet(int coinsToRemove)
        {
            RemoveCoinsTask(coinsToRemove);
        }
        
        public void AddCarToCollection(int carIdToAdd)
        {
            //AddCarToWalletTask(carIdToAdd);
        }

        private async UniTask AddCarToWalletTask(int id)
        {
            var myPlayerId = Game.Player.ID;
            var car = Game.CarsStorage.GetCarById(id);
            var carIndex = Game.CarsStorage.Cars.IndexOf(car);
            var carCost = (ulong)car.Cost * 1000000000000000000;
            var _data = "0x";
            var coinAddress = "0xf48B60dd98B0373d61690A9925f9cEea7630133c";
            
            string carToAddRequest = $"{{ " +
                                      $"\"player\": \"{myPlayerId}\", " +
                                      $"\"chainId\": \"{ChainId}\", " +
                                      $"\"policy\": \"{CarPolicyId}\", " +
                                      $"\"optimistic\": false, " +
                                      $"\"interactions\": [{{ " +
                                      $"\"contract\": \"{CoinContractId}\", " +
                                      $"\"functionName\": \"approve\", " +
                                      $"\"functionArgs\": [\"{CarContractId}\", \"{carCost}\"] " +
                                      $"}}, {{ " +
                                      $"\"contract\": \"{CarContractId}\", " +
                                      $"\"functionName\": \"claim\", " +
                                      $"\"value\": \"0\", " +
                                      $"\"functionArgs\": [" +
                                      $"\"{myPlayerId}\", " +
                                      $"{carIndex}, " +
                                      $"{1}, " +
                                      $"\"{coinAddress}\", " +
                                      $"\"{carCost}\", " +
                                      $"[[\"0x0000000000000000000000000000000000000000000000000000000000000000\"],{ 1 },\"{carCost}\",\"{CoinContractId}\"], " + 
                                      $"\"{_data}\"" +
                                      $"] }}" +
                                      $"] }}";
                                      //$"{{[\"0x0000000000000000000000000000000000000000000000000000000000000000\"],{ 1 },\"{carCost}\",\"{CoinContractId}\", \"{_data}\" }}";
            
                                      // Create new player
                                      var request =
                                          UnityWebRequest.Post(JsonUrlTransaction, carToAddRequest,
                                              RequestContentType); // use get to get some specific player of all of them if requested with id

                                      request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
                                      //request.SetRequestHeader("Content-Type", "application/json");

                                      await request.SendWebRequest(); // Update my id
                                      Debug.Log("Added");
        }
        public BackendServices()
        {
            InitTask();
            AddCarToCollection(2525);
        }
        async UniTask InitTask()
        {
            
            var player = Data.Player.Load();
            if (player == null || player.ID == _authToken)
            {
                // Create new player
                var request =
                    UnityWebRequest.Post(JsonUrl, PostData,
                        RequestContentType); // use get to get some specific player of all of them if requested with id

                request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
                //request.SetRequestHeader("Content-Type", "application/json");

                var registrationRequest = await request.SendWebRequest(); // Update my id
                var resultString = registrationRequest.downloadHandler.text;
               
                // Extract the value associated with the "id" key
                string playerId = GetJsonValue(resultString, "id");

                Game.Player = new Data.Player(playerId);
                Game.Player.Save();
            }
            else
            {
                Game.Player = player;
            }
        }

        private async UniTask AddCoinsTask(int coinsToAdd)
        {
            var mintCoinsToAdd = (ulong)coinsToAdd * 1000000000000000000;
            var myPlayerId = Game.Player.ID;
            string coinToAddRequest = $"{{ " +
                                      $"\"player\": \"{CoinMasterPlayerId}\", " +
                                      $"\"chainId\": \"{ChainId}\", " +
                                      $"\"policy\": \"{CoinPolicyId}\", " +
                                      $"\"optimistic\": false, " +
                                      $"\"interactions\": [{{ " +
                                      $"\"contract\": \"{CoinContractId}\", " +
                                      $"\"functionName\": \"transfer\", " +
                                      $"\"functionArgs\": [\"{myPlayerId}\", \"{mintCoinsToAdd}\"] " +
                                      $"}}] }}";
            
            
            var request =
                UnityWebRequest.Post(JsonUrlTransaction, coinToAddRequest,
                    RequestContentType); // use get to get some specific player of all of them if requested with id

            request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
            //request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();
            Debug.Log("Done");
            OnCoinsAddedToWallet?.Invoke();
        }
        
        private async UniTask RemoveCoinsTask(int coinsToRemove)
        {
            var mintCoinsAmountToRemove = (ulong)coinsToRemove * 1000000000000000000;
            
            var myPlayerId = Game.Player.ID;
            string coinToAddRequest = $"{{ " +
                                      $"\"player\": \"{myPlayerId}\", " +
                                      $"\"chainId\": \"{ChainId}\", " +
                                      $"\"policy\": \"{CoinPolicyId}\", " +
                                      $"\"optimistic\": false, " +
                                      $"\"interactions\": [{{ " +
                                      $"\"contract\": \"{CoinContractId}\", " +
                                      $"\"functionName\": \"transfer\", " +
                                      $"\"functionArgs\": [\"{CoinMasterPlayerId}\", \"{mintCoinsAmountToRemove}\"] " +
                                      $"}}] }}";
            
            
            var request =
                UnityWebRequest.Post(JsonUrlTransaction, coinToAddRequest,
                    RequestContentType); // use get to get some specific player of all of them if requested with id

            request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
            //request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();
            Debug.Log("Done removed");
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
        
        string GetJsonValue(string jsonString, string key)
        {
            int startIndex = jsonString.IndexOf("\"" + key + "\":") + key.Length + 5; // 4 is for the characters ": "
            int endIndex = jsonString.IndexOf("\"", startIndex + 1); // Look for the next quotation mark after the starting quote

            return jsonString.Substring(startIndex, endIndex - startIndex);
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
    }
}