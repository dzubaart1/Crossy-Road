using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class VehicleSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject vehicle;
        [SerializeField]
        private List<Transform> spawnPoses;

        void Start()
        {
            StartCoroutine(SpawnVehicle());
        }

        private IEnumerator SpawnVehicle()
        {
            int whichSide = Random.Range(0, spawnPoses.Count);
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(3, 7));
                Destroy(Instantiate(vehicle, spawnPoses[whichSide].position, Quaternion.LookRotation(spawnPoses[whichSide].forward)), 9);
            }
        }
    }
}