using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour{
    public Rigidbody rb;
    public float maxSpeed = 2;
    private GameObject go;
    [SerializeField] private float ballSlideSpeed = 1.0f;
    [SerializeField] private float ballSpeed = 1.0f;
    public float ballSize;
    public Vector3 ballP, moveP;
    void Start(){
        ballSize = GetComponent<Renderer>().bounds.size.y/2;
    }
    void Update () {
        if(!StartingGame.isGameStarted)
            return;
        GetComponent<Rigidbody>().useGravity = true;
        if(rb.velocity.magnitude > maxSpeed){
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            moveP = MoveBall(touch.position);
        }
    }
    public Vector3 MoveBall(Vector2 touchPos){
        if(StartingGame.isFirstTouch){
            StartingGame.isFirstTouch = false;
            touchPos.x = 0;
        } 
        else{
            if(touchPos.x < Screen.width/2){
                ballP.z += ballSlideSpeed;
            }
            else{
                ballP.z -= ballSlideSpeed;
            }
        }    
        
        return ballP;
    }
    public void OnTriggerStay(Collider other){
        Debug.Log(other.gameObject.name);
    }
}
