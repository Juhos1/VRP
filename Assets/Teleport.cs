using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public InputActionReference action;
    public GameObject location1Object;
    private Vector3 location2;
    private bool locationSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            locationSwitch = !locationSwitch;

            if (locationSwitch) {
                location2 = gameObject.transform.position;
                gameObject.transform.position = location1Object.transform.position;
            } else {
                gameObject.transform.position = location2;
            }
        };
    }
}
