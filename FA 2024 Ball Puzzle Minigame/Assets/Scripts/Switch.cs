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
    public AudioClip switchHitClip;
    public Vector3 tempPosition;
    public quaternion tempRotation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            SoundFXManager.Instance.PlaySoundFXClip(switchHitClip, transform, 1f);
            tempPosition = affectedObject.transform.position;
            tempRotation = affectedObject.transform.rotation;
            affectedObject.transform.position = objectLocationSprite.transform.position;
            affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
            objectLocationSprite.transform.position = tempPosition;
            objectLocationSprite.transform.rotation = tempRotation;
            Destroy(collision.gameObject);
            
        }
    }
}
