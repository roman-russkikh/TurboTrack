using System.Collections;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
using Openfort;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;

namespace CodeBase.Services.Backend
{
    public class BackendServices : IService
    {
        private const string JsonUrl = "https://api.openfort.xyz/v1/players"; // add id to update the data

        private const string PostData = "{ \"name\": \"Roman Ru\", \"metadata\": \"json\" }";

        private const string RequestContentType = "application/json";
        public BackendServices()
        {
            InitTask();
        }
        async UniTask InitTask()
        {
            // Create new player
            var request = UnityWebRequest.Post(JsonUrl, PostData, RequestContentType); // use get to get some specific player of all of them if requested with id
        
            request.SetRequestHeader("Authorization", "Bearer sk_test_67a85e48-566f-5485-9679-77c8cd1b5be6");
            //request.SetRequestHeader("Content-Type", "application/json");
            
            await request.SendWebRequest();
            
            Debug.Log(request);
            /*var publishKey = OpenfortSettings.Instance.PublishedKey;
            var openfort = new OpenfortClient(publishKey);*/
            /*if (openfort.LoadSessionKey() == null) 
            { // Load player key from Player prefs
                /*openfort.CreateSessionKey();
                // To get session address use sessionKey.Address property
                openfort.SaveSessionKey();#1#

                // After registering the session key, you can then use it like:
                /*var signature = openfort.SignMessage(message);
                openfort.SendSignatureSessionRequest(sessionId, signature);#1#
            }*/
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
            www.SetRequestHeader("Authentication", "Bearer sk_test_67a85e48-566f-5485-9679-77c8cd1b5be6");
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