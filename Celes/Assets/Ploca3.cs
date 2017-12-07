using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ploca3 : MonoBehaviour {

    private Animation Ploca;
    private void Start()
    {
        Ploca = transform.GetComponent<Animation>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Ploca.IsPlaying("Ploca3Down") && collision.gameObject.name=="Player")
        {
            Ploca.Rewind("Ploca3Down");
        }
    }
}
