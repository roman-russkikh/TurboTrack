using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Cars
{
    [Serializable]
    [CreateAssetMenu(fileName = "CarStorage", menuName = "Static Data/Create car storage")]
    public class CarStorage : ScriptableObject
    {
        [SerializeField] public List<Car> Cars;
    }
}