using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Core.Models;
using System.Collections.Generic;
using UnityEngine;

namespace AutomatedWarehouse.Features.Robots
{
    public class RobotsController : MonoBehaviour, IRobotsController
    {
        [SerializeField] private GameObject _robotPrefab;

        private List<GameObject> _robots = new();

        public void DisplayView(IEnumerable<RobotModel> shelves)
        {
            foreach (var shelf in shelves)
            {
                var shelfInstance = Instantiate(_robotPrefab, transform);
                shelfInstance.name = shelf.Id;
                shelfInstance.transform.position = new Vector3(shelf.Position.X, 0f, shelf.Position.Y);
                _robots.Add(shelfInstance);
            }
        }

        public void HideView()
        {
            foreach (var shelf in _robots)
            {
                Destroy(shelf);
            }
            _robots.Clear();
        }
    }
}
