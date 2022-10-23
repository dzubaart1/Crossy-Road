using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Zenject;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform _terrainHolder;
    [SerializeField]
    private int _maxTerrains;
    [SerializeField]
    private int _minDistanceCreating;

    private List<GameObject> _currentTerrains;
    private List<GameObject> _commonRoads;
    private List<GameObject> _startRoads;
    private Vector3 _currentPosition;
    private RoadsCollection _roadsCollection;

    [Inject]
    public void Construct(RoadsCollection roadsCollection)
    {
        _roadsCollection = roadsCollection;
    }
    private void Awake()
    {
        _currentTerrains = new List<GameObject>();
        _currentPosition = new Vector3(0, 0, 0);
        _roadsCollection.CollectRoads();
        _commonRoads = _roadsCollection.commonRoads;
        _startRoads = _roadsCollection.startRoads;
    }

    private void Start()
    {
        BuildStartPlane();
    }

    private void BuildStartPlane()
    {
        BuildTerrain(_startRoads.Find(n => n.name == "Start"));
        for(int i = 0; i < _minDistanceCreating; i++)
        {
            BuildTerrain(_startRoads.Find(n => n.name == "Crazy"));
        }
    }
    private void BuildTerrain(GameObject terrain)
    {
        var gameObject = Instantiate(terrain, _currentPosition, Quaternion.identity, _terrainHolder);
        _currentTerrains.Add(gameObject);
        _currentPosition.x++;
    }

    public void UpdateTerrains(Vector3 playerPos)
    {
        if (_currentPosition.x - playerPos.x < _minDistanceCreating)
        {
            BuildTerrain(_commonRoads[Random.Range(0,_commonRoads.Count)]);
        }
        if (_currentTerrains.Count > _maxTerrains)
        {
            Destroy(_currentTerrains[0]);
            _currentTerrains.RemoveAt(0);
        }
    }
}
