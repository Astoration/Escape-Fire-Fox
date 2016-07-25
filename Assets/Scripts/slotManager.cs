using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class slotManager : MonoBehaviour {
    public int slotNum;
    public Image showNewGame;
    public Canvas showLoadGame;
    public Text showStageNum;
    int curStage, baseSlotNum;


	// Use this for initialization
	void Start () {
        baseSlotNum = slotNum;
        slotNum = PlayerPrefs.GetInt(baseSlotNum + "slot", slotNum);
        curStage = PlayerPrefs.GetInt(slotNum + "stage", 0);
        if (curStage == 0)
        {
            showNewGame.gameObject.SetActive(true);
            showLoadGame.gameObject.SetActive(false);
        }
        else
        {
            showNewGame.gameObject.SetActive(false);
            showLoadGame.gameObject.SetActive(true);
            showStageNum.text = curStage + "";
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void selectSlot()
    {
        saveManager.curSlot = slotNum;
        if (curStage == 0)
        {
            saveManager.SetInt("stage", 1);
            saveManager.SetInt("money", 1000);
            saveManager.SetInt("defaultDamage", 1);
            saveManager.SetInt("defaultDistance", 1);
            saveManager.SetInt("defaultFrequency", 1);
            saveManager.SetInt("statusHp", 1);
            saveManager.SetInt("statusSpeed", 1);
            saveManager.SetInt("statusHpIncrease", 1);
            saveManager.SetInt("statusMpIncrease", 1);
            saveManager.SetInt("skillFireBall", 1);
            saveManager.Save();
        }
        Application.LoadLevel("upgradeScene");
    }

    public void deleteSlot()
    {
        //if (UnityEditor.EditorUtility.DisplayDialog("데이터 삭제","정말로 데이터를 삭제하시겠습니까?", "Yes", "No"))
        //{
            slotNum += 3;
            curStage = 0;
            PlayerPrefs.SetInt(baseSlotNum + "slot", slotNum);
            PlayerPrefs.Save();
            showNewGame.gameObject.SetActive(true);
            showLoadGame.gameObject.SetActive(false);
        //}
        //else
        //{
            
        //}
    }

}
