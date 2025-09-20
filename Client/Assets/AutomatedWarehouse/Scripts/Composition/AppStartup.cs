using UnityEngine;
using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Infrastructure.API;
using AutomatedWarehouse.Infrastructure.API.DTO;
using AutomatedWarehouse.Features.Warehouse;
using AutomatedWarehouse.Features.Shelves;

namespace AutomatedWarehouse.Composition
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private FloorView _floorView;
        [SerializeField] private ShelvesView _shelvesView;

        private IWarehouseController _warehouseController;
        private IAPIService _apiService;

        private void Awake()
        {
            _warehouseController = new WarehouseController(_floorView, _shelvesView);

            string baseURL = "http://127.0.0.1:5000/";
            _apiService = new APIService(baseURL);
        }

        private async void Start()
        {
            await _apiService.PingServerAsync();
            Debug.Log("Подключение к серверу успешно установлено.");

            var layout = await _apiService.GetAsync<LayoutResponse>("/api/v1/layout");
            _warehouseController.BuildWarehouse(layout);
            Debug.Log(layout);

            var state = await _apiService.GetAsync<StateResponse>("/api/v1/state");
            Debug.Log(state);
        }
    }
}