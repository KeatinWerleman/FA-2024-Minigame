using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    public static TargetChecker Instance;
    
    
    
    private void Awake()
    {
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isLevelWon == false)
        {
            AreTargetsHere();
            
        }
        
    }
    
    public void AreTargetsHere()
    {
        if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            GameManager.Instance.HandleWin();
        }


    }

}
