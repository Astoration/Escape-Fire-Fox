using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Scene()
    {
        Application.LoadLevel("upgradeScene");
    }


    public void NextScene()
    {
        Application.LoadLevel("ingameScene");
    }

    public void BackScene()
    {
        Application.LoadLevel("saveScene");
    }
}
