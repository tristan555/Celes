using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SavingGame : MonoBehaviour {
   
    private GameObject[] Ploce;
    private string[] imenaPloca;
    private string[] xPozicije,yPozicije,zPozicije;
   


    public void Start()
    {
        Ploce = new GameObject[6];
        xPozicije = new string[6];
        yPozicije = new string[6];
        zPozicije = new string[6]; 
        imenaPloca = new string[6];

        for(int i = 0; i < imenaPloca.Length; i++)
        {
            imenaPloca[i] = "Ploca" + Convert.ToString(i+1);
        }
        for (int i = 0; i < imenaPloca.Length; i++)
        {
            xPozicije[i] = imenaPloca[i] + "X";
        }
        for (int i = 0; i < imenaPloca.Length; i++)
        {
            yPozicije[i] = imenaPloca[i] + "Y";
        }
        for (int i = 0; i < imenaPloca.Length; i++)
        {
            zPozicije[i] = imenaPloca[i] + "Z";
        }
        for (int i=0;i<imenaPloca.Length;i++)
        {
            Ploce[i] = GameObject.Find(imenaPloca[i]);
        }
        
    }
    public void SaveObjectsPosition()
    {
       
        
            for (int i = 0; i < Ploce.Length; i++)
            {
            if (Ploce[i])
            {
                PlayerPrefs.SetFloat(xPozicije[i], Ploce[i].transform.position.x);
                PlayerPrefs.SetFloat(yPozicije[i], Ploce[i].transform.position.y);
                PlayerPrefs.SetFloat(zPozicije[i], Ploce[i].transform.position.z);
            }

            }
        
    }
    public void LoadObjects()
    {
        for (int i = 0; i < 6; i++)
        {
            Ploce[i] = GameObject.Find(imenaPloca[i]);
        }
        for (int i = 0; i < Ploce.Length; i++)
        {
           if(PlayerPrefs.HasKey(xPozicije[i]) && Ploce[i])Ploce[i].transform.position = new Vector3(PlayerPrefs.GetFloat(xPozicije[i]), PlayerPrefs.GetFloat(yPozicije[i]), PlayerPrefs.GetFloat(zPozicije[i]));
            
        }    
    }
}
