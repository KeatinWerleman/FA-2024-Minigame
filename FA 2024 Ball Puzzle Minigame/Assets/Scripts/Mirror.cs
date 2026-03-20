using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Mirror : MonoBehaviour
{
    
    public GameObject thisMirror;
    public string wallTag;
    public AudioClip ballBounceSound;
    public float volume;
    
    public GameObject mirrorHitParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }



    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Special Ball")
        {
            //hitCount--;
            if (collision.gameObject.tag == "Special Ball")
            {
                GameManager.Instance.UpdateScore(1);
            }
            
            
            Debug.Log(collision.gameObject.transform.position);
            collision.transform.position = new Vector3(Mathf.RoundToInt(collision.transform.position.x), Mathf.RoundToInt(collision.transform.position.y), 0f);
            Debug.Log("ROUNDED POS" + collision.gameObject.transform.position);
            SoundFXManager.Instance.PlaySoundFXClip(ballBounceSound, transform, volume);
            GameManager.Instance.UpdateScore(1);

            if (PlayerPrefs.GetString("Are Particles On") == "true")
            {
                var particles = Instantiate(mirrorHitParticleSystem, transform.position, Quaternion.identity);
                Destroy(particles, 0.5f);
            }
            
        }
        

        

        
    }

}
