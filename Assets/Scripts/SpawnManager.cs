using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {
    public GameObject smallGolam, Bat, Pung, Golam, witch;
    public static SpawnManager instance;
    private int Count=0;
    private int Stage=1;
    public Image Bar;
    private int Round = 0;
    public GameObject ResultDialog;
    private int Money = 0;
    public Text text;
    public Text Mana;
    public Text Score;
    public Sprite[] Image;
    public GameObject Bg;
    public void GetMoney(int m)
    {
        Money += m;
        text.text = Money+"";
    }
    void Awake()
    {
        instance = this;
    }

    public void Kill()
    {
        Count -= 1;
        Vector3 BarPos = Bar.rectTransform.anchoredPosition;
        Debug.Log((((10 * (Round - 1)) + (10 - Count)) / 30.0f) * 360);
        BarPos.x = (((10*(Round-1))+(10-Count))/30.0f)*360;
        Bar.rectTransform.anchoredPosition = BarPos;
    }

	void Start () {
        Stage = PlayerPrefs.GetInt("stage", 1);
        Bg.GetComponent<SpriteRenderer>().sprite = Image[(Stage - 1) / 20];
    }

	IEnumerator Spawn()
    {
        Round += 1;
        if (1 <= Stage % 20 && Stage % 20 <= 5)
        {
            Count = 10;
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range((int)0, (int)2);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(smallGolam, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
        }
        if (6 <= Stage % 20 && Stage % 20 <= 10)
        {
            Count = 10;
            for (int i = 0; i < 6; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(smallGolam, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(Bat, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
        }
        if (11 <= Stage % 20 && Stage % 20 <= 15)
        {
            Count = 10;
            for (int i = 0; i < 5; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(smallGolam, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            for (int i = 0; i < 3; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(Bat, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            for (int i = 0; i < 2; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(Pung, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
        }
        if (16 <= Stage % 20 && Stage % 20 <= 20)
        {
            Count = 10;
            for (int i = 0; i < 3; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(smallGolam, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            for (int i = 0; i < 2; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(smallGolam, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            for (int i = 0; i < 3; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(Bat, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            for (int i = 0; i < 2; i++)
            {
                int rand = Random.Range((int)0, (int)1);
                int direction = 1;
                float randY = Random.Range(-3.86f, 2.57f);
                if (rand == 1) direction = -1;
                Vector3 pos = new Vector3(4.45f * direction, randY, -0.55f);
                Instantiate(Pung, pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            int randDirection = Random.Range((int)0, (int)1);
            int defaultDirection = 1;
            float randomY = Random.Range(-3.86f, 2.57f);
            if (randDirection == 1) defaultDirection = -1;
            Vector3 position = new Vector3(4.45f * defaultDirection, randomY, -0.55f);
            Instantiate(witch, position, Quaternion.identity);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Round == 3 && Count == 0)
        {
            Stage += 1;
            PlayerPrefs.SetInt("stage", Stage);
            ResultDialog.SetActive(true);
            Mana.text = Money + "";
            Score.text = (Money * 0.6254) + "";
        }
        if (Count == 0&&Round!=3)
            StartCoroutine(Spawn());
        
	}
    public void isDead()
    {
        ResultDialog.SetActive(true);
        Mana.text = Money + "";
        Score.text = (Money * 0.6254) + "";
    }
}
