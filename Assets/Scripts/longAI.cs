using UnityEngine;
using System.Collections;

public class longAI : MonoBehaviour {
    public GameObject target;
    private float speed = 3f;
    private Animator animation;
    public float targetDistance = 3f;
    public GameObject projectile;
    public bool isWitch = false;
    private float attackTimer = 0;
    public float attackDelay =1f;
    private int HP;
    public int DefaultHP;
    public int HPStageRatio;
    private int Stage;
    private bool isFreeze = false;
    // Use this for initialization
    void Start () {
        Stage = PlayerPrefs.GetInt("currentStage", 1);
        HP = DefaultHP + Stage * HPStageRatio;
        target = GameObject.FindGameObjectWithTag("Player");
        animation = GetComponent<Animator>();
    }
    IEnumerator Freeze()
    {
        isFreeze = true;
        yield return new WaitForSeconds(0.5f);
        isFreeze = false;
    }
    IEnumerator AnimateAttack()
    {
        animation.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.5f);
        animation.SetBool("isAttack", false);
    }
    public void onFreeze()
    {
        StartCoroutine(Freeze());
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
        if (!isFreeze)
        {
            float step = speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, target.transform.position) > targetDistance)
            {
                attackTimer = 0;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                if (transform.position.x > target.transform.position.x)
                {
                    Vector3 scale = transform.localScale;
                    scale.x = Mathf.Abs(scale.x) * -1;
                    if(isWitch)
                        scale.x = Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
                else
                {
                    Vector3 scale = transform.localScale;
                    scale.x = Mathf.Abs(scale.x);
                    if (isWitch)
                        scale.x = Mathf.Abs(scale.x)*-1;
                    transform.localScale = scale;
                }
            }
            else
            {
                Vector3 targetPos = target.transform.position;
                targetPos.x = transform.position.x;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
                attackTimer += Time.deltaTime;
                if (attackDelay <= attackTimer)
                {
                    if(isWitch)
                        StartCoroutine(AnimateAttack());
                    if (transform.position.x > target.transform.position.x)
                    {
                        int direction = -1;
                        if (isWitch) direction = 1;
                        ((GameObject)Instantiate(projectile, transform.position, Quaternion.identity)).GetComponent<Projectile>().SetDirection(direction);
                    }
                    else
                    {
                        int direction = 1;
                        if (isWitch) direction = -1;
                        ((GameObject)Instantiate(projectile, transform.position, Quaternion.identity)).GetComponent<Projectile>().SetDirection(direction);
                    }
                    attackTimer = 0f;
                }
            }
        }
    }
}
