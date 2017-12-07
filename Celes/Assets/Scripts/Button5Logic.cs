using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button5Logic : MonoBehaviour
{
    private Animation Ploca;
    
    public bool Podignuta = false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Button5Pomjeren")) Podignuta = Convert.ToBoolean(PlayerPrefs.GetFloat("Button5Pomjeren"));
        else Podignuta = false;
        Ploca = GameObject.Find("Ploca5").GetComponent<Animation>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!Podignuta)
        {
            if (!GameObject.Find("Ploca5").GetComponent<Animation>().IsPlaying("Ploca5Down"))
            {
                Ploca = GameObject.Find("Ploca5").GetComponent<Animation>();
                Ploca.Play("Ploca5Up");
                Podignuta = true;
                
            }
        }
        else if (Podignuta)
        {
            if (!Ploca.IsPlaying("Ploca5Up"))
            {
                GameObject.Find("Ploca5").GetComponent<Animation>().Play("Ploca5Down");
                Podignuta = false;
            }
        }
        transform.GetComponent<Animation>().Play();
        PlayerPrefs.SetFloat("Button5Pomjeren", Convert.ToInt32(Podignuta));

    }
    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetFloat("Button5Pomjeren", Convert.ToInt32(Podignuta));
    }
}
