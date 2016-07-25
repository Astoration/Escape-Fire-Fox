using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    private float Speed = 7f;
    private int direction = -1;
    private int stage;
	// Use this for initialization
	void Start () {
        stage = PlayerPrefs.GetInt("currentStage", 1);
	}
	public void SetDirection(int i)
    {
        this.direction = i;
        this.transform.localScale = new Vector2(-i, 1);
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(Speed * Time.deltaTime * new Vector2(direction,0));
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StatusManager.instance.DealHP(5+stage);
            Destroy(this.gameObject);
        }
    }
}
