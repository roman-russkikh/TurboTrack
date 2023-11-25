using Cysharp.Threading.Tasks;
using Openfort;

namespace CodeBase.Services.Backend
{
    public class BackendServices : IService
    {
        public BackendServices()
        {
            InitTask();
        }
        async UniTaskVoid InitTask()
        {
            var openfort = new OpenfortClient("pk_test_XXXXXXX");
            if (openfort.LoadSessionKey() == null) 
            { // Load player key from Player prefs
                openfort.CreateSessionKey();
                // To get session address use sessionKey.Address property
                openfort.SaveSessionKey();

                // After registering the session key, you can then use it like:
                /*var signature = openfort.SignMessage(message);
                openfort.SendSignatureSessionRequest(sessionId, signature);*/
            }
        }
        
    }
}