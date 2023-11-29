using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]Vector3 offset;

    void Update() => TrackingPerson();

    private void TrackingPerson() => transform.position = target.position + offset;
}

