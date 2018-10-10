using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float smoothTime = 0.1f;

    private Vector3 velocity_Cam;
    private Vector3 maxDistance;
    private Vector3 curPos;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maxDistance = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void FindPosition()
    {
        Vector3 averagePos = new Vector3();
        averagePos += player.transform.position + maxDistance;
        averagePos.y = transform.position.y;

        curPos = averagePos;
    }

    private void Move()
    {
        FindPosition();
        transform.position = Vector3.SmoothDamp(transform.position, curPos, ref velocity_Cam, smoothTime);
    }

}
