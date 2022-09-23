using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private List<TerrainObject> terrainDatas = new List<TerrainObject>();
    [SerializeField]
    private int maxTerrains;
    [SerializeField]
    private int minDistanceCreating;

    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0,0,0);
    private void Start()
    {
        BuildStartPlane();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UpdateTerrains();
        }
    }

    private void BuildStartPlane()
    {
        for(int i = 0; i < minDistanceCreating; i++)
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
            var gameObject = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity);
            currentTerrains.Add(gameObject);
            currentPosition.x++;
            if(currentTerrains.Count > maxTerrains)
            {
                Destroy(currentTerrains[0]);
                currentTerrains.RemoveAt(0);
            }
        }
    }

    private void UpdateTerrains()
    {
        BuildTerrain();
        if (currentTerrains.Count > maxTerrains)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
    }
}
