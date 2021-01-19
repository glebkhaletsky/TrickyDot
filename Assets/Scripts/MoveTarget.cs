using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    bool check;
    float speed;
    [SerializeField] int score;
    void Start()
    {
        speed = 0;
        score = FindObjectOfType<PlayerScript>().score;
    }

    
    void Update()
    {
        
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
        if (score >= 10)
        {
            speed = 0.001f;
        }
        if (score >= 20)
        {
            speed = 0.005f;
        }
    }
}
