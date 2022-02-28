using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyBehaviour : MonoBehaviour
{
    Rigidbody mRigidBody;
    public float mThrust = 0.0000001f;

    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mRigidBody.AddForce(transform.up * mThrust);
    }
}
