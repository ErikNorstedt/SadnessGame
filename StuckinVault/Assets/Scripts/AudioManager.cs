using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance_;
    public AudioClip[] clips_;
    public AudioSource clipSource_;
    public AudioSource clockSource_;

    private void Awake()
    {
        if (instance_ == null)
            instance_ = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playRandomBadThought()
    {
        if (instance_.clipSource_.isPlaying == true)
            return;
        instance_.clipSource_.clip = instance_.clips_[Random.Range(1,instance_.clips_.Length - 1)];
        instance_.clipSource_.Play();
    }

    public static bool isPlaying()
    {
        return instance_.clipSource_.isPlaying;
    }

    public static void playGoodConversation()
    {
        instance_.clipSource_.Stop();
        instance_.clipSource_.clip = instance_.clips_[0];
        instance_.clipSource_.Play();
    }

    public static void stopClock()
    {
        instance_.clockSource_.Stop();
    }
}
