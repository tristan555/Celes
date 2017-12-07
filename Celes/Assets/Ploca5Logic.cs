using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ploca5Logic : MonoBehaviour {

    private Animation Ploca;
    private void Start()
    {
        Ploca = transform.GetComponent<Animation>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Ploca.IsPlaying("Ploca5Down"))
        {
            Ploca.Rewind("Ploca5Down");
        }
    }
}
