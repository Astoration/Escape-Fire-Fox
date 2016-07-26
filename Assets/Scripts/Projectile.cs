using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float Speed = 7f;
    public int defaultDamage;
    public int damageRatio;
    private int direction = -1;
    private int stage;
    // Use this for initialization
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("ㅅ;빌");
            StatusManager.instance.DealHP(defaultDamage+stage*damageRatio);
        }
    }
}
