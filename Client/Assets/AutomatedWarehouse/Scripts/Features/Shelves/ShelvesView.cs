using System.Collections.Generic;
using UnityEngine;
using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Infrastructure.API.DTO;

namespace AutomatedWarehouse.Features.Shelves
{
    public class ShelvesView : MonoBehaviour, IShelvesView
    {
        [SerializeField] private GameObject _shelfPrefab;

        private List<GameObject> _shelves = new();

        public void GenerateView(IEnumerable<ShelfData> shelves)
        {
            foreach(var shelf in shelves)
            {
                var shelfInstance = Instantiate(_shelfPrefab, transform);
                shelfInstance.name = shelf.id;
                shelfInstance.transform.position = new Vector3(shelf.position.x, 0f, shelf.position.y);
                shelfInstance.transform.localScale = new Vector3(shelf.size.width, 1f, shelf.size.length);
                _shelves.Add(shelfInstance);
            }
        }

        public void DestroyView()
        {
            foreach(var shelf in _shelves)
            {
                Destroy(shelf);
            }
            _shelves.Clear();
        }
    }
}