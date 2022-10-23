using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadsCollection
{
    public List<GameObject> commonRoads = new List<GameObject>();
    public List<GameObject> startRoads = new List<GameObject>();
    private CollectionParams _collectionParams;
    public RoadsCollection(CollectionParams collectionParams)
    {
        _collectionParams = collectionParams;
    }
    public void CollectRoads()
    {
        if(_collectionParams != null)
        {
            List<GameObject> roadsList = Resources.LoadAll<GameObject>(_collectionParams.PathToRoads).ToList();
            foreach (var road in roadsList)
            {
                if(road.name == "Start" || road.name == "Crazy")
                {
                    startRoads.Add(road);
                }
                else
                {
                    commonRoads.Add(road);
                }
            }
        }
    }
}
