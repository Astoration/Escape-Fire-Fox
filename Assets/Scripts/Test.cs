using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    public int stage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("stage", stage);
	}
}
