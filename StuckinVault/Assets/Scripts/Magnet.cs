using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float pullForce_ = 0.1f;
    public float minDistance_;

    private float currentPull_;

    
    private GameObject player_;
    [HideInInspector]
    public bool isPulling_ = false;
    private bool decreasedPull_ = false;

   

    private void Start()
    {
        currentPull_ = pullForce_;
        player_ = GameObject.FindGameObjectWithTag("Player");
        
        if (player_ == null)
        {
            Debug.LogError("couldnt find object with tag player");
        }
       


    }
    private void FixedUpdate()
    {
        Attract(player_);
    }
    void Attract(GameObject objToAttract)
    {
        float distance = Vector3.Distance(transform.position, objToAttract.transform.position);

        if (distance < minDistance_)
        {
            if(isPulling_ == false)
                player_.GetComponent<simpleMove>().changeState();
            isPulling_ = true;
            objToAttract.transform.position = Vector3.MoveTowards(objToAttract.transform.position, transform.position, currentPull_ * Time.deltaTime);
        }
        else
        {
            if (isPulling_ == true)
            {
                player_.GetComponent<simpleMove>().changeState();
                isPulling_ = false;
            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (decreasedPull_ == false)
            {
                
                currentPull_ = pullForce_ / 2;
            }
        }
        
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, minDistance_);
    }

}
