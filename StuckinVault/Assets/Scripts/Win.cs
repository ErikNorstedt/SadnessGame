using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Transform hinge_;
    public Transform cameraTarget_;
    public float delay_;
    bool won = false;
    Vector3 targetPos_ = new Vector3(0, 4.6f, 0);

    simpleMove movescript_;
    
    void Start()
    {
        movescript_ = GameObject.FindGameObjectWithTag("Player").GetComponent<simpleMove>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(won)
        {
            if(cameraTarget_.position != targetPos_)
            {
                cameraTarget_.position = Vector3.MoveTowards(cameraTarget_.position, targetPos_, 0.5f);
                
            }
            else if (hinge_.rotation.eulerAngles.y > 280)
            {

                openDoor();
            }
        }
    }
    
    void openDoor()
    {
        hinge_.Rotate(Vector3.left * 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(delayed());
        }
    }

    IEnumerator delayed()
    {
        yield return new WaitForSeconds(delay_);
        won = true;
        movescript_.enabled = false;
        cameraTarget_.Rotate(Vector3.up, 180);
    }
}
