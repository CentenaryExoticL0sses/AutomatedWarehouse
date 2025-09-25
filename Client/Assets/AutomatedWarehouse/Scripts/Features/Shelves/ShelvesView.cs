using System.Collections.Generic;
using UnityEngine;
using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Features.Shelves
{
    public class ShelvesView : MonoBehaviour, IShelvesView
    {
        [SerializeField] private GameObject _shelfPrefab;

        private List<GameObject> _shelves = new();

        public void GenerateView(IEnumerable<ShelfModel> shelves)
        {
            foreach(var shelf in shelves)
            {
                var shelfInstance = Instantiate(_shelfPrefab, transform);
                shelfInstance.name = shelf.Id;
                shelfInstance.transform.position = new Vector3(shelf.Position.X, 0f, shelf.Position.Y);
                shelfInstance.transform.localScale = new Vector3(shelf.Size.Width, 1f, shelf.Size.Length);
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