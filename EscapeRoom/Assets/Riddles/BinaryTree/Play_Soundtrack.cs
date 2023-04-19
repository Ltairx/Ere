using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Soundtrack : MonoBehaviour
{
    public AudioSource src1;
    public AudioClip sfx_1;
    bool in_room;
    
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
    {
        if(in_room == true && src1.volume < 1)
        {
            src1.volume += 0.01f;
        }
        if (in_room == false && src1.volume > 0)
        {
            src1.volume -= 0.01f;
        }
    }
}
