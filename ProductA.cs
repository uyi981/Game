using UnityEngine;

public class ProductA : UnityEngine.MonoBehaviour, IProduct,Ivalue
{
    [SerializeField] private string productName = "ProductA";
    [SerializeField] private int valuePoint;
    [SerializeField] private ParticleSystem spawnEffect;
    public string ProductName
    {
        get => productName; set => productName = value;
    }
    public int ValuePoint { get => valuePoint; set => valuePoint = value; }
    public void Initialize()
    {
       
        // any unique logic to this product
        gameObject.name = productName;
        GameObject.Instantiate(spawnEffect, transform.position, Quaternion.identity);
        spawnEffect?.Stop();
        spawnEffect?.Play();
    }
}
