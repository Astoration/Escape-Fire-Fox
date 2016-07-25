using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {
    public static SkillManager instance;
    public GameObject Wind, Ice, Thunder, Dark;
    public GameObject Character;
    public Image left, bottom, top, right;
    public Queue<string> patternQueue;
    private string[] 토네이도 = {  "왼위" , "위왼","위오" , "오왼" , "오아" ,  "아오" , "아왼" ,  "왼아"  };
    private string[] 아이스블래스트 = {  "왼위오", "오위왼" , "위오아","아오왼" ,  "오아왼" ,  "왼아오" ,  "아왼위", "위왼아"  };
    private string[] 썬더스트로크 = { "위왼오아" , "아오왼위"  };
    private string[] 다크플래시 = { "아위오" ,  "위아오" };
    private bool isTouch = false;

    void Awake()
    {
        if(!instance)
            instance = this;
    }

	void Start () {
        patternQueue = new Queue<string>();
        Character = GameObject.FindGameObjectWithTag("Player");
        SoundManager.instance.Player(0);
	}

	public void insertQueue(string tag)
    {
        foreach(string temp in patternQueue)
        {
            if (temp.Equals(tag))
            {
                return;
            }
        }
        patternQueue.Enqueue(tag);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < 토네이도.Length; i++)
            {
                bool isTry = false;
                string check = "";
                foreach(string tag in patternQueue)
                {
                    check += tag;
                }
                isTry = check.Equals(토네이도[i]);
                if (isTry)
                {
                    SoundManager.instance.Player(4);
                    switch (i / 2)
                    {
                        case 0:
                            ((GameObject)Instantiate(Wind, Character.transform.position, Quaternion.identity)).GetComponent<Wind>().SetDirection(new Vector2(-1, 1));
                            break;
                        case 1:
                            ((GameObject)Instantiate(Wind, Character.transform.position, Quaternion.identity)).GetComponent<Wind>().SetDirection(new Vector2(1, 1));
                            break;
                        case 2:
                            ((GameObject)Instantiate(Wind, Character.transform.position, Quaternion.identity)).GetComponent<Wind>().SetDirection(new Vector2(1, -1));
                            break;
                        case 3:
                            ((GameObject)Instantiate(Wind, Character.transform.position, Quaternion.identity)).GetComponent<Wind>().SetDirection(new Vector2(-1, -1));
                            break;
                    }
                }
            }
            for (int i = 0; i < 아이스블래스트.Length; i++)
            {
                bool isTry = false;
                string check = "";
                foreach (string tag in patternQueue)
                {
                    check += tag;
                }
                isTry = check.Equals(아이스블래스트[i]);
                if (isTry)
                {
                    SoundManager.instance.Player(4);
                    switch (i / 2)
                    {
                        case 0:
                            ((GameObject)Instantiate(Ice, Character.transform.position, Quaternion.identity)).GetComponent<IceBlast>().SetRotation(-90);
                            break;
                        case 1:
                            ((GameObject)Instantiate(Ice, Character.transform.position, Quaternion.identity)).GetComponent<IceBlast>().SetRotation(-180);
                            break;
                        case 2:
                            ((GameObject)Instantiate(Ice, Character.transform.position, Quaternion.identity)).GetComponent<IceBlast>().SetRotation(-270);
                            break;
                        case 3:
                            ((GameObject)Instantiate(Ice, Character.transform.position, Quaternion.identity)).GetComponent<IceBlast>().SetRotation(0);
                            break;
                    }
                }
            }
            for(int i = 0; i < 2; i++)
            {
                bool isTry = false;
                string check = "";
                foreach (string tag in patternQueue)
                {
                    check += tag;
                }
                isTry = check.Equals(썬더스트로크[i]);
                if (isTry)
                {
                    SoundManager.instance.Player(3);
                    GameObject[] longEnemys = GameObject.FindGameObjectsWithTag("LongAI");
                    GameObject[] shortEnemys = GameObject.FindGameObjectsWithTag("ShortAI");
                    int ThunderLevel = saveManager.GetInt("ThunderStrokeLevel", 1);
                    foreach (GameObject enemy in longEnemys)
                    {
                        enemy.GetComponent<longAI>().DealDamage(220 + 60 * ThunderLevel);
                        Instantiate(Thunder, Character.transform.position, Quaternion.identity);
                    }
                    foreach (GameObject enemy in shortEnemys)
                    {
                        enemy.GetComponent<shortAI>().DealDamage(220 + 60 * ThunderLevel);
                        Instantiate(Thunder, Character.transform.position, Quaternion.identity);
                    }
                }
            }
            for (int i = 0; i < 2; i++)
            {
                bool isTry = false;
                string check = "";
                foreach (string tag in patternQueue)
                {
                    check += tag;
                }
                isTry = check.Equals(다크플래시[i]);
                if (isTry)
                {
                    SoundManager.instance.Player(3);
                    GameObject[] longEnemys = GameObject.FindGameObjectsWithTag("LongAI");
                    GameObject[] shortEnemys = GameObject.FindGameObjectsWithTag("ShortAI");
                    int ThunderLevel = saveManager.GetInt("ThunderStroke", 1);
                    Instantiate(Dark, Character.transform.position, Quaternion.identity);
                    foreach (GameObject enemy in longEnemys)
                    {
                        if (Vector2.Distance(Character.transform.position, enemy.transform.position)<1.5f)
                            enemy.GetComponent<longAI>().DealDamage(220 + 60 * ThunderLevel);
                    }
                    foreach (GameObject enemy in shortEnemys)
                    {
                        if (Vector2.Distance(Character.transform.position, enemy.transform.position) < 1.5f)
                            enemy.GetComponent<shortAI>().DealDamage(220 + 60 * ThunderLevel);
                    }
                }
            }
            isTouch = false;
            patternQueue.Clear();
        }
	}
}
