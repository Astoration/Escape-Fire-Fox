using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject,0.8f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
