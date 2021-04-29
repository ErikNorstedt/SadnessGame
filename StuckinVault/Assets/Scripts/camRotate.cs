using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotate : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;

    private void Start()
    {
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else
        {
            /*turn.y = Mathf.MoveTowards(turn.y, 0, 0.4f);
            turn.x = Mathf.MoveTowards(turn.x, 0, 0.4f);
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);*/
        }
    }
}
