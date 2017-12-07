using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button2Logic : MonoBehaviour {

    private Animation Ploca;
    public bool Podignuta = false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Button2Pomjeren")) Podignuta = Convert.ToBoolean(PlayerPrefs.GetFloat("Button2Pomjeren"));
        else Podignuta = false;
        Ploca = GameObject.Find("Ploca2").GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Podignuta)
        {
            if (!GameObject.Find("Ploca2").GetComponent<Animation>().IsPlaying("Ploca2Down"))
            {
                Ploca = GameObject.Find("Ploca2").GetComponent<Animation>();
                Ploca.Play("Ploca2Up");
                Podignuta = true;
            }
        }
        else if (Podignuta)
        {
            if (!Ploca.IsPlaying("Ploca2Up"))
            {
                GameObject.Find("Ploca2").GetComponent<Animation>().Play("Ploca2Down");
                Podignuta = false;
            }
        }
        transform.GetComponent<Animation>().Play();
        PlayerPrefs.SetFloat("Button2Pomjeren", Convert.ToInt32(Podignuta));
       
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetFloat("Button2Pomjeren", Convert.ToInt32(Podignuta));
    }

}
