
using UnityEngine;
public class RandomMovingBehavior : MonoBehaviour, IMovable,IRandomMoving
{
    [SerializeField] protected Vector3 oldPositon;
    [SerializeField] protected int randomZone;
    //
    [SerializeField] protected float offSetDeg;
    [SerializeField] protected int speed;
    public int MoveSpeed { get => speed; set => speed = value; }

    public float OffSetDeg { get => offSetDeg; set => offSetDeg = value; }

    public void RandomMoving(Transform transformObject)
    {
        Vector3 RandomPosition = VoHauUsedFullMethods.RamdomPosition(-randomZone, randomZone, transformObject.position.z) + transformObject.position;
            if (transformObject.position != oldPositon)
            {
                movingAndLooking(oldPositon,transformObject);
            }
            else
            {
                oldPositon = RandomPosition;
            }
    }
    
    public void movingAndLooking(Vector3 target, Transform transformObject)
    {
        Moving(target,transformObject);
        transformObject.rotation = VoHauUsedFullMethods.LookAt(target,transformObject.position, offSetDeg);
    }
    public void Moving(Vector3 target, Transform transformObject)
    {
       
        transformObject.position = Vector3.MoveTowards(transformObject.position, target, Time.deltaTime * MoveSpeed);
    }
    private void Start()
    {
        oldPositon = gameObject.transform.position;
    }
}

