using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace AutomatedWarehouse.Infrastructure.API
{
    public class APIService : MonoBehaviour
    {
        [Header("Настройки")]
        [SerializeField] private string _baseURL;
        [SerializeField] private string _layoutEndpoint;

        private async void Start()
        {
            string response = await GetAsync(_layoutEndpoint);
            Debug.Log(response);
        }

        private async Task<string> GetAsync(string endPoint)
        {
            string finalURL = _baseURL + endPoint.TrimStart('/');
            UnityWebRequest request = UnityWebRequest.Get(finalURL);
            await request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {
                throw new APIServiceException(request.error, request.responseCode);
            }

            string data = request.downloadHandler.text;
            return data;
        }
    }
}