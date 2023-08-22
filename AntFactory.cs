using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntFactory:Factory
{
    private void Start()
    {
   
    }

    public void Spawning(int type)
    {
        if (Singleton<PointController>.Instance.Point <= productPrefab[type].ValuePoint)
        {
            Debug.Log("khong du thuc pham!");
        }
        else
        {
            // Create a 1 random position for make creating ant became more cool
            offset = new Vector3(Random.Range(minRandomValue, maxRandomValue), Random.Range(minRandomValue, maxRandomValue), transform.position.z);
            // decreasing point when create!
            Debug.Log(-productPrefab[type].ValuePoint);
            Singleton<PointController>.Instance.PointUpdate(-productPrefab[type].ValuePoint);
            GetProduct(transform.position + offset,type);
        }
    }
    public override IProduct GetProduct(Vector3 position, int type)
    {
        Debug.Log(type);
        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(productPrefab[type].gameObject,
        position, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();
        // each product contains its own logic
        newProduct.Initialize();
        Singleton<AntNumberController>.Instance.UpdateNumberAnts(1);
        return newProduct;
    }
}
