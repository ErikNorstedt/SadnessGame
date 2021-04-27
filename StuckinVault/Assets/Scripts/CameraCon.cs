using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform camTarget_;
    public float posLerp = .02f;
    public float rotLerp = .01f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget_.position, posLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget_.rotation, rotLerp);
    }
}
