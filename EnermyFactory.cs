using UnityEngine;

public class EnermyFactory : Factory
{
    [SerializeField] private float time, timeStart;
    private void Start()
    {
        InvokeRepeating("Spawning", timeStart, time);
    }
    public void Spawning()
    {
        Vector3 ranPosition = new Vector3(Random.Range(minRandomValue, maxRandomValue), Random.Range(minRandomValue,maxRandomValue), transform.position.z);
        int type = Random.Range(0, productPrefab.Length);
        GetProduct(ranPosition, type);
    }
    public override IProduct GetProduct(Vector3 position, int type)
    {
        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(productPrefab[type].gameObject,
        position, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();
        // each product contains its own logic
        newProduct.Initialize();
        return newProduct;
    }
}
