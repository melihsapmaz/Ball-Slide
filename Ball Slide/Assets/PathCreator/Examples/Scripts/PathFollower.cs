using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public BallController ballController;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5, speedZ = 1.0f;
        float distanceTravelled;
        public float moveZ;
        public Vector3 MoveVector;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
                //moveZ = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction).z;
            }
        }

        void Update(){
            if(!StartingGame.isGameStarted)
                return;
            if (pathCreator != null){
                distanceTravelled += speed * Time.deltaTime;
                //moveZ = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction).z;
                moveZ = ballController.moveP.z * speedZ;
                moveZ = Mathf.Clamp(moveZ, -30f, 30f);
                var moveX = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction).x;
                var moveY = ballController.ballSize + pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction).y;
                MoveVector = new Vector3(moveX, moveY, 0);
                //transform.position = MoveVector;
                ballController.rb.AddForce(MoveVector*speed);
                ballController.rb.AddForce(new Vector3(0,0,moveZ));
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
    
}