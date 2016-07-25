using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {
    public GameObject Dialog;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Click()
    {
        Time.timeScale = 1;
        Dialog.SetActive(false);
    }
}
