using UnityEngine;
using System.Collections;
//ovo ja napravio hahahah ponosan sam uglavnom fja rotate rotira loptu po z osi(zbog ovog Up) i dize za po 1 stepen u deltaTime*20 to je nedje 60 puta u sekundi
public class StaticRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime*20.0f);
	}
}
