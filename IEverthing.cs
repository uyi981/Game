using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public interface IMovable
{
    public int MoveSpeed { get; set; }
    public float OffSetDeg { get; set; }

    public void movingAndLooking(Vector3 target,  Transform transformObject);
    public void Moving(Vector3 target,  Transform transformObject);


}
public interface IRandomMoving
{
    public void RandomMoving( Transform transformClone);
}
public interface IMouseMovavable
{

    public Vector3 MousePosition{ get; set; }
    public GameObject Choosing { get; set; }
    public Vector3 Target { get; set; }
    public void MovingByMouse( Transform transformClone);

}

public interface Ihealth
{
    public float Health { get; set; }
    public void receiveDamaged(float dame);
}
public interface IAttacker
{
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }
    public float AttackSpeedClone { get; set; }
    public float Dame { get; set; }
    public float Damaged(); 
}

public interface IProduct
{
    public string ProductName { get; set; }
    public void Initialize();
}
public interface IfindEnermy
{
    public float Radius { get; set; }
    public Vector3 FindInCricleZone(Vector3 position,float radius);
}
public interface Ivalue
{
    public int ValuePoint { get; set; }
}
public interface IPredators
{
    public Vector3 HomePosition{ get; set; }
    public void BringFoodToHome(Vector3 food);
}
