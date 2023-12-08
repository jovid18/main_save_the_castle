using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public List<AudioClip> AddedSound = new List<AudioClip>();
    public AudioSource deathSound;

    // Start is called before the first frame update
    public void sound(GameObject gameObject)
    {   
        if (gameObject.tag == "Demon")
        {
            int select = Random.Range(0, 2);
            deathSound.clip = AddedSound[select];
        }
        else if (gameObject.tag == "Giant")
        {
            deathSound.clip = AddedSound[2];
        }
        else if (gameObject.tag == "UmbrellaYokai")
        {
            int select = Random.Range(3, 5);
            deathSound.clip = AddedSound[select];
        }
        else if (gameObject.tag == "OniSamurai2")
        {
            int select = Random.Range(6, 9);
            deathSound.clip = AddedSound[select];
        }
        deathSound.PlayOneShot(deathSound.clip);
    }
}

