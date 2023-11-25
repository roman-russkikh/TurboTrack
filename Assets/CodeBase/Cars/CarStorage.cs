using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Cars
{
    [Serializable]
    [CreateAssetMenu(fileName = "CarStorage", menuName = "Static Data/Create car storage")]
    public class CarStorage : ScriptableObject
    {
        [SerializeField] public List<Car> Cars;
        
        public Car GetCarById(int id)
        {
         var car = Cars.FirstOrDefault(i => i.Id == id);
         return car;
        }
    }
}