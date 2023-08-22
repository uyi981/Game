using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Factory : MonoBehaviour 

{
    [SerializeField] protected Vector3 offset;
    [SerializeField] protected int type;
    [SerializeField] protected float minRandomValue, maxRandomValue;
    [SerializeField] protected ProductA[] productPrefab;

    private void Start()
    {
      
    }

    public abstract IProduct GetProduct(Vector3 position, int type);

}
