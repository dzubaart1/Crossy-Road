using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform terrainHolder;
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

    private void BuildStartPlane()
    {
        for(int i = 0; i < minDistanceCreating; i++)
        {
            BuildTerrain(3);
        }
    }
    private void BuildTerrain(int whichTerrain = -1)
    {
        if (whichTerrain == -1)
        {
            whichTerrain = Random.Range(0, terrainDatas.Count);
        }

        int countsOfTerrain = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
        for(int i = 0; i < countsOfTerrain; i++)
        {
            var gameObject = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
            currentTerrains.Add(gameObject);
            currentPosition.x++;
        }
    }

    public void UpdateTerrains(Vector3 playerPos)
    {
        if (currentPosition.x - playerPos.x < minDistanceCreating)
        {
            BuildTerrain();
        }
        if (currentTerrains.Count > maxTerrains)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
    }
}
