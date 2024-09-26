using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    public static TargetChecker Instance;
    public GameObject target;
    public GameObject target2;
    
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
        if (target == null && target2 == null)
        {
            Debug.Log("NO TARGETS LEFT");
            GameManager.Instance.HandleWin();
        }
        
    }

}
