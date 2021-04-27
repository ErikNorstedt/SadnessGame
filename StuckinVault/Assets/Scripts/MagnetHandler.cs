using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetHandler : MonoBehaviour
{
    static MagnetHandler instance_;
    public Magnet[] magnets_;
    void Start()
    {
        instance_ = this;     
    }

    public static bool AreMagnetsPulling()
    {
        foreach(Magnet magnet in instance_.magnets_)
        {
            if(magnet.isPulling_)
            {
                return true;
            }
        }
        return false;
    }
}
