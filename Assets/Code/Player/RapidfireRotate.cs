using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidfireRotate : MonoBehaviour
{
    [SerializeField] private Transform rotatingPart;
    
    private void Update()
    {
        rotatingPart.Rotate(new(0, 0, 1));
    }
}
