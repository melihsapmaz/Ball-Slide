using UnityEngine;

namespace PathCreation.Examples{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class camFollow : MonoBehaviour
    {
        public BallController ballController;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if(!StartingGame.isGameStarted)
                return;
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = new Vector3(-5,3,0) + pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                var x = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                x.y = transform.rotation.eulerAngles.y + ballController.ballP.z;
                x.z = 0;
                transform.rotation = x;
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}
