using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBlock : MonoBehaviour
{
    public string ballTag;
    public AudioClip targetHitClip;
    public float volume;
    public GameObject winBlockParticleExplosion;

    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            var particles = Instantiate(winBlockParticleExplosion, transform.position, Quaternion.identity);
            Debug.Log("Target Hit at " + collision.gameObject.transform.position);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            SoundFXManager.Instance.PlaySoundFXClip(targetHitClip, transform, volume);
            Destroy(particles, 0.5f);
            GameManager.Instance.TurnLaunchStateOn();
            

        }
    }
}
