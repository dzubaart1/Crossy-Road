using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smootheness;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smootheness);
    }
}
