using UnityEngine;

public class Receiver : MonoBehaviour, Ihealth
{
    [SerializeField] protected float health;
    public float Health { get => health; set => health = value; }

    public void receiveDamaged(float dame)
    {
        if (this.Health > 0)
        {
            this.Health -= dame;
        }
    }
}
