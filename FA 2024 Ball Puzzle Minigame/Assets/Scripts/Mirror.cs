using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Mirror : MonoBehaviour
{
    public int hitCount;
    public int maxHitCount;
    public GameObject thisMirror;
    public string wallTag;
    public AudioClip ballBounceSound;
    public float volume;
    public TextMeshPro hitCountText;
    public GameObject mirrorHitParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        hitCount = maxHitCount;
        hitCountText.SetText(hitCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
         
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Launcher" || collision.gameObject.tag == "Target" || collision.gameObject.tag == "Switch" || collision.gameObject.tag == "Location Sprite")
        {
            Debug.Log("Touched Something Bad");
            Mouse.Instance.MoveBackToIntital(thisMirror);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitCount--;
            hitCountText.SetText(hitCount.ToString());
            var particles = Instantiate(mirrorHitParticleSystem, transform.position, Quaternion.identity);
            
            Debug.Log(collision.gameObject.transform.position);
            collision.transform.position = new Vector3(Mathf.RoundToInt(collision.transform.position.x), Mathf.RoundToInt(collision.transform.position.y), 0f);
            Debug.Log("ROUNDED POS" + collision.gameObject.transform.position);
            SoundFXManager.Instance.PlaySoundFXClip(ballBounceSound, transform, volume);
            Destroy(particles, 0.5f);

        }

        if (hitCount <= 0)
        {
            Destroy(thisMirror);
        }
    }

}
