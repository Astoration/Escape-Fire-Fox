using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour {
    public Image HPBar;
    public Image MPBar;
    public static StatusManager instance;
    private float HP=50;
    private float MP=80;
    private float MAX_HP = 100;
    private float MAX_MP = 80;
    public Text ConsoleLog;

    void Awake()
    {
        if (!instance)
            instance = this;
    }
    public bool DealHP(int dealMount)
    {
        if (HP <= dealMount)
        {
            HP = 0;
            SpawnManager.instance.isDead();
            return true;
        }
        HP -= dealMount;
        applyBar();
        return false;
    }
    public bool UseMP(int useMount)
    {
        if (MP < useMount)
            return false;
        MP -= useMount;
        applyBar();
        return true;
    }

	// Use this for initialization
	void Start () {
        HP = 50 + PlayerPrefs.GetInt("itemHp", 1) * 50;
	}
    void applyBar()
    {
        float HPPercentage = Mathf.Round((1f-(HP / MAX_HP))*10)/10f;
        float MPPercentage = Mathf.Round((1f-(MP / MAX_MP))*10)/10f;
        HPBar.rectTransform.rotation = Quaternion.Euler(0, 0, 180 * HPPercentage);
        MPBar.rectTransform.rotation = Quaternion.Euler(0, 0, -180 * MPPercentage);   
    }
	// Update is called once per frame
	void Update () {
        healHP(0.6f * Time.deltaTime);
        healMP(2 * Time.deltaTime);
	}
    public void healMP(float mount)
    {
        MP += mount;
        if (MAX_MP < MP) MP = MAX_MP;
        applyBar();
    }
    public void healHP(float mount)
    {
        HP += mount*100;
        if (MAX_HP < HP) HP = MAX_HP;
        applyBar();
    }

    public void healHalfMP()
    {
        MP += MAX_MP/2;
        if (MAX_MP < MP) MP = MAX_MP;
        applyBar();
    }
    public void healHalfHP()
    {
        HP += MAX_HP/2;
        if (MAX_HP < HP) HP = MAX_HP;
        applyBar();
    }
}
