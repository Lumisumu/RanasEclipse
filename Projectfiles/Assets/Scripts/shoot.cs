using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shoot : MonoBehaviour {
    private bool ammu_bool = false;

    SpriteRenderer SR;
    Animator anim;
    
    bool isPressed = false;
    public AudioClip shootAud;
    public AudioSource AudioSource;

    public float fireRate = 0;
    public float Damage = 10;
    float timeToFire = 10;

    public Text m_Text;
    public Text m_Text2;

    public Transform spawnPoint;
    public Transform spawnPoint2;
    Vector2 bulletDir;
    Vector2 ClickedPos;

    public GameObject JS_hitbox;
    
    public GameObject bulleprefab;
    public float speed = 100;

    private float nextFire;

    // Use this for initialization
    void Start() {
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (ammu_bool == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            anim.SetBool("IsShoottinks", true);
       

            if (gameObject.GetComponent<PlayerInput>().direcInput3.y == 0.0f && gameObject.GetComponent<PlayerInput>().direcInput3.x == 0.0f && gameObject.GetComponent<Player>().onAir == false)
            {
                Vector2 spawnPoint_xy = new Vector2(spawnPoint2.position.x, spawnPoint2.position.y);

                Vector2 JoyDirection = gameObject.GetComponent<PlayerInput>().lastDirecInput;

                Vector3 diff = gameObject.GetComponent<PlayerInput>().lastDirecInput;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                spawnPoint.rotation = Quaternion.Euler(0f, 0f, rot_z);

                //AudioSource.PlayOneShot(shootAud, 0.5f);
                //AudioSource.PlayClipAtPoint(shootAud, new Vector3(0, 0, 0));

                GameObject bullet = Instantiate(bulleprefab, spawnPoint_xy, spawnPoint.rotation) as GameObject;

                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

                rigidbody.AddForce(JoyDirection * speed * 15);
            }
            else
            {

                Vector2 spawnPoint_xy = new Vector2(spawnPoint.position.x, spawnPoint.position.y);

                Vector2 JoyDirection = gameObject.GetComponent<PlayerInput>().lastDirecInput;

                Vector3 diff = gameObject.GetComponent<PlayerInput>().lastDirecInput;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                spawnPoint.rotation = Quaternion.Euler(0f, 0f, rot_z);

                //AudioSource.PlayOneShot(shootAud, 0.5f);
                //AudioSource.PlayClipAtPoint(shootAud, new Vector3(0, 0, 0));

                GameObject bullet = Instantiate(bulleprefab, spawnPoint_xy, spawnPoint.rotation) as GameObject;

                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

                rigidbody.AddForce(JoyDirection * speed * 15);

            }
        }
        //print("isPressed: " + isPressed);

        
    }

    public void AmmuNapista()
    {
        ammu_bool = true;
    }
    public void SetAmmuBoolFalse()
    {
        ammu_bool = false;
        anim.SetBool("IsShoottinks", false);
    }

    public void SetPoolTrue()
    {
        isPressed = true;
    }

    public void SetPoolFalse()
    {
        isPressed = false;    
    }


}


