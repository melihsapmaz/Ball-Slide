using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour{
    public Vector3 ballPos;
    public float duration;
    void Start(){
        duration = 1.0f;
    }

    void LateUpdate(){
        ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position;
        ballPos.y += 1.2f;
        ballPos.x -= 4.5f;
        transform.position = ballPos;
        float time = 0;
        while(time < duration){
            transform.position = Vector3.Lerp(transform.position, ballPos, time/duration);
            time += Time.deltaTime;
        }
    }
}
