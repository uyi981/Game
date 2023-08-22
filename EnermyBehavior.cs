using UnityEngine;

public abstract class EnermyBehavior : AnimalBehavior, IfindEnermy
{
    [SerializeField] protected float radius;
    public float Radius { get => radius; set => radius = value; }
    public abstract Vector3 FindInCricleZone(Vector3 position, float radius);
}
