using UnityEngine;
using AutomatedWarehouse.Core.Interfaces;

namespace AutomatedWarehouse.Features.Warehouse
{
    public class FloorView : MonoBehaviour, IFloorView
    {
        [SerializeField] private GameObject _floorPrefab;

        private GameObject _floorInstance;

        public void GenerateView(int width, int length)
        {
            _floorInstance = Instantiate(_floorPrefab, transform);
            _floorInstance.transform.localScale = new Vector3(width, 0, length);
        }

        public void DestroyView()
        {
            Destroy(_floorInstance);
        }

    }
}