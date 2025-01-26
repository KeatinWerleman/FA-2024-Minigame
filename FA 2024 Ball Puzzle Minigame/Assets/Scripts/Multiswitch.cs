using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiswitch : MonoBehaviour
{
    public bool isSwitchActive = false;
    public AudioClip switchHitClip;
    public float volume;
    public SpriteRenderer spriteRenderer;
    public Collider2D switchCollider;
    public GameObject switchHitParticleSystem;
    public Color startColor;
    public Color hitColor;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switchCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!switchCollider.isTrigger)
        {
            
            
                if (collision.gameObject.tag == "Ball")
                {

                    SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                    ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                    main.startColor = spriteRenderer.color;
                    var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                    
                    Destroy(particles, 0.5f);

                    
                    if (isSwitchActive == true)
                    {
                        isSwitchActive = false;
                        Destroy(collision.gameObject);
                    GameManager.Instance.TurnLaunchStateOn();
                    MultiswitchHandler.Instance.CheckIfAllSwitchesAreHit();
                }
                    else if (!isSwitchActive)
                    {
                        isSwitchActive = true;
                        Destroy(collision.gameObject);
                    GameManager.Instance.TurnLaunchStateOn();
                    MultiswitchHandler.Instance.CheckIfAllSwitchesAreHit();
                }
                
                }
            


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (switchCollider.isTrigger)
        {
            {

                SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
                ParticleSystem.MainModule main = switchHitParticleSystem.GetComponent<ParticleSystem>().main;
                main.startColor = spriteRenderer.color;
                var particles = Instantiate(switchHitParticleSystem, transform.position, Quaternion.identity);
                
                Destroy(particles, 0.5f);
                
                if (isSwitchActive)
                {
                    isSwitchActive = false;
                    Destroy(collision.gameObject);
                    GameManager.Instance.TurnLaunchStateOn();
                    MultiswitchHandler.Instance.CheckIfAllSwitchesAreHit();
                }
                else if (!isSwitchActive)
                {
                    isSwitchActive = true;
                    Destroy(collision.gameObject);
                    GameManager.Instance.TurnLaunchStateOn();
                    MultiswitchHandler.Instance.CheckIfAllSwitchesAreHit();
                }

            }


        }

    }

}
