using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour{
    public BallController ballController;
    public StartingGame startingGame;
    public PathCreator pathCreator;

    void Update(){
        if((int)pathCreator.path.GetPoint(pathCreator.path.localPoints.Length-1).x == (int)ballController.transform.position.x){
            if(SceneManager.sceneCountInBuildSettings - 1 != SceneManager.GetActiveScene().buildIndex)
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene(0);
            
        }
    }
}
