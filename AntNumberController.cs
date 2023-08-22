using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AntNumberController : Singleton<AntNumberController>
{
    
    [SerializeField]  private int numberAnts;
    public int NumberAnts { get; set; }
    private float timing, maxtiming;
    // Start is called before the first frame update
    void Start()
    {
        timing = maxtiming = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timing -= Time.deltaTime;
        if(timing<=0)
        {
            Singleton<PointController>.Instance.PointUpdate(-numberAnts);
            timing = maxtiming;
        }

    
    }
    public void UpdateNumberAnts(int number)
    {
        numberAnts+=number;
    }
}
