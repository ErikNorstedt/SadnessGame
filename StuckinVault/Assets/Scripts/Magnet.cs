using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float pullForce_;
    public float minDistance_;
    private Rigidbody rb;

    private Rigidbody player_;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("rigidbody missing for magnet with name: " + gameObject.name);
        }
        if (player_ == null)
        {
            Debug.Log("rigidbody missing for player object");
        }
    }
    private void FixedUpdate()
    {

        Attract(player_);
    }
    void Attract(Rigidbody rbToAttract)
    {
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = Vector3.Distance(rb.position, rbToAttract.position);

        float forceMagnitude = pullForce_ * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        if (distance < minDistance_)
        {
            Debug.Log("W");
            rbToAttract.AddForce(force);
        }
        else if (rbToAttract.velocity != Vector3.zero)
        {
            //rbToAttract.velocity = Vector3.zero;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, minDistance_);
    }
}
