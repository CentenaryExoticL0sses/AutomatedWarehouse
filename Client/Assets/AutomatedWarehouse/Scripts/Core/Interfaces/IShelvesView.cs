using AutomatedWarehouse.Infrastructure.API.DTO;
using System.Collections.Generic;
using UnityEngine;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IShelvesView
    {
        public void GenerateView(IEnumerable<ShelfData> shelves);

        public void DestroyView();
    }
}