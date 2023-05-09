using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Soundtrack : MonoBehaviour
{
    public AudioSource src1;
    public AudioClip sfx_1;
    bool in_room;
    public float volume_level;
    
    // Start is called before the first frame update
    private void Start()
    {
        src1.clip = sfx_1;
        src1.volume = 0;
        src1.Play();
        in_room = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //src1.volume = 1;
            in_room=true;
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //src1.volume = 0;
            in_room = false;
        }
    }
    private void Update()
    {   if (volume_level != null)
        {
            if (in_room == true && src1.volume < volume_level)
            {
                if(volume_level == 1)
                {
                    src1.volume += 0.01f;
                }
                else
                {
                    src1.volume += 0.001f;
                }
                //src1.volume += volume_level / 100;


            }
            if (in_room == false && src1.volume > 0)
            {
                
                if (volume_level == 1)
                {
                    src1.volume -= 0.01f;
                }
                else
                {
                    src1.volume -= 0.001f;
                }
                //src1.volume -= volume_level / 100;
            }
        }
        else
        {
            if (in_room == true && src1.volume < 1)
            {
                src1.volume += 0.001f;
            }
            if (in_room == false && src1.volume > 0)
            {
                src1.volume -= 0.001f;
            }
        }
        
        
    }
}
