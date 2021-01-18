using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    [SerializeField]
    Transform SpawnPosLeft;
    [SerializeField]
    Transform SpawnPosRight;
    Transform RandomPos;
    float rndpos;
 

    public void Start()
    {
       
        StartCoroutine(SpawnCD());       
    }

    private void Update()
    {
        rndpos = Random.Range(0, 3);
        if (rndpos < 1)
        {
            RandomPos = SpawnPosLeft;
        }
        if (rndpos >= 1)
        {
            RandomPos = SpawnPosRight;
        }
    }

    public void targetSpawn()
    {
        StartCoroutine(SpawnCD());        
    }

    public IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(0f);
        Instantiate(Target, /*RandomPos.transform.position*/ new Vector3(0, 2.81f, 0), Quaternion.identity);
        
    }
}
