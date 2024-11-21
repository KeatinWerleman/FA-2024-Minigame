using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
            else if (spriteRenderer.flipX == true)
            { 
                spriteRenderer.flipX = false;
            }
            SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, volume);
            tempPosition = affectedObject.transform.position;
            tempRotation = affectedObject.transform.rotation;
            affectedObject.transform.position = objectLocationSprite.transform.position;
            affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
            objectLocationSprite.transform.position = tempPosition;
            objectLocationSprite.transform.rotation = tempRotation;
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
