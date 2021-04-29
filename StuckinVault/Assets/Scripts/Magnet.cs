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

    private int segments_ = 20;
    LineRenderer line_;

    private void Start()
    {
        currentPull_ = pullForce_;
        player_ = GameObject.FindGameObjectWithTag("Player");
        
        if (player_ == null)
        {
            Debug.LogError("couldnt find object with tag player");
        }
        line_ = GetComponent<LineRenderer>();
        line_.positionCount = segments_ + 1;
        line_.useWorldSpace = false;
        createPoints();


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
    void createPoints()
    {
        float x;
        float y = -0.2f;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments_ + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * minDistance_;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * minDistance_;

            line_.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments_);
        }
    }


}
