using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance_;
    public AudioClip[] clips_;
    public AudioSource clipSource_;
    public AudioSource clockSource_;

    float randomTimer_;
    float timer_ = 0;
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
        randomTimer_ = Random.Range(4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if(Win.won == false)
        {
            timer_ += Time.deltaTime;
            if (timer_ >= randomTimer_)
            {
                playRandomBadThought();
                randomTimer_ = Random.Range(4, 7);
                timer_ = 0;
            }
        }    
    }

    void playRandomBadThought()
    {
        instance_.clipSource_.Stop();
        instance_.clipSource_.clip = instance_.clips_[Random.Range(1,instance_.clips_.Length - 1)];
        instance_.clipSource_.Play();
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
