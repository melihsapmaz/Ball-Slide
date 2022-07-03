using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositioning : MonoBehaviour{
    private Vector3 angles;
    void Start(){
        angles = this.gameObject.transform.eulerAngles;
        angles.z = 90.0f;
        angles.y = 90.0f;
        this.gameObject.transform.eulerAngles = angles;
    }
}
