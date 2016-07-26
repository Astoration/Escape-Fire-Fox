using UnityEngine;
using System.Collections;

public class shortAI : MonoBehaviour {
    public GameObject target;
    private float speed = 3f;
    private Animator animation;
    private float AttackTimer = 0f;
    public float AttackDelay = 1f;
    private float targetDistance = 0.6f;
    private int HP;
    private int Damage;
    public int DefaultHP;
    public int DefulatDamage;
    public int HPStageRatio;
    public int DamageStageRatio;
    private int Stage;
    public bool isBoom;
    public bool isMultiAnimation;
    private bool isFreeze = false;
    public GameObject ExplosionEffect;
	void Start () {
        animation = GetComponent<Animator>();
        Stage = PlayerPrefs.GetInt("currentStage", 1);
        HP = DefaultHP+Stage*HPStageRatio;
        Damage = DefulatDamage + Stage * DamageStageRatio;
        target = GameObject.FindGameObjectWithTag("Player");
	}
    IEnumerator Freeze()
    {
        isFreeze = true;
        yield return new WaitForSeconds(0.5f);
        isFreeze = false;
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
            SpawnManager.instance.GetMoney(HP + Damage * 5);
            Destroy(this.gameObject);
            return true;
        }
        HP -= DamageMount;
        return false;
    }
    void Update () {
        if (!isFreeze)
        {
            float step = speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, target.transform.position) > targetDistance)
            {
                AttackTimer = 0;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                if (isMultiAnimation)
                {
                    animation.SetBool("isRun", true);
                    animation.SetBool("isAttack", false);
                }
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
                AttackTimer += Time.deltaTime;
                if (AttackTimer >= AttackDelay)
                {
                    AttackTimer = 0;
                    StatusManager.instance.DealHP(Damage);
                    if (isBoom)
                    {
                        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
                        Destroy(this.gameObject);
                    }
                }
                if (isMultiAnimation)
                {
                    animation.SetBool("isRun", false);
                    animation.SetBool("isAttack", true);
                }
            }
        }
    }
}
