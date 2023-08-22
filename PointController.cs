using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointController : Singleton<PointController>
{
    // Start is called before the first frame update
    [SerializeField] private int point;
    [SerializeField] private GameObject textOwner;
    [SerializeField] private TextMeshProUGUI textPoint;
    public int Point { get => point; set => point = value; }

    void Start()
    {
        textOwner = GameObject.Find("TextPoint");
        textPoint = textOwner.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textPoint.text= "Point: "+this.point;
    }
    public void PointUpdate(int pointAdd)
    {
        this.point += pointAdd;
    }
}
