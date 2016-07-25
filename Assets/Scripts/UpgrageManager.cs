using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UpgrageManager : MonoBehaviour {
	public static UpgrageManager instance;


	void Awake() {
		if (UpgrageManager.instance == null)
			UpgrageManager.instance = this;
	}

	Dictionary<string,string> iconName = new Dictionary<string,string> ();
	Dictionary<string,string> iconContent = new Dictionary<string,string> ();
    Dictionary<string, int> iconValue = new Dictionary<string, int>();
    Dictionary<string, int> iconValueIncrease = new Dictionary<string, int>();
    Dictionary<string, int> iconMoney = new Dictionary<string, int>();
    Dictionary<string, int> iconMoneyIncrease = new Dictionary<string, int>();



	// Use this for initialization
	void Start () {
        saveManager.Save();
        //saveManager.SetInt("money", 1000000);
		iconName.Add ("defaultFrequency", "빈도 증가");
        iconContent.Add("defaultFrequency", "매직미사일의 발사 빈도를 높여준다.");
        iconValue.Add("defaultFrequency", 1);
        iconValueIncrease.Add("defaultFrequency", 1);
        iconMoney.Add("defaultFrequency", 1000);
        iconMoneyIncrease.Add("defaultFrequency", 0);
        iconName.Add("defaultDistance", "거리 증가");
        iconContent.Add("defaultDistance", "매직미사일의 사정거리를 증가시킵니다.");
        iconValue.Add("defaultDistance", 100);
        iconValueIncrease.Add("defaultDistance", 10);
        iconMoney.Add("defaultDistance", 1000);
        iconMoneyIncrease.Add("defaultDistance", 500);
        iconName.Add("defaultDamage", "데미지 증가");
        iconContent.Add("defaultDamage", "매직미사일의 데미지를 증가시킵니다.");
        iconValue.Add("defaultDamage", 20);
        iconValueIncrease.Add("defaultDamage", 10);
        iconMoney.Add("defaultDamage", 500);
        iconMoneyIncrease.Add("defaultDamage", 500);

        iconName.Add("statusHp", "체력 증가");
        iconContent.Add("statusHp", "캐릭터의 체력이 증가합니다.");
        iconValue.Add("statusHp", 50);
        iconValueIncrease.Add("statusHp", 50);
        iconMoney.Add("statusHp", 400);
        iconMoneyIncrease.Add("statusHp", 400);
        iconName.Add("statusSpeed", "속도 증가");
        iconContent.Add("statusSpeed", "캐릭터의 속도가 증갑합니다.");
        iconValue.Add("statusSpeed", 100);
        iconValueIncrease.Add("statusSpeed", 10);
        iconMoney.Add("statusSpeed", 500);
        iconMoneyIncrease.Add("statusSpeed", 500);
        iconName.Add("statusHpIncrease", "체력회복 증가");
        iconContent.Add("statusHpIncrease", "캐릭터의 5초당 체력 회복량이 증가합니다.");
        iconValue.Add("statusHpIncrease", 5);
        iconValueIncrease.Add("statusHpIncrease", 3);
        iconMoney.Add("statusHpIncrease", 300);
        iconMoneyIncrease.Add("statusHpIncrease", 300);
        iconName.Add("statusMpIncrease", "마나회복 증가");
        iconContent.Add("statusMpIncrease", "캐릭터의 5초당 마나 회복량이 증가합니다.");
        iconValue.Add("statusMpIncrease", 3);
        iconValueIncrease.Add("statusMpIncrease", 1);
        iconMoney.Add("statusMpIncrease", 500);
        iconMoneyIncrease.Add("statusMpIncrease", 500);

        iconName.Add("skillFireBall", "파이어볼");
        iconContent.Add("skillFireBall", "가운데를 눌러 차징후 원하는 방향에 파이어볼을 날립니다.");
        iconValue.Add("skillFireBall", 50);
        iconValueIncrease.Add("skillFireBall", 35);
        iconMoney.Add("skillFireBall", 500);
        iconMoneyIncrease.Add("skillFireBall", 500);
        iconName.Add("skillWindCutter", "윈드 커터");
        iconContent.Add("skillWindCutter", "대각선으로 패턴을 입력해 해당 방향으로 바람을 날립니다.");
        iconValue.Add("skillWindCutter", 80);
        iconValueIncrease.Add("skillWindCutter", 45);
        iconMoney.Add("skillWindCutter", 700);
        iconMoneyIncrease.Add("skillWindCutter", 700);
        iconName.Add("skillTeleport", "텔레포트");
        iconContent.Add("skillTeleport", "이동 조이스틱을 바깥원까지 드래그하면 해당 방향으로 순간이동 합니다.");
        iconValue.Add("skillTeleport", 100);
        iconValueIncrease.Add("skillTeleport", 10);
        iconMoney.Add("skillTeleport", 800);
        iconMoneyIncrease.Add("skillTeleport", 800);
        iconName.Add("skillIceBlast", "아이스블래스트");
        iconContent.Add("skillIceBlast", "바깥쪽으로 3개의 패턴을 연결 시켜 해당 방향으로 ");
        iconValue.Add("skillIceBlast", 150);
        iconValueIncrease.Add("skillIceBlast", 70);
        iconMoney.Add("skillIceBlast", 1000);
        iconMoneyIncrease.Add("skillIceBlast", 1000);
        iconName.Add("skillDarkFlash", "다크플래시");
        iconContent.Add("skillDarkFlash", "위아래 와 우로 패턴을 연결시켜 자신 주변에 있는 모든 적에게 피해를 입힙니다.");
        iconValue.Add("skillDarkFlash", 200);
        iconValueIncrease.Add("skillDarkFlash", 80);
        iconMoney.Add("skillDarkFlash", 1000);
        iconMoneyIncrease.Add("skillDarkFlash", 1000);
        iconName.Add("skillThunderStroke", "썬더스트로크");
        iconContent.Add("skillThunderStroke", "카메라 내에 있는 모든 적에게 번개를 내리 칩니다.");
        iconValue.Add("skillThunderStroke", 400);
        iconValueIncrease.Add("skillThunderStroke", 100);
        iconMoney.Add("skillThunderStroke", 1500);
        iconMoneyIncrease.Add("skillThunderStroke", 1500);

        iconName.Add("itemHp", "체력포션");
        iconContent.Add("itemHp", "체력을 절반 회복시켜주는 물약이다.");
        iconValue.Add("itemHp", 0);
        iconValueIncrease.Add("itemHp", 1);
        iconMoney.Add("itemHp", 250);
        iconMoneyIncrease.Add("itemHp", 0);
        iconName.Add("itemMp", "마나포션");
        iconContent.Add("itemMp", "마나를 절반 회복시켜주는 물약이다.");
        iconValue.Add("itemMp", 0);
        iconValueIncrease.Add("itemMp", 1);
        iconMoney.Add("itemMp", 250);
        iconMoneyIncrease.Add("itemMp", 0);
        iconName.Add("itemWand", "마녀의 지팡이");
        iconContent.Add("itemWand", "모든 공격의 대미지를 증가시켜준다.");
        iconValue.Add("itemWand", 5);
        iconValueIncrease.Add("itemWand", 5);
        iconMoney.Add("itemWand", 1000);
        iconMoneyIncrease.Add("itemWand", 1000);
        iconName.Add("itemHat", "마녀의 모자");
        iconContent.Add("itemHat", "모든 피해의 대미지를 감소시켜준다.");
        iconValue.Add("itemHat", 2);
        iconValueIncrease.Add("itemHat", 2);
        iconMoney.Add("itemHat", 1000);
        iconMoneyIncrease.Add("itemHat", 1000);
	}

    public Text moneyText;
    public Text costText;
    public Text stageText;
    public Text selectlevelText;
    public Text selectNameText;
    public Text selectContentText;

    public Canvas defaultCanvas;
    public Canvas statusCanvas;
    public Canvas skillCanvas;
    public Canvas itemCanvas;

    public string curName;

    //public text curText;

	// Update is called once per frame
	void Update () {
		moneyText.text = saveManager.GetInt ("money", 0).ToString ();
		stageText.text = saveManager.GetInt ("stage", 1).ToString();
	}

	public void SelectIcon(string name) {
        selectlevelText.text = saveManager.GetInt(name, 0).ToString();
        selectNameText.text = iconName[name];

        saveManager.SetInt(name + "Mount", getMount(name, 0));
        selectContentText.text = iconContent[name] + '\n' + getMount(name, 0) + "->" + getMount(name, 1);
        costText.text = (iconMoney[name] + iconMoneyIncrease[name] * saveManager.GetInt(name, 1)).ToString();
        curName = name;
	}
    
    int getMount(string name, int nextLevel)
    {
        return iconValue[name] + iconValueIncrease[name] * (saveManager.GetInt(name, 1) + nextLevel - 1);
    }

	public void UpgradeIcon() {
        if (saveManager.GetInt("money", 0) >= int.Parse(costText.text))
        {
            saveManager.SetInt(curName, saveManager.GetInt(curName, 1) + 1);
            saveManager.SetInt("money", saveManager.GetInt("money", 0) - int.Parse(costText.text));
            saveManager.Save();
            print(saveManager.GetInt(curName, 1));
            this.SelectIcon(curName);
        }
	}

    public void chageTap(Canvas c)
    {
        c.gameObject.SetActive(true);
        if (c != defaultCanvas) 
            defaultCanvas.gameObject.SetActive(false);
        if (c != statusCanvas)
            statusCanvas.gameObject.SetActive(false);
        if (c != skillCanvas)
            skillCanvas.gameObject.SetActive(false);
        if (c != itemCanvas)
            itemCanvas.gameObject.SetActive(false);
    }

}
