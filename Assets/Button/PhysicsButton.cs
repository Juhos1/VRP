using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    public GameObject[] resetObjects;
    
    private Vector3[] originalPositions;

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();

        originalPositions = new Vector3[resetObjects.Length];

        for(int i = 0; i < resetObjects.Length; i++)
        {
            if (resetObjects[i] != null)
            {
                originalPositions[i]  = resetObjects[i].GetComponent<Rigidbody>().position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{GetValue() + threshold}");
        if (!_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private void Pressed()
    {
        _isPressed = true;
        
        for(int i = 0; i < resetObjects.Length; i++)
        {
            Debug.Log("1!");
            if (resetObjects[i] != null)
            {
                Debug.Log("OG: " + originalPositions[i] + " vs " + resetObjects[i].transform.position);
                resetObjects[i].transform.position = originalPositions[i];
                resetObjects[i].transform.rotation = Quaternion.identity;
                resetObjects[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }

        Debug.Log("Pressed!");
    }

    private void Released()
    {
        _isPressed = false;
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }
}
