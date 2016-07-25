using UnityEngine;
using System.Collections;

public class saveManager : MonoBehaviour {
    public static int curSlot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int GetInt(string name, int baseValue)
    {
        return PlayerPrefs.GetInt(curSlot + name, baseValue);
    }

    public static float GetFloat(string name, float baseValue)
    {
        return PlayerPrefs.GetFloat(curSlot + name, baseValue);
    }

    public static string GetInt(string name, string baseValue)
    {
        return PlayerPrefs.GetString(curSlot + name, baseValue);
    }

    public static void SetInt(string name, int value)
    {
        PlayerPrefs.SetInt(curSlot + name, value);
    }

    public static void SetFloat(string name, float value)
    {
        PlayerPrefs.SetFloat(curSlot + name, value);
    }

    public static void SetString(string name, string value)
    {
        PlayerPrefs.SetString(curSlot + name, value);
    }
    
    public static void Save()
    {
        PlayerPrefs.Save();
    }
}
