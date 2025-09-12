using UnityEngine;
using AutomatedWarehouse.Infrastructure.API;

namespace AutomatedWarehouse.Composition
{
    public class AppStartup : MonoBehaviour
    {
        private APIService _apiService;

        private async void Start()
        {
            string baseURL = "http://127.0.0.1:5000/api/";
            _apiService = new APIService(baseURL);

            string connectionTest = await _apiService.GetAsync("/v1/health");
            Debug.Log(connectionTest);

            string layout = await _apiService.GetAsync("/v1/layout");
            Debug.Log(layout);
        }
    }
}