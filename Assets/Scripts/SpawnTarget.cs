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

    public void Start()
    {       
        StartCoroutine(SpawnCD());       
    }

    private void Update()
    {
        
    }

    public void targetSpawn()
    {
        StartCoroutine(SpawnCD());        
    }

    public IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(0f);
        Instantiate(Target, new Vector2(Random.Range(-2.26f,2.26f),2.25f), Quaternion.identity);
    }
}
