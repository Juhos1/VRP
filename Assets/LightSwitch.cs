using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference action;
    public GameObject lightGameObject;
    private Light lightComponent;
    private bool lightSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = lightGameObject.GetComponent<Light>();

        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            lightSwitch = !lightSwitch;

            if (lightSwitch) {
                lightComponent.color = Color.red;
            } else {
                lightComponent.color = Color.blue;
            }
        };
    }
}
