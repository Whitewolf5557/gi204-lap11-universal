using UnityEngine;
using System.Collections.Generic;

public class Gravitation : MonoBehaviour
{
    public static List<Gravitation> otherObj;
    private Rigidbody rb;
    const float G = 0.00667f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObj == null) 
        { 
            otherObj = new List<Gravitation>();
        }
        otherObj.Add(this);
    }

    void FixedUpdate()
    {
        foreach (Gravitation obj in otherObj) 
        { 
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }
    void Attract(Gravitation other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;

        float distance = direction.magnitude;
        if (distance == 0f) return;

        float forceMagnitude = G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);
        Vector3 gravitationForce = forceMagnitude * direction.normalized;
        otherRb.AddForce(gravitationForce);
    }
}
