using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : UnityEngine.MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float moveSpeedScreen = 0.01f;
    [SerializeField] private float horizontalInput, verticalInput;
    [SerializeField] private Vector3 mouseDirection;
    private float mouseScrollDelta;
    [SerializeField] private float mouseScrollSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);
        mouseScrollDelta = Input.mouseScrollDelta.y;
        transform.Translate(Vector3.forward * mouseScrollDelta * Time.deltaTime * mouseScrollSpeed);
        if(Input.GetMouseButtonDown(0))
        {
            mouseDirection = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - mouseDirection;
            transform.Translate(-delta.x*moveSpeedScreen*Time.deltaTime,-delta.y*moveSpeedScreen* Time.deltaTime,0);
        }
    }
}
