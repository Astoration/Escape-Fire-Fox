using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displayLevel : MonoBehaviour {
    public string name;
    public Text levelText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        levelText.text = saveManager.GetInt(name, 0).ToString();
	}
}
