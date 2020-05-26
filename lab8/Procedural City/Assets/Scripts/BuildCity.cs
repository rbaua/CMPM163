using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int buildingFootprint = 4;

    void Start()
    {
        float seed = Random.Range(0, 100);
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                int result = (int)(Mathf.PerlinNoise(w/9.0f + seed, h/9.0f + seed) * buildings.Length);
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                Instantiate(buildings[result], pos, Quaternion.Euler(0f, Random.Range(0, 4) * 90f, 0f));
            }
        }        
    }
}
