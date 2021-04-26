using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour
{
    public float speed_;
    public float maxSpeed_;

    private float xDir_;
    private float zDir_;
    private Rigidbody rb_;
    private void Start()
    {
        rb_ = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xDir_ = Input.GetAxis("Horizontal");
        zDir_ = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(xDir_, 0, zDir_);

        rb_.AddForce(moveDir * speed_);
        if(xDir_ == 0)
        {
            rb_.velocity = new Vector3(Mathf.MoveTowards(rb_.velocity.x, 0, 0.6f), 0, rb_.velocity.z);
        }
        if (zDir_ == 0)
        {
            rb_.velocity = new Vector3(rb_.velocity.x, 0, Mathf.MoveTowards(rb_.velocity.z, 0, 0.6f));
        }
    }
}
