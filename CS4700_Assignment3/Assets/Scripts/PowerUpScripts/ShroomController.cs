using UnityEngine;

public class ShroomController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float _speed = 1.0f;
    Rigidbody2D _powerRigidBody;
    [SerializeField] private PowerState _power = PowerState.Mushroom;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _powerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    //Move goomba the the left side of the screen
    void moveLeft()
    {
        //transform.position = transform.position - (new Vector3(speed, 0, 0) * Time.deltaTime);
        //enemy_rigidBody.AddForce(new Vector2 (0, 0));

        _powerRigidBody.linearVelocity = new Vector2(-_speed, _powerRigidBody.linearVelocityY);
    }
    //Move goomba the the right side of the screen
    void moveRight()
    {
        _powerRigidBody.linearVelocity = new Vector2(_speed, _powerRigidBody.linearVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().setPower(_power);
            Destroy(gameObject);
            
            print("test");
        }

    }

}
