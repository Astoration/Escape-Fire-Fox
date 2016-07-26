using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
    public float Speed = 5f;
    public GameObject Effect;
    private int skillLevel;
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
	// Use this for initialization
	void Start () {
        skillLevel = PlayerPrefs.GetInt("FireBallLevel", 1);
	}
	    
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("ShortAI")|| other.gameObject.tag.Equals("LongAI"))
        {
            if (other.gameObject.tag.Equals("ShortAI"))
            {
                other.gameObject.GetComponent<shortAI>().DealDamage(80 + 70 * skillLevel);
            }
            else
            {
                other.gameObject.GetComponent<longAI>().DealDamage(80 + 70 * skillLevel);
            }
            Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
