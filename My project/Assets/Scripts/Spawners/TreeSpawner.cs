using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawners
{
    public class TreeSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _treeModel;
        [SerializeField]
        private Transform _treeHolder;
        void Start()
        {
            SetTrees();
        }
        private void SetTrees()
        {
            List<int> vacantPos = new List<int>(Enumerable.Range(-10, 20));
            int countOfTrees = Random.Range(3, 6);
            int whichPos = 0;

            Instantiate(_treeModel, transform.position + new Vector3(0, 1f, -11), Quaternion.identity, _treeHolder);
            Instantiate(_treeModel, transform.position + new Vector3(0, 1f, 11), Quaternion.identity, _treeHolder);
            for (int i = 0; i < countOfTrees; i++)
            {
                whichPos = Random.Range(0, vacantPos.Count);
                Instantiate(_treeModel, transform.position + new Vector3(0, 1f, vacantPos[whichPos]), Quaternion.identity, _treeHolder);
                vacantPos.RemoveAt(whichPos);
            }
        }
    }
}