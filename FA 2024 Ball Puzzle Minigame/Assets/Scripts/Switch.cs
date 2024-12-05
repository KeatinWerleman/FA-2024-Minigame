using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject affectedObject;
    public GameObject objectLocationSprite;
    public bool isSwitchActive = false;
    public bool isThisMirror;
    public AudioClip switchHitClip;
    public float volume;
    public Vector3 tempPosition;
    public quaternion tempRotation;
    public SpriteRenderer spriteRenderer;
    public Collider2D switchCollider;
    public GameObject switchHitParticleSystem;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switchCollider = GetComponent<Collider2D>();
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (!switchCollider.isTrigger)
        {
            if (affectedObject != null)
            {
                if (collision.gameObject.tag == "Ball")
                {
                    SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                    ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                    main.startColor = spriteRenderer.color;
                    var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                    tempPosition = affectedObject.transform.position;
                    tempRotation = affectedObject.transform.rotation;
                    affectedObject.transform.position = objectLocationSprite.transform.position;
                    affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
                    objectLocationSprite.transform.position = tempPosition;
                    objectLocationSprite.transform.rotation = tempRotation;
                    Destroy(particles, 0.5f);
                    if (isThisMirror == false)
                    {
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            

         }
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (switchCollider.isTrigger)
        {
            if (affectedObject != null)
            {
                if (collision.gameObject.tag == "Ball")
                {
                    SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                    tempPosition = affectedObject.transform.position;
                    tempRotation = affectedObject.transform.rotation;
                    affectedObject.transform.position = objectLocationSprite.transform.position;
                    affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
                    objectLocationSprite.transform.position = tempPosition;
                    objectLocationSprite.transform.rotation = tempRotation;
                    Destroy(switchHitParticleSystem.gameObject, 0.5f);

                }
            }
            
        }
        
    }

}
