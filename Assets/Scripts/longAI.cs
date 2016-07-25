using UnityEngine;
using System.Collections;

public class longAI : MonoBehaviour {
    public GameObject target;
    private float speed = 3f;
    private Animator animation;
    private float targetDistance = 3f;
    public GameObject projectile;
    private float attackTimer = 0;
    public float attackDelay =1f;
    private int HP;
    public int DefaultHP;
    public int HPStageRatio;
    private int Stage;
    // Use this for initialization
    void Start () {
        Stage = PlayerPrefs.GetInt("currentStage", 1);
        HP = DefaultHP + Stage * HPStageRatio;
        target = GameObject.FindGameObjectWithTag("Player");
    }
    public bool DealDamage(int DamageMount)
    {
        if (HP <= DamageMount)
        {
            HP = 0;
            SpawnManager.instance.Kill();
            SpawnManager.instance.GetMoney(HP + 20 * 5);
            Destroy(this.gameObject);
            return true;
        }
        HP -= DamageMount;
        return false;
    }
    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.transform.position) > targetDistance)
        {
            attackTimer = 0;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            if (transform.position.x > target.transform.position.x)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x) * -1;
                transform.localScale = scale;
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
        else
        {
            Vector3 targetPos = target.transform.position;
            targetPos.x = transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position,targetPos, step);
            attackTimer += Time.deltaTime;
            if (attackDelay <= attackTimer)
            {
                if (transform.position.x > target.transform.position.x)
                {
                    ((GameObject)Instantiate(projectile, transform.position, Quaternion.identity)).GetComponent<Projectile>().SetDirection(-1);
                }
                else
                {
                    ((GameObject)Instantiate(projectile, transform.position, Quaternion.identity)).GetComponent<Projectile>().SetDirection(1);
                }
                attackTimer = 0f;
            }
        }
    }
}
