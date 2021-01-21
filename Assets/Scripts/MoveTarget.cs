using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    bool check;
    [SerializeField] float speed;
    [SerializeField] int score;
    int R;
    void Start()
    {
        R = Random.Range(0, 2);
        if (R <= 1)
        {
            check = true;
        }
        if (R >= 1)
        {
            check = false;
        }
        speed = 0;
        score = FindObjectOfType<PlayerScript>().score;
    }

    
    void Update()
    {
        speed = score * 0.0001f;
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(-2.46f, 2.25f), speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(2.46f, 2.25f), speed);
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
}
