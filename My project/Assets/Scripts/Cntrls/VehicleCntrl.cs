using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cntrls
{
    public class VehicleCntrl : MonoBehaviour
    {
        [SerializeField] private float speed;

        void Update()
        {
            transform.Translate(Vector3.forward * Random.Range(1, speed) * Time.deltaTime);
        }
    }
}