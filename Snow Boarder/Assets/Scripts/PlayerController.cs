using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float boostSpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float torqueAmount =1;
    SurfaceEffector2D _se2d;
    Rigidbody2D _rb2d;
    bool _canMove=true;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_canMove)
        {
            PlayerRotate();
            RespondToBoost();
        }
        

    }

    public void DisableControls()
    {
        _canMove = false;
    }
    public void ActiveControls()
    {
        _canMove = true;
    }

    private void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _se2d.speed = boostSpeed;
        }
        else
        {
            _se2d.speed = normalSpeed;
        }
    }

    private void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb2d.AddTorque(torqueAmount);

        }
        else if (Input.GetKey(KeyCode.D)) //if yerine else if kullanildiðinda iki isi ayný anda yapamamasýný sagliyor
        {
            _rb2d.AddTorque(-torqueAmount);

        }
    }
}
