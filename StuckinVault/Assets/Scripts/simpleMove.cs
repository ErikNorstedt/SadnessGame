using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour
{
    public float speed_;
    private void Start()
    {

    }

    private void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0, zDir);

        transform.position += moveDir * speed_;
    }
}
