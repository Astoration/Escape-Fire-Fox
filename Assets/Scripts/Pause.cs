using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public GameObject Dialog;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click()
    {
        Dialog.SetActive(true);
        Time.timeScale = 0;
    }
}
