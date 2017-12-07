using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlocaMovement : MonoBehaviour {

    public Vector3 dir;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   public void MovePloca()
    {
        rb.position = Vector3.Lerp(transform.position, new Vector3(dir.x, dir.y, dir.z), Time.deltaTime);
    }
}
