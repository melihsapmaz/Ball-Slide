using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class StartingGame : MonoBehaviour
{
    public static bool isGameStarted;
    public static bool isFirstTouch;
    void Start(){
        isGameStarted = false;
    }

    void Update(){
        if(Input.touchCount > 0){
            Touch touch;
            touch = Input.GetTouch(0);
            touch.position = new Vector2(0,0);
            isGameStarted = true;
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
