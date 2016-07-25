using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Portion : MonoBehaviour {
    public Text showNum;
    public string name;
    int num;
	// Use this for initialization
	void Start () {
        num = saveManager.GetInt(name, 0);
        showNum.text = num + "";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void useHpPortion()
    {
        if (num > 0)
        {
            saveManager.SetInt(name, --num);
            showNum.text = num + "";
            StatusManager.instance.healHalfHP();
        }
    }

    public void useMpPortion()
    {
        if (num > 0)
        {
            saveManager.SetInt(name, --num);
            showNum.text = num + "";
            StatusManager.instance.healHalfMP();
        }
    }

}
