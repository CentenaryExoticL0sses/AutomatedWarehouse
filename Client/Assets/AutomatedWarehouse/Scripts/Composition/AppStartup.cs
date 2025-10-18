using UnityEngine;
using System.Threading.Tasks;
using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Infrastructure.API;
using AutomatedWarehouse.Infrastructure.API.DTO;
using AutomatedWarehouse.Features.Warehouse;
using AutomatedWarehouse.Features.Shelves;
using AutomatedWarehouse.Features.Floor;
using AutomatedWarehouse.Features.Robots;

namespace AutomatedWarehouse.Composition
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private FloorController _floorView;
        [SerializeField] private ShelvesController _shelvesView;
        [SerializeField] private RobotsController _robotsView;

        [SerializeField] private float _pollingIntervalSeconds;

        private IWarehouseController _warehouseController;
        private IAPIService _apiService;

        private void Awake()
        {
            _warehouseController = new WarehouseController(_floorView, _shelvesView, _robotsView);

            string baseURL = "http://127.0.0.1:5000/";
            _apiService = new APIService(baseURL);
        }

        private async void Start()
        {
            await _apiService.PingServerAsync();
            Debug.Log("Подключение к серверу успешно установлено.");

            var layoutData = await _apiService.GetAsync<LayoutData>("/api/v1/layout");
            var layoutModel = layoutData.ToDomain();
            _warehouseController.BuildWarehouse(layoutModel);
            Debug.Log(layoutModel);

            var stateData = await _apiService.GetAsync<StateData>("/api/v1/state");
            var stateModel = stateData.ToDomain();
            _warehouseController.UpdateWarehouse(stateModel);
            Debug.Log(stateModel);

            _ = PollStateAsync();
        }

        private async Task PollStateAsync()
        {
            int pollingInterval = (int)(_pollingIntervalSeconds * 1000);

            while (true)
            {
                await Task.Delay(pollingInterval);
                var stateData = await _apiService.GetAsync<StateData>("/api/v1/state");
                var stateModel = stateData.ToDomain();
                _warehouseController.UpdateWarehouse(stateModel);
                Debug.Log(stateModel);
            }
        }
    }
}