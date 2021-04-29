using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour
{
    enum state
    {
        NOTSTUCK,
        STUCK,
    }

    state currentState_ = state.NOTSTUCK;
    public float speed_;
    private float xDir_;
    private float zDir_;

    Vector3 lastDir_ = Vector3.right;
    private void Start()
    {

    }

    private void Update()
    {
        xDir_ = Input.GetAxis("Horizontal");
        zDir_ = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir_, 0, zDir_);
        if (moveDir.x != 0 && moveDir.z != 0)
        {
            lastDir_ = moveDir;
        }
        
        switch (currentState_)
        {
            case state.NOTSTUCK:
                //Debug.Log("notstuck");
                nonStuckMove(moveDir);
                break;
            case state.STUCK:
                stuckMove(lastDir_);
                break;
        }
        //rotatePlayer();
    }
    public float stuckMultiplier = 10;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    private void nonStuckMove(Vector3 dir)
    {
        dir.Normalize();
        if (dir.magnitude >= 0.1f)
        {
           
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            if(dir.z > -0.5)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            Debug.Log(moveDirection);
            transform.position += moveDirection * speed_ * Time.deltaTime;
        }
        
    }
    private void stuckMove(Vector3 dir)
    {
        dir.Normalize();
        if (pressedMoveKey())
        {
            if (dir.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                if (dir.z > -0.5)
                {
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                transform.position += moveDirection * stuckMultiplier * Time.deltaTime;
            }
            
        }
    }

    public void changeState()
    {
        if(currentState_ == state.STUCK)
        {
            currentState_ = state.NOTSTUCK;
        }else{
            currentState_ = state.STUCK;
        }
    }

    private bool pressedMoveKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }
}

