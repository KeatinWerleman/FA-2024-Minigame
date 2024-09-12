using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBlock : MonoBehaviour
{
    public string ballTag;
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
        if(collision.gameObject.tag == ballTag)
        {
            Debug.Log("Level Win");
            //Switch Game State to "LevelWon" and bring up menu to move to next level.
        }
    }
}
