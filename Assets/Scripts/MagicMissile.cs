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
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
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
