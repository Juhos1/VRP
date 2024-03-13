using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Goal : MonoBehaviour
{
    public InputActionReference resetAction;

    [SerializeField] private TMP_Text _text;
    private int _goals = 0;

    void Start()
    {
        resetAction.action.Enable();
        resetAction.action.performed += (ctx) =>
        {
            _goals = 0;
            _text.text = _goals.ToString();
        };
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet")
        {
            _goals++;
            _text.text = _goals.ToString();
        }
    }
}
