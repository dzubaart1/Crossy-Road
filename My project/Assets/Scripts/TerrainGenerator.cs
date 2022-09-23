using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private List<TerrainObject> terrainDatas = new List<TerrainObject>();

    private Vector3 currentPosition = new Vector3(0,0,0);
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            BuildTerrain();
        }
    }

    private void BuildTerrain()
    {
        int whichTerrain = Random.Range(0, terrainDatas.Count);
        int countsOfTerrain = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
        for(int i = 0; i < countsOfTerrain; i++)
        {
            Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity);
            currentPosition.x++;
        }
    }
}
