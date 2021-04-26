using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour
{
    public float speed_;
    public float maxSpeed_;

    private Rigidbody rb_;
    private void Start()
    {
        rb_ = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb_.velocity.magnitude >= maxSpeed_)
            return;

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0, zDir);

        rb_.AddForce(moveDir * speed_);
    }
}
