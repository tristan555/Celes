using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ploca4Collision : MonoBehaviour {


    public bool Sudar = false;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name==("Ploca3"))
        {
            Sudar = true;
        }
        PlayerPrefs.SetFloat("Sudar",Convert.ToInt32(Sudar));
    }
}
