using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject affectedObject;
    public GameObject objectLocationSprite;
    public bool isSwitchActive = false;
    public bool isSpecialSwitch;
    public AudioClip switchHitClip;
    public float volume;
    public Vector3 tempPosition;
    public quaternion tempRotation;
    public SpriteRenderer spriteRenderer;
    public Collider2D switchCollider;
    public GameObject switchHitParticleSystem;
    public Color startColor;
    public Color hitColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switchCollider = GetComponent<Collider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (switchCollider.isTrigger == false)
        {


            if (affectedObject != null)
            {
                if (isSpecialSwitch)
                {
                    if (collision.gameObject.tag == "Special Ball")
                    {
                        {

                            SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                            ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                            main.startColor = spriteRenderer.color;
                            
                           
                            tempPosition = affectedObject.transform.position;
                            tempRotation = affectedObject.transform.rotation;
                            affectedObject.transform.position = objectLocationSprite.transform.position;
                            affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
                            objectLocationSprite.transform.position = tempPosition;
                            objectLocationSprite.transform.rotation = tempRotation;
                            if (PlayerPrefs.GetString("Are Particles On") == "true")
                            {
                                var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                                Destroy(particles, 0.5f);
                            }
                            Debug.Log("Special Ball Touched Switch");
                            Destroy(collision.gameObject);
                            GameManager.Instance.TurnLaunchStateOn();


                        }
                    }
                }

                if (!isSpecialSwitch)
                {
                    if (collision.gameObject.tag == "Ball")
                    {
                        SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                        ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                        main.startColor = spriteRenderer.color;
                        
                        tempPosition = affectedObject.transform.position;
                        tempRotation = affectedObject.transform.rotation;
                        affectedObject.transform.position = objectLocationSprite.transform.position;
                        affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
                        objectLocationSprite.transform.position = tempPosition;
                        objectLocationSprite.transform.rotation = tempRotation;
                        if (PlayerPrefs.GetString("Are Particles On") == "true")
                        {
                            var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                            Destroy(particles, 0.5f);
                        }

                        GameManager.Instance.TurnLaunchStateOn();
                        Destroy(collision.gameObject);



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
                if (isSpecialSwitch)
                {
                    if (collision.gameObject.tag == "Special Ball")
                    {
                        {
                            SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                            ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                            main.startColor = spriteRenderer.color;
                            
                            tempPosition = affectedObject.transform.position;
                            tempRotation = affectedObject.transform.rotation;
                            affectedObject.transform.position = objectLocationSprite.transform.position;
                            affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
                            objectLocationSprite.transform.position = tempPosition;
                            objectLocationSprite.transform.rotation = tempRotation;
                            if (PlayerPrefs.GetString("Are Particles On") == "true")
                            {
                                var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                                Destroy(particles, 0.5f);
                            }
                            Debug.Log("Special Ball Touched Button");
                            


                        }
                        


                    }
                }
            }
            if (!isSpecialSwitch)
            {
                if (collision.gameObject.tag == "Ball")
                {
                    SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                    ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                    main.startColor = spriteRenderer.color;
                   
                    tempPosition = affectedObject.transform.position;
                    tempRotation = affectedObject.transform.rotation;
                    affectedObject.transform.position = objectLocationSprite.transform.position;
                    affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
                    objectLocationSprite.transform.position = tempPosition;
                    objectLocationSprite.transform.rotation = tempRotation;
                    if (PlayerPrefs.GetString("Are Particles On") == "true")
                    {
                        var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                        Destroy(particles, 0.5f);
                    }


                }
            }

        }

    }

}


