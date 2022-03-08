using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ResizeCamera : MonoBehaviour
{
    private float CamRect = 9f/16f;

    public void Awake()
    {
        Camera cam = this.GetComponent<Camera>();
        cam.aspect = CamRect;
    }
}