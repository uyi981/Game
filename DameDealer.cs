using UnityEngine;

public class DameDealer : MonoBehaviour ,IAttacker
{
    [SerializeField] protected float dame;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackSpeedClone;
    public float Dame { get => dame; set => dame = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float AttackSpeedClone { get => attackSpeedClone; set => attackSpeedClone = value; }

    public float Damaged()
    {
        return dame;
    }
}
