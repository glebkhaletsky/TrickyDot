using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPlum : MonoBehaviour
{
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, 2f), 0.25f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, -3f), 0.25f);
        }
        if (transform.position.y >= 2f)
        {
            check = false;
        }
        if (transform.position.y <= -3)
        {
            check = true; 
        }

    }
}
