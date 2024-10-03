using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private void OnCollisionExit2D(Collision2D collision)
    {
        /* if (collision.gameObject.tag == "Mirror")
         {
             collision.transform.position = new Vector3(Mathf.RoundToInt(collision.transform.position.x), Mathf.RoundToInt(collision.transform.position.y), 0f);
         }*/
    }
}
