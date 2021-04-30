using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float fanForce_ = 0.1f;
    public float minDistance_;

    private GameObject player_;
    private Rigidbody playerRb_;

    private void Start()
    {
        player_ = GameObject.FindGameObjectWithTag("Player");

        if (player_ == null)
        {
            Debug.LogError("couldnt find object with tag player");
        }
        playerRb_ = player_.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(Win.won == false)
        {
            Push(player_);
        }
        else
        {
            playerRb_.velocity = Vector3.zero;
        }
    }
    void Push(GameObject objToAttract)
    {
        Vector3 direction = new Vector3(0, 0, -1);
        float distance = Vector3.Distance(transform.position, objToAttract.transform.position);

        float appliedForce = fanForce_ / (1.0f + distance * distance);
        Vector3 force = direction.normalized * appliedForce;
        if (distance < minDistance_)
        {
            playerRb_.AddForce(force);
        }
        else
        {
            playerRb_.velocity = Vector3.zero;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3F);
        Gizmos.DrawSphere(transform.position, minDistance_);
    }
}
