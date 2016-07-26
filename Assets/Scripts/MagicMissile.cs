using UnityEngine;
using System.Collections;

public class MagicMissile : MonoBehaviour {
    public float Speed = 5f;
    private int skillLevel;
    private Vector3 direction;
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start()
    {
        skillLevel = PlayerPrefs.GetInt("FireBallLevel", 1);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("ShortAI") || other.gameObject.tag.Equals("LongAI"))
        {
            if (other.gameObject.tag.Equals("ShortAI"))
            {
                other.gameObject.GetComponent<shortAI>().DealDamage(20 * skillLevel);
            }
            else
            {
                other.gameObject.GetComponent<longAI>().DealDamage(20 * skillLevel);
            }
            Destroy(this.gameObject);
        }
    }
}
