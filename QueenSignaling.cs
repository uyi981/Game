using System.Collections.Generic;
using UnityEngine;

public class QueenSignaling : Singleton<QueenSignaling>
{
    [SerializeField] Vector3 homePosition;
    [SerializeField] public Vector3 HomePosition { get=>homePosition; set => homePosition= value; }
    [SerializeField] public List<Vector3> FoodPositionSignal = new List<Vector3>();
    [SerializeField] public delegate void Dead(Vector3 food);
    [SerializeField] public event Dead enermyDeadSignal;
    public void DeadEnermyFound(Vector3 foodPosition)
    {
        if(!FoodPositionSignal.Contains(foodPosition))
        {
            FoodPositionSignal.Add(foodPosition);
        }
        enermyDeadSignal?.Invoke(foodPosition);

    }    
    public void RemoveOldPosition(Vector3 oldPostion)
    {
        if(FoodPositionSignal!=null)
        {
          if( FoodPositionSignal.Contains(oldPostion))
            {
                FoodPositionSignal.Remove(oldPostion);
            }

        }   
    }
    private void Start()
    {
        homePosition = transform.position;
    }
    
}