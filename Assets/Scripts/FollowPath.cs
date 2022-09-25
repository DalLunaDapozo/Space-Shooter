using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private Transform[] waypoints;
   
    private int waypointIndex = 0;

    private void Start() {

        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update() {

        Move();
    }

    private void Move() {

        if (waypointIndex <= waypoints.Length - 1)
        {

            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
                                 moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {

                waypointIndex += 1;

            }
        }
        else return;
    }

}
