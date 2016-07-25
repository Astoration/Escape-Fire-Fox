using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
    public float Speed = 5f;
    public GameObject Effect;
    private int skillLevel;
    private Vector2 direction;
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        skillLevel = PlayerPrefs.GetInt("IceBlastLevel", 1);
    }
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
    void Update()
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ShortAI") || other.gameObject.tag.Equals("LongAI"))
        {
            if (other.gameObject.tag.Equals("ShortAI"))
            {
                other.gameObject.GetComponent<shortAI>().DealDamage(50 + 60 * skillLevel);
            }
            else
            {
                other.gameObject.GetComponent<longAI>().DealDamage(50 + 60 * skillLevel);
            }
            Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
