using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using AutomatedWarehouse.Core.Interfaces;
using System;
using AutomatedWarehouse.Infrastructure.API.DTO;

namespace AutomatedWarehouse.Infrastructure.API
{
    public class APIService : IAPIService
    {
        private readonly string _baseURL;

        public APIService(string baseURL)
        {
            _baseURL = baseURL.TrimEnd('/');
        }

        public async Task<T> GetAsync<T>(string endPoint)
        {
            string finalURL = CombineURL(endPoint);
            using UnityWebRequest request = UnityWebRequest.Get(finalURL);

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new APIServiceException($"Get failed: {request.error}", request.responseCode);
            }

            string data = request.downloadHandler.text;

            try
            {
                var responseObject = JsonUtility.FromJson<T>(data);

                return responseObject;
            }
            catch (Exception ex)
            {
                throw new APIServiceException($"Failed to parse JSON response for type {typeof(T).Name}. See inner exception for details.", ex);
            }
        }

        public async Task PingServerAsync()
        {
            string finalURL = CombineURL("api/v1/health");
            using UnityWebRequest request = UnityWebRequest.Get(finalURL);

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new APIServiceException($"Health check failed: {request.error}", request.responseCode);
            }

            try
            {
                string data = request.downloadHandler.text;
                var healthStatus = JsonUtility.FromJson<HealthData>(data);

                if (healthStatus == null || healthStatus.status != "ok")
                {
                    throw new InvalidOperationException($"Health response was not valid. Received: {data}");
                }
            }
            catch (Exception ex)
            {
                throw new APIServiceException("Failed to parse health response.", ex);
            }
        }

        public async Task PostAsync(string endPoint)
        {
            throw new NotImplementedException();
        }

        private string CombineURL(string endpoint)
        {
            return $"{_baseURL}/{endpoint.TrimStart('/')}";
        }
    }
}