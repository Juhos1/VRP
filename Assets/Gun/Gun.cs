using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public InputActionReference shootAction;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public InputActionReference gripAction;
    public InputActionReference triggerAction;
    public float shootSpeed = 0.1f;

    private float _nextActionTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        shootAction.action.Enable();
        gripAction.action.Enable();
        triggerAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextActionTime ) {
            _nextActionTime += shootSpeed;
        
            if (shootAction.action.IsPressed() && gripAction.action.ReadValue<float>() > 0.8 && triggerAction.action.ReadValue<float>() < 0.01)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
        }
    }
}
