﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Joystic : MonoBehaviour {
    public Image JoysticImage;
    public GameObject Character;
    public bool moveEnable = true;
    private Animator CharacterMoving;
    Vector2 distance = Vector2.zero;
    private float fireballChargingDelay = 0.15f;
    private float fireballChargingTimer = 0f;
    private int teleportSkillLevel;
    public GameObject fireBall;
    public GameObject magicMissile;
    public GameObject teleportPrefabs;
    public int Frequency = 1;
    private float missileDelay;
    private float missileTimer = 0f;
    public Camera camera;

    //private Vector3 
    // Use this for initialization
    void Start () {
        Frequency = PlayerPrefs.GetInt("defaultFrequency", 1);
        missileDelay = 1f / (float)Frequency;
        teleportSkillLevel = PlayerPrefs.GetInt("teleportSkillLevel", 1);
        CharacterMoving = Character.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        missileTimer += Time.deltaTime;
        CharacterMoving.SetFloat("velocity", Vector2.Distance(Vector2.zero, distance));
        if (distance.x > 0)
        {
            Vector3 scale = Character.transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1;
            Character.transform.localScale = scale;
        }
        else
        {
            Vector3 scale = Character.transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            Character.transform.localScale = scale;
        }
        if (moveEnable && (Input.touchCount>0 || Input.GetMouseButton(0)))
        {
            if (missileDelay < missileTimer)
            {
                missileTimer = 0;
                ((GameObject)Instantiate(magicMissile, Character.transform.position, Quaternion.identity)).GetComponent<MagicMissile>().SetDirection((distance * 0.03f));
            }
            if (fireballChargingTimer < fireballChargingDelay)
            {
                if(Vector2.Distance(Vector2.zero, distance) < 20&&0!= Vector2.Distance(Vector2.zero, distance))
                {
                    fireballChargingTimer += Time.deltaTime;
                }
                Character.transform.Translate((distance * 0.03f) * Time.deltaTime);
            }
            else
            {
                JoysticImage.color = new Color(255, 0, 0);
            }
            if (Vector2.Distance(Vector2.zero, distance) > 180f)
            {
                if (fireballChargingDelay < fireballChargingTimer)
                {
                    shootFireBall();
                    JoysticImage.rectTransform.localPosition = Vector2.zero;
                    distance = Vector2.zero;
                    moveEnable = false;
                }
                else
                {
                    JoysticImage.rectTransform.localPosition = Vector2.zero;
                    if (StatusManager.instance.UseMP(20))
                    {
                        Instantiate(teleportPrefabs, Character.transform.position, Quaternion.identity);
                        Vector2 teleport = distance * 0.01f;
                        Character.transform.Translate(teleport + (teleport * (teleportSkillLevel * 0.1f)));
                    }
                    distance = Vector2.zero;
                    moveEnable = false;
                }
            }       
        }

        camera.transform.localPosition = Character.transform.localPosition;
        if (camera.transform.localPosition.x < -3.15)
        {
            Vector3 pos = camera.transform.localPosition;
            pos.x = -3.15f;
            camera.transform.localPosition = pos;
        }
        if (camera.transform.localPosition.x > 3.09)
        {
            Vector3 pos = camera.transform.localPosition;
            pos.x = 3.09f;
            camera.transform.localPosition = pos;
        }
        if (camera.transform.localPosition.y < -1.36)
        {
            Vector3 pos = camera.transform.localPosition;
            pos.y = -1.36f;
            camera.transform.localPosition = pos;
        }
        if (camera.transform.localPosition.y > 1.37)
        {
            Vector3 pos = camera.transform.localPosition;
            pos.y = 1.37f;
            camera.transform.localPosition = pos;
        }
        if (Character.transform.localPosition.x < -4.46)
        {
            Vector3 pos = Character.transform.localPosition;
            pos.x = -4.46f;
            Character.transform.localPosition = pos;
        }
        if (Character.transform.localPosition.x > 4.45)
        {
            Vector3 pos = Character.transform.localPosition;
            pos.x = 4.45f;
            Character.transform.localPosition = pos;
        }
        if (Character.transform.localPosition.y < -3.86)
        {
            Vector3 pos = Character.transform.localPosition;
            pos.y = -3.86f;
            Character.transform.localPosition = pos;
        }
        if (Character.transform.localPosition.y > 2.57)
        {
            Vector3 pos = Character.transform.localPosition;
            pos.y = 2.57f;
            Character.transform.localPosition = pos;
        }
    }
    void shootFireBall()
    {
        if (StatusManager.instance.UseMP(10))
        {
            float dx = distance.x;
            float dy = distance.y;
            float rad = Mathf.Atan2(dx, dy);
            float angle = Mathf.Rad2Deg * rad + 180;
            Instantiate(fireBall, Character.transform.position, Quaternion.Euler(0,0,angle));
        }
    }
    public void OnDrag()
    {
        if (moveEnable == true)
        {
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);
                JoysticImage.rectTransform.position = t.position;
                distance = JoysticImage.rectTransform.localPosition;
            }
            else
            {
                JoysticImage.rectTransform.position = Input.mousePosition;
                distance = JoysticImage.rectTransform.localPosition;
            }
        }
        else if (Vector2.Distance(Vector2.zero, distance) < 180f)
        {
            moveEnable = true;
        }

    }
    public void OnEndDrag()
    {
        JoysticImage.rectTransform.localPosition = Vector3.zero;
        distance = Vector2.zero;
        if (fireballChargingDelay< fireballChargingTimer&&moveEnable)
            shootFireBall();
        fireballChargingTimer = 0f;
        moveEnable = true;
        JoysticImage.color = new Color(255, 255, 255);
    }

}
