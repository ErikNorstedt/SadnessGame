using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Transform hinge_;
    public Transform cameraTarget_;
    public float delay_;
    public static bool won = false;
    bool move = false;
    Vector3 targetPos_ = new Vector3(0, 4.6f, 0);

    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        if(move)
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
        won = true;
        AudioManager.stopClock();
        AudioManager.playGoodConversation();
        yield return new WaitForSeconds(delay_);
        move = true;
        cameraTarget_.Rotate(Vector3.up, 180);
    }
}
