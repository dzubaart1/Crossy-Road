using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Spawners
{
    public class TreeSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _treeModel;
        [SerializeField]
        private Transform _treeHolder;
        private Border _border = new Border();

        /*[Inject]
        private void Construct(Border border)
        {
            _border = border;
        }*/
        private void Start()
        {
            _border._upperBound = 11;
            _border._lowerBound = -11;
            SetTrees();
        }
        private void SetTrees()
        {
            List<int> vacantPos = new List<int>(Enumerable.Range(_border._lowerBound + 1, _border._upperBound-_border._lowerBound-2));
            int countOfTrees = Random.Range(3, 6);
            int whichPos = 0;

            Instantiate(_treeModel, transform.position + new Vector3(0, 1f, _border._lowerBound), Quaternion.identity, _treeHolder);
            Instantiate(_treeModel, transform.position + new Vector3(0, 1f, _border._upperBound), Quaternion.identity, _treeHolder);
            for (int i = 0; i < countOfTrees; i++)
            {
                whichPos = Random.Range(0, vacantPos.Count);
                Instantiate(_treeModel, transform.position + new Vector3(0, 1f, vacantPos[whichPos]), Quaternion.identity, _treeHolder);
                vacantPos.RemoveAt(whichPos);
            }
        }
    }
}