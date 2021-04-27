using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour
{
    public float speed_;
    private float xDir_;
    private float zDir_;
    private void Start()
    {
    }

    private void Update()
    {
        xDir_ = Input.GetAxis("Horizontal");
        zDir_ = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir_, 0, zDir_);
        transform.position += moveDir * speed_ * Time.deltaTime;
    }
}
