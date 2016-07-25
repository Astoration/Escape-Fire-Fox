using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataManager : MonoBehaviour {
	public static DataManager instance;

	void Awake() {
		if (DataManager.instance == null)
			DataManager.instance = this;
	}
	public int curSlot;

	public int stageLevel;
	public int money;

	public int defaultFrequency;
	public int defaultDistance;
	public int defaultDamage;

	public int statusHp;
	public int statusSpeed;
	public int statusHpIncrease;
	public int statusMpIncrease;

	public int skillFireBall;
	public int skillWindCutter;
	public int skillTeleport;
	public int skillIceBlast;
	public int skillDarkFlash;
	public int skillThunderStroke;

	public int itemHp;
	public int itemMp;
	public int itemWand;
	public int itemHat;


	public void saveData() {
		PlayerPrefs.SetInt (curSlot + "", 1);

	}
		

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}


}
