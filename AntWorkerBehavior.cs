using JetBrains.Annotations;
using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;
using static UnityEngine.GraphicsBuffer;


public class AntWorkerBehavior : AntBehavior
{
    [SerializeField] private bool isPredators;
    [SerializeField] private int foodStorage, foodBring;
    [SerializeField] private Vector3 foodPAim;
    [SerializeField] private GameObject havingFood;
    [SerializeField] private bool isGoHome = false;
    [SerializeField] private bool isFindingFood = false;
    [SerializeField] private Vector3 homePosition;

    private void Start()
    {
        homePosition = Singleton<QueenSignaling>.Instance.HomePosition;
        dameDealer = GetComponent<DameDealer>();
        receiver = GetComponent<Receiver>();
        randomMoving = GetComponent<RandomMovingBehavior>();
        move = GetComponent<RandomMovingBehavior>();
        product = GetComponent<ProductA>();
        movingByTheMouseBehavior = GetComponent<MovingByTheMouseBehavior>();
        Singleton<QueenSignaling>.Instance.enermyDeadSignal += BringFoodToHome;
    }
    public Vector3 HomePosition { get => homePosition; set => homePosition = value; }

    public void BringFoodToHome(Vector3 food)
    {
        if (isPredators == false)
        {
            Vector3 foodP = food;
            isPredators = true;
            foodPAim = foodP;
        }
        // busy now!
    }
  
    private void Update()
    {
        if (this.movingByTheMouseBehavior.Choosing.activeInHierarchy)
        {
            this.movingByTheMouseBehavior.MovingByMouse(transform);
        }
        else
        {
            if (this.receiver.Health <= 0)
            {
                Singleton<AntNumberController>.Instance.UpdateNumberAnts(-1);
                Destroy(gameObject);
            }
            if (isPredators)
            {

                if (transform.position != foodPAim)
                {
                    move.movingAndLooking(foodPAim, transform);
                }
                else
                {
                    if (isFindingFood == false)
                    {
                        FindInCricleZone(transform.position, this.Radius);
                    }
                    if (this.isGoHome == true)
                    {
                        foodPAim = Singleton<QueenSignaling>.Instance.HomePosition;
                    }
                    if (transform.position == Singleton<QueenSignaling>.Instance.HomePosition)
                    {
                        isPredators = false;
                        isFindingFood = false;
                        isGoHome = false;
                        havingFood.SetActive(false);
                        Singleton<PointController>.Instance.PointUpdate(foodBring);
                    }
                }
            }
            else
            {
                randomMoving.RandomMoving(transform);
            }
        }
    }
    IEnumerator WaitingStime(float s)
    {
        yield return new WaitForSeconds(s);
        isGoHome = true;
    }
    public override Vector3 FindInCricleZone(Vector3 position, float radius)
    {
        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int i = coliders.Length - 1; i >= 0; i--)
        {
            if (coliders[i].tag == "enermy")
            {
                EnermyBehavior enermy = coliders[i].gameObject.GetComponent<EnermyBehavior>();
                if (enermy != null)
                {
                    isFindingFood = true;
                    StartCoroutine(WaitingStime(1f));
                    havingFood.SetActive(true);
                    if (enermy.Receiver.Health <= 0)
                    {
                        if (enermy.Product.ValuePoint > foodStorage)
                        {
                            enermy.Product.ValuePoint -= foodStorage;
                            foodBring = foodStorage;
                        }
                        else
                        {
                            foodBring = enermy.Product.ValuePoint;
                            enermy.Product.ValuePoint = 0;
                        }
                    }
                }
            }
        }
        return transform.position;
    }
}