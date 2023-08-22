using UnityEngine;

public abstract class AnimalBehavior : MonoBehaviour
{
    [SerializeField] protected IAttacker dameDealer;
    [SerializeField] protected Ihealth receiver;
    [SerializeField] protected IRandomMoving randomMoving;
    [SerializeField] protected IMovable move;
    [SerializeField] protected ProductA product;
    public IAttacker DameDealer { get => dameDealer; set => dameDealer = value; }
    public Ihealth Receiver { get => receiver; set => receiver = value; }
    public IMovable Move { get => move; set => move = value; }
    public ProductA Product { get => product; set => product = value; }
    public IRandomMoving RandomMoving { get => randomMoving; set => randomMoving = value; }


}
