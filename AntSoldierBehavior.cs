using System.Resources;
using UnityEngine;

public class AntSoldierBehavior : AntBehavior
{
    Vector3 enermyPosition;

    private void Start()
    {
        dameDealer = GetComponent<DameDealer>();
        receiver = GetComponent<Receiver>();
        randomMoving = GetComponent<RandomMovingBehavior>();
        move = GetComponent<RandomMovingBehavior>();
        product = GetComponent<ProductA>();
        movingByTheMouseBehavior = GetComponent<MovingByTheMouseBehavior>();
         
    }
    private void Update()
    {
        if (receiver.Health <= 0)
        {
            Singleton<AntNumberController>.Instance.UpdateNumberAnts(-1);
            Destroy(gameObject);
        }
        enermyPosition = FindInCricleZone(gameObject.transform.position, this.Radius);
        // neu dang khong trong trang thai duoc chon!
        if (!this.movingByTheMouseBehavior.Choosing.activeInHierarchy)
        {
            InNonChoosingState();
        }
        // neu kien dang duoc chon
        else
        {
            InChoosingState();
        }
    }
    public override Vector3 FindInCricleZone(Vector3 position, float radius)
    {
        // tim doi tuong tren mot colider hinh tron
        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, radius);
        //tim doi tuong o gan nhat
        for (int i = coliders.Length - 1; i >= 0; i--)
        {
            // kiem tra co phai la enermy khong
            if (coliders[i].tag == "enermy")
            {

                // bat lay component enermy
                Receiver enermy = coliders[i].gameObject.GetComponent<Receiver>();
                if (enermy != null)
                {
                    if (enermy.Health > 0)
                    {
                        ChangingAttackAnimation(ref enermy, coliders[i].gameObject.transform.position);
                        return coliders[i].gameObject.transform.position;
                    }
                    else if (enermy.Health <= 0)
                    {
                        // de cho enermy phat tin hieu 
                        enermy.receiveDamaged(0);


                    }
                }
            }
        }
        return gameObject.transform.position;
    }
    private void ChangingAttackAnimation(ref Receiver enermy, Vector3 position)
    {
        this.dameDealer.AttackSpeedClone -= Time.deltaTime;
        if (this.dameDealer.AttackSpeedClone <= 0)
        {
            if (Vector3.Distance(transform.position, position) <= this.dameDealer.AttackRange)
            {
                enermy.receiveDamaged(this.dameDealer.Damaged());
                this.dameDealer.AttackSpeedClone = this.dameDealer.AttackSpeed;
            }

        }
        Debug.Log("nhan dame duoc roi");
    }
    private void InNonChoosingState()
    {
        // di chuyen ngau nhien khi khong tim thay enermy
        if (enermyPosition == transform.position)
        {
            this.randomMoving.RandomMoving(transform);
        }
        // tim thay enermy
        else
        {
            // di chuyen toi enermy
            this.move.movingAndLooking(enermyPosition, transform);
        }
        // chon tat ca kien
        SelectAll();
    }
    private void InChoosingState()
    {
        // tat trang thai chon
        this.movingByTheMouseBehavior.MovingByMouse(transform);
    }
    private void SelectAll()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.movingByTheMouseBehavior.Choosing.SetActive(true);
                this.movingByTheMouseBehavior.MovingByMouse(transform);

            }
        }
    }
}