using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace AutomatedWarehouse.Infrastructure.API
{
    public class APIService
    {
        private readonly string _baseURL;

        public APIService(string baseURL)
        {
            _baseURL = baseURL;
        }

        public async Task<string> GetAsync(string endPoint)
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