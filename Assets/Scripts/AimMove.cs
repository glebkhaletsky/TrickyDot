using UnityEngine;

public class AimMove : MonoBehaviour
{
    bool check;
    [SerializeField]bool stop;
    float speed;
    void Start()
    {
        check = false;
        stop = false;
        speed = 0.1f;
    }

    void  FixedUpdate()
    {
        if (stop == true)
        {
            speed=0f;
        }
        else
        {
            speed = 0.15f;
        }
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(-2.46f,2.89f), speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(2.46f, 2.89f), speed);
        }
        if (transform.position.x <= -2.46f)
        {
            check = false;
        }
        if (transform.position.x >= 2.46f)
        {
            check = true; ;
        }
    }
    public void stopMove()
    {
        stop = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stop = false;
        }
    }
}
