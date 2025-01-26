using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BreakingWalls : MonoBehaviour
{
    public int startingHP;
    public int currentHP;
    public TextMeshProUGUI currentHPText;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = startingHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            
            currentHP--;
            currentHPText.SetText(currentHP.ToString());
            Destroy(collision.gameObject);
            if (currentHP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
