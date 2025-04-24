using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int width, height;    // Start is called before the first frame update
    [SerializeField] private Tile tilePrefab;
    
    
    void Start()
    {

        if (PlayerPrefs.GetString("Are Grids On") == "true")
        {
            GenerateGrid();
        }

        else if (PlayerPrefs.GetString("Are Grids On") == "false")
        {
            Debug.Log("Grids are off");
        }
        

        
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3 (x, y, 0), Quaternion.identity, this.transform);
                spawnedTile.name = "Tile" + x + ", " + y;
                
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
