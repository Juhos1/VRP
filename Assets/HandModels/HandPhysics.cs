using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        if (float.IsInfinity(rotationAxis.x))
            return;

        if (angleInDegree > 180f)
            angleInDegree -= 360f;
        
        Vector3 angular = (Mathf.Deg2Rad * angleInDegree / Time.fixedDeltaTime) * rotationAxis.normalized;
        rb.angularVelocity = angular;
        
        //Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;
        //rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
