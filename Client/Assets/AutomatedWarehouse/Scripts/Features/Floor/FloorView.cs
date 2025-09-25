using UnityEngine;
using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Features.Floor
{
    public class FloorView : MonoBehaviour, IFloorView
    {
        [SerializeField] private GameObject _floorPrefab;

        private GameObject _floorInstance;

        public void DisplayView(SizeModel size)
        {
            _floorInstance = Instantiate(_floorPrefab, transform);
            _floorInstance.transform.localScale = new Vector3(size.Width, 0, size.Length);
        }

        public void HideView()
        {
            Destroy(_floorInstance);
        }

    }
}