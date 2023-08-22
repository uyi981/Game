using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class EnermySoldierBehavior : EnermyBehavior
{

    public override Vector3 FindInCricleZone(Vector3 position, float radius)
    {

        // tim doi tuong tren mot colider hinh tron
        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, radius);
        //tim doi tuong o gan nhat
        for (int i = coliders.Length - 1; i >= 0; i--)
        {
            // kiem tra co phai la enermy khong
            if (coliders[i].tag == "Player")
            {

                // bat lay component enermy
                Receiver enermy = coliders[i].gameObject.GetComponent<Receiver>();
                if (enermy != null)
                {
                    if (enermy.Health >= 0)
                    {
                        ChangingAttackAnimation(ref enermy );
                        return coliders[i].gameObject.transform.position;
                    }
                    else if (enermy.Health <= 0)
                    {
                    }
                }
            }
        }
        return gameObject.transform.position;
    }
    private void Start()
    {
        dameDealer = GetComponent<DameDealer>();
        receiver = GetComponent<Receiver>();
        randomMoving = GetComponent<RandomMovingBehavior>();
        move = GetComponent<RandomMovingBehavior>();
        product = GetComponent<ProductA>();
    }
    private void Update()
    {
         if (this.receiver.Health <= 0)
        {
            this.Move.MoveSpeed = 0;

            if (this.product.ValuePoint <= 0)
            {
                Singleton<QueenSignaling>.Instance.RemoveOldPosition(transform.position);
                Destroy(gameObject);
            }
        }
        if (this.product.ValuePoint > 0 && this.receiver.Health <= 0)
        {
            Singleton<QueenSignaling>.Instance.DeadEnermyFound(transform.position);
            Debug.Log("Phat tin hieu da tim thay thuc an!");
        }

        // tim cac doi tuong player de di chuyen den va tan cong!
        Vector3 target = FindInCricleZone(transform.position, this.Radius);
        // neu khong tim thay player thi di chuyen ngau nhien
        if (target == transform.position)
        {
            this.randomMoving.RandomMoving(transform);
        }
        // tim thay player
        else
        {
            // di chuyen toi player

            this.Move.movingAndLooking(target, transform);
        }
        // ket thuc
    }
    private void ChangingAttackAnimation(ref Receiver enermy)
    {
        this.dameDealer.AttackSpeedClone -= Time.deltaTime;
        if (this.dameDealer.AttackSpeedClone <= 0)
        {
            if (Vector3.Distance(transform.position, enermy.gameObject.transform.position) <= this.dameDealer.AttackRange)
            {
                enermy.receiveDamaged(this.dameDealer.Damaged());
                Debug.Log("tan cong thanh cong!");
                this.dameDealer.AttackSpeedClone = this.dameDealer.AttackSpeed;
            }

        }
    }
}