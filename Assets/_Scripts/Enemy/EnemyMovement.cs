using UnityEngine;


public class EnemyMovement : DinoBehaviourScript
{
    [SerializeField] protected Transform homePoint;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float distance;
    [SerializeField] protected int distanceMax = 5;
    [SerializeField] protected float moveTime = 2f;
    [SerializeField] protected float moveTimeCounter = 0f;
    [SerializeField] protected bool isMoving;
    private Vector2 wayPoint;
    public bool IsMoving => isMoving;
    protected override void Start()
    {
        this.SetNewDestination();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHomePoint();
    }
    protected void LoadHomePoint()
    {
        if (this.homePoint != null) return;
        this.homePoint = GameObject.Find("HomePoint").transform;
        Debug.Log(transform.name + ": LoadHomePoint", gameObject);
    }
    void Update()
    {
        this.Moving();
        this.FlipDirect();
        this.StopMoving();
    }
    protected void Moving()
    {
        this.isMoving = true;
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, this.wayPoint,
        this.speed * Time.deltaTime);
    }
    protected void StopMoving()
    {
        this.distance = Vector2.Distance(transform.parent.position, this.wayPoint);
        if (this.distance < 0.5f)
        {
            this.isMoving = false;
            this.moveTimeCounter += Time.deltaTime;
            if (this.moveTimeCounter < this.moveTime) return;
            this.moveTimeCounter = 0;
            this.SetNewDestination();

        }
    }
    protected void SetNewDestination()
    {
        Vector2 homePosition = (Vector2)homePoint.position;
        this.wayPoint = homePosition + new Vector2(
            Random.Range(-this.distanceMax, this.distanceMax),
            Random.Range(-this.distanceMax, this.distanceMax)
        );
    }
    protected void FlipDirect()
    {
        float direction = wayPoint.x - transform.parent.position.x;

        if (direction >= 0)
            transform.parent.localScale = new Vector3(1, 1, 1);
        else
            transform.parent.localScale = new Vector3(-1, 1, 1);
    }
}
