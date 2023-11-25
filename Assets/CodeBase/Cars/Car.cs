using System;
using UnityEngine;

[Serializable]
public class Car
{
    [SerializeField] public int Id;
    [SerializeField] public Sprite Sprite;
    [SerializeField] public int Cost;
    [SerializeField] public string Name;
    [SerializeField] public int Velocity;
    [SerializeField] public int MaxSpeed;
    [SerializeField] public int MaxLives;
    [SerializeField] public int Control;
}
