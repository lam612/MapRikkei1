using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int Numberplayer = 1;
    public float Speed = 12f;
    public float turnSpeed = 180f;

    private string movermentAxisName;
    private string turnAxisName;
    private Rigidbody RigidPlayer;

    private float movermentInputValue;
    private float turnInputValue;

    private void Awake()
    {
        RigidPlayer = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        RigidPlayer.isKinematic = false;
        movermentInputValue = 0f;
        turnInputValue = 0f;
    }


    private void OnDisable()
    {
        RigidPlayer.isKinematic = true;
    }


    private void Start()
    {
        movermentAxisName = "Vertical" + Numberplayer;
        turnAxisName = "Horizontal" + Numberplayer;

        //m_OriginalPitch = m_MovementAudio.pitch;
    }


    private void Update()
    {
        movermentInputValue = Input.GetAxis(movermentAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * Speed * movermentInputValue * Time.deltaTime;

        RigidPlayer.MovePosition(transform.position + movement);
    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        RigidPlayer.MoveRotation(transform.rotation * turnRotation);
    }
}
