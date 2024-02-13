using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensRotate : MonoBehaviour
{
    public Camera lensCamera;
    public Camera playerViewCamera;

    void Start()
    {
        
    }

    void Update()
    {
        Quaternion relativeRotation = Quaternion.LookRotation(transform.position - playerViewCamera.transform.position, transform.up);

        lensCamera.transform.rotation = relativeRotation;
    }
}
