using UnityEngine;

public class MovingByTheMouseBehavior : MonoBehaviour, IMovable, IMouseMovavable
{
    [SerializeField] public GameObject choosing;
    [SerializeField] protected Vector3 target;
    [SerializeField] protected Vector3 mousePosition;
    [SerializeField] protected Camera mainCam;
    //
    [SerializeField] protected int speed;
    [SerializeField] protected float offSetDeg;

    // IMovable
    public int MoveSpeed { get => speed; set => speed = value; }
    public float OffSetDeg { get => offSetDeg; set => offSetDeg = value; }
    //IMouseMovavable
    public Vector3 MousePosition { get => mousePosition; set => mousePosition = value; }
    public GameObject Choosing { get => choosing; set => choosing = value; }
    public Vector3 Target { get => target; set => target = value; }

    private void Start()
    {
        MoveSpeed = gameObject.GetComponent<RandomMovingBehavior>().MoveSpeed;
        offSetDeg = gameObject.GetComponent<RandomMovingBehavior>().OffSetDeg;
        mainCam = Camera.main;
        target = gameObject.transform.position;
    }
    public void MovingByMouse(Transform transformObject)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Choosing.SetActive(false);
        }
        // kien dang duoc chon

        if (Input.GetMouseButtonDown(0))
        {
            GetMousePosition();
        }
        // lay vi tri chuot       
        // di theo chuot
        MovingToTarget(target, Vector3.zero, transformObject);
    }
    public void movingAndLooking(Vector3 target, Transform transformObject)
    {
        Moving(target, transformObject);
        transformObject.rotation = VoHauUsedFullMethods.LookAt(target, transformObject.position, offSetDeg);
    }
    public void Moving(Vector3 target, Transform transformObject)
    {

        transformObject.position = Vector3.MoveTowards(transformObject.position, target, Time.deltaTime * MoveSpeed);

    }
    private void OnMouseDown()
    {
        Choosing.SetActive(true);
    }
    public Vector3 MovingDirected()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 target = hit.point;
            target.z = 0;
            return target;
        }
        return Vector3.zero;
    }
    private void GetMousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // lay toa do mousePosition
            mousePosition = Input.mousePosition;
            target = MovingDirected();
        }
    }
    private void MovingToTarget(Vector3 target, Vector3 targetCondition, Transform transformObject)
    {
        if (target != targetCondition)
        {
            if (transformObject.position != target)
            {
                movingAndLooking(target, transformObject);
            }
        }
    }
}
