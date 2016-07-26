using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {
    public static SkillManager instance;
    public GameObject Wind, Ice, Thunder, Dark, FireBall;
    public GameObject Character;
    public Image left, bottom, top, right;
    public Queue<string> patternQueue;
    public Image ThunderEffect;
    private Animator CharAni;
    public GameObject[] Lines;
    private string[] 토네이도 = {  "왼위" , "위왼","위오" , "오왼" , "오아" ,  "아오" , "아왼" ,  "왼아"  };
    private string[] 아이스블래스트 = {  "왼위오", "오위왼" , "위오아","아오왼" ,  "오아왼" ,  "왼아오" ,  "아왼위", "위왼아"  };
    private string[] 썬더스트로크 = { "위왼오아" , "아오왼위"  };
    private string[] 다크플래시 = { "아위오" ,  "위아오" };
    private bool isTouch = false;
    IEnumerator AnimateAttack()
    {
        CharAni.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.5f);
        CharAni.SetBool("isAttack", false);
    }

    IEnumerator ThunderAlphaCounter()
    {
        for(int i = 0; i <= 155; i+=8)
        {
            ThunderEffect.color = new Color(0, 0, 0, i/255f);
            yield return new WaitForSeconds(0.0001f);
        }
        for(int i = 155; 0<= i; i-=8)
        {
            ThunderEffect.color = new Color(0, 0, 0, i/255f);
            yield return new WaitForSeconds(0.0001f);
        }
    }
    void Awake()
    {
        if(!instance)
            instance = this;
    }

	void Start () {
        patternQueue = new Queue<string>();
        Character = GameObject.FindGameObjectWithTag("Player");
        SoundManager.instance.Player(0);
        CharAni = Character.GetComponent<Animator>();
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
        if (patternQueue.Count != 0)
        {
            bool top=false, bottom=false, left=false, right=false;
            foreach(string tag in patternQueue)
            {
                switch (tag)
                {
                    case "위":
                        top = true;
                        break;
                    case "아":
                        bottom = true;
                        break;
                    case "오":
                        right = true;
                        break;
                    case "왼":
                        left = true;
                        break;
                }
            }
            foreach(GameObject line in Lines)
            {
                line.SetActive(false);
            }
            if (left && bottom) Lines[0].SetActive(true);
            if (left && top) Lines[1].SetActive(true);
            if (top && right) Lines[2].SetActive(true);
            if (right && bottom) Lines[3].SetActive(true);
            if (top && bottom) Lines[4].SetActive(true);
            if (left && right) Lines[5].SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject line in Lines)
            {
                line.SetActive(false);
            }
            if (patternQueue.Count == 1)
            {
                if (StatusManager.instance.UseMP(10))
                {
                    StartCoroutine(AnimateAttack());
                    switch (patternQueue.Dequeue())
                    {
                        case "위":
                            Instantiate(FireBall, Character.transform.position, Quaternion.Euler(new Vector3(0, 0, 270)));
                            break;
                        case "아":
                            Instantiate(FireBall, Character.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                            break;
                        case "오":
                            Instantiate(FireBall, Character.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                            break;
                        case "왼":
                            Instantiate(FireBall, Character.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                            break;

                    }
                }
                patternQueue.Clear();
            }
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
                    if (!StatusManager.instance.UseMP(20)) return;
                    StartCoroutine(AnimateAttack());
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
                    if (!StatusManager.instance.UseMP(30)) return;

                    StartCoroutine(AnimateAttack());
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
                    if (!StatusManager.instance.UseMP(40)) return;
                    StartCoroutine(AnimateAttack());
                    SoundManager.instance.Player(3);
                    GameObject[] longEnemys = GameObject.FindGameObjectsWithTag("LongAI");
                    GameObject[] shortEnemys = GameObject.FindGameObjectsWithTag("ShortAI");
                    StartCoroutine(ThunderAlphaCounter());
                    int ThunderLevel = saveManager.GetInt("ThunderStrokeLevel", 1);
                    foreach (GameObject enemy in longEnemys)
                    {
                        Instantiate(Thunder, enemy.transform.position, Quaternion.identity);
                        enemy.GetComponent<longAI>().DealDamage(220 + 60 * ThunderLevel);
                    }
                    foreach (GameObject enemy in shortEnemys)
                    {
                        Instantiate(Thunder, enemy.transform.position, Quaternion.identity);
                        enemy.GetComponent<shortAI>().DealDamage(220 + 60 * ThunderLevel);
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
                    if (!StatusManager.instance.UseMP(30)) return;
                    StartCoroutine(AnimateAttack());
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
