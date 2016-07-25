using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pattern : MonoBehaviour {
    public Image myImage;
    public bool isTouched = false;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (isTouched == true && Input.GetMouseButtonUp(0))
        {
            OnTouchUp();
        }
	}

    public void OnTouch(string dir)
    {
        if (isTouched == false)
        {
            isTouched = true;
            myImage.color = Color.green;
            SkillManager.instance.insertQueue(dir);
        }
    }
    public void OnTouchUp()
    {
        isTouched = false;
        myImage.color = Color.white;
    }

}
