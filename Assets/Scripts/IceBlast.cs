using UnityEngine;
using System.Collections;

public class IceBlast : MonoBehaviour {
    public float Speed = 5f;
    public GameObject Effect;
    private int skillLevel;
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        skillLevel = PlayerPrefs.GetInt("IceBlastLevel", 1);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
    public void SetRotation(float angle)
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("ShortAI") || other.gameObject.tag.Equals("LongAI"))
        {
            if (other.gameObject.tag.Equals("ShortAI"))
            {
                other.gameObject.GetComponent<shortAI>().onFreeze();
                other.gameObject.GetComponent<shortAI>().DealDamage(60 + 50 * skillLevel);
            }
            else
            {
                other.gameObject.GetComponent<longAI>().onFreeze();
                other.gameObject.GetComponent<longAI>().DealDamage(60 + 50 * skillLevel);
            }
            Instantiate(Effect, other.gameObject.transform.position, Quaternion.identity);
        }
    }
}
