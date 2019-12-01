using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if ((transform.position.x == targetPosition.x) && (transform.position.y == targetPosition.y))
            {

                waypointIndex++;

            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

//if not yet reached last waypoint then...
//  MoveTowards() target waypoint
//  check if we've reached the target
//    if so, increment target waypoint

//if have reached last waypoint
//  Destroy enemy gameObject