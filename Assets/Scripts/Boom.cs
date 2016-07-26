using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {
    public float time = 0.8f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject,time);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
