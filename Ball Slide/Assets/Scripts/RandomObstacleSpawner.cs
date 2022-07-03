using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleSpawner : MonoBehaviour{
    
    [SerializeField] private GameObject obstaclePrefab;
    private float objSize;
    private Vector3 obstaclePos;
    private float i = 0;
    
    void Start(){
        objSize = GetComponent<Renderer>().bounds.size.y/2;
        
        StartCoroutine(SpawnObstacleAtPosition());
    }


    IEnumerator SpawnObstacleAtPosition(){
        yield return new WaitForSeconds(1f);
        Debug.Log(objSize);
        var ballX = GameObject.FindGameObjectWithTag("Ball").transform.position.x;
        i = ballX + 50f;
        obstaclePos = new Vector3(Random.Range(i, ballX + 100f), objSize, Random.Range(-1.687f, 1.687f));
        Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
        
    }
}
