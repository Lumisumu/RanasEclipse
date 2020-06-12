using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    Animator anime;
    public float maxHp;
    public float currentHp = 100f;
    private float damageHp = 0.3f;
    private float damageArmor = 0.7f;
    public float damage = 40f;
    private float targetHp;
    private float currentArmor = 0f;
    private float targetArmor;
    public float delay = 0.1f;
    public Text chpText;
    public Text thpText;
    public Text carmorText;
    public Text tarmorText;
    bool knockedBack = false;

    private Player theplayer;
    private Controller2D cont;
    private JoystickHandler jh;
    private PlayerInput pi;

    void Start()
    {
        theplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        maxHp = 75f;
        StartCoroutine(DelayFrame());
        cont = GetComponent<Controller2D>();
        anime = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(currentHp <= 0){
            //kuolemisanimaatiot ja muut
            Debug.Log("PLAYER DED!");
            SceneManager.LoadScene("GameOverScreen");
        }

        if(currentHp > maxHp){
            currentHp = maxHp;
        }
       

        /*
        if (Input.GetKey(KeyCode.P))
        {
            if (currentArmor == 0f)
            {
                if (currentHp >= 0f)
                {
                    currentHp -= 1f;
                    PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                }
            }
            else
            {
                currentArmor -= 1f;
                PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (currentHp <= 50f)
            {
                currentHp = currentHp + 50f;
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            }
            else
            {
                currentHp = 100f;
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            }

        }
        
       if (Input.GetKeyDown(KeyCode.U))
        {
            if (currentArmor <= 50f)
            {
                currentArmor = currentArmor + 50f;
                PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
            }
            else
            {
                currentArmor = 100f;
                PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
            }
        }
       if (Input.GetKeyDown(KeyCode.O))
        {
            if (currentArmor == 0f)
            {
                if (currentHp >= 25f)
                {
                    currentHp -= 25f;
                    PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                }
                else
                {
                    currentHp = 0f;
                    PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                }
            }
            else if (currentArmor <= 20f)
            {
                currentHp = currentHp - (20f - currentArmor) - 5f;
                currentArmor = 0f;
                PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            }
            else if (currentArmor > 20f)
            {
                currentArmor = currentArmor - 20f;
                currentHp = currentHp - 5f;
                PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            }
        }
       if (Input.GetKeyDown(KeyCode.T))
        {

            if (currentArmor > (damage * damageArmor))
            {
                targetHp = currentHp - (damage * damageHp);
                targetArmor = currentArmor - (damage * damageArmor);
                if (targetHp < 0f)
                {
                    targetHp = 0f;
                }
                chpText.text = ("Current HP " + currentHp);
                thpText.text = ("Target HP " + targetHp);
                carmorText.text = ("Current Armor " + currentArmor);
                tarmorText.text = ("Target Armor " + targetArmor);
                Debug.Log("targHP" + targetHp);
                Debug.Log("targArmor" + targetArmor);
            }
            else if (currentArmor <= (damage * damageArmor))
            {
                Debug.Log("Negative or zero armor");
                if (currentArmor == (damage * damageArmor))
                {
                    Debug.Log("Zero armor");
                    currentArmor = 0f;
                    targetArmor = 0f;
                    currentHp = currentHp - (damage * damageHp);
                    PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
                    PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                }
                else
                {
                    Debug.Log("Negative armor");
                    currentArmor = 0f;
                    targetArmor = 0f;
                    currentHp = currentHp - ((damage * damageHp) + ((damage * damageArmor) - currentArmor));
                    PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
                    PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                }
            }
            InvokeRepeating("DelayHPReduce", 0.1f, 0.1f);
            InvokeRepeating("DelayArmorReduce", 0.1f, 0.1f);
        }
     */   
    }
    
    IEnumerator DelayFrame()
    {
        yield return new WaitForSeconds(2);
    }
    void DelayHPReduce()
    {
        if (currentHp > targetHp)
        {
            currentHp -= 1f;
            PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            Debug.Log("hp " + currentHp.ToString("n2"));
        }
        else
        {
            CancelInvoke("DelayHPReduce");
        }
    }
    void DelayArmorReduce()
    {
        if (currentArmor > targetArmor)
        {
            currentArmor -= 1f;
            PlayerUIManager.Instance.UpdatePlayerArmorBar(currentArmor);
            Debug.Log("armor " + currentArmor.ToString("n2"));
        }
        else
        {
            CancelInvoke("DelayArmorReduce");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            currentHp += 25;
            PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            Destroy(other.gameObject);
        }

        if (knockedBack == false)
        {
            

            if (other.gameObject.CompareTag("SmallEnemyProjectile"))
            {
                currentHp -= 10;
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                Destroy(other.gameObject);
                StartCoroutine(Knockback());
            }

            if (other.gameObject.CompareTag("BigEnemyProjectile"))
            {
                currentHp -= 10;
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                Destroy(other.gameObject);
                StartCoroutine(Knockback());
            }

            if (other.CompareTag("DmgTrig"))
            {
                currentHp -= 15;
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
                StartCoroutine(Knockback());
            }
            if (other.CompareTag("Hazard"))
            {
                currentHp -= 0.15f;
                PlayerUIManager.Instance.UpdatePlayerHpBar(currentHp);
            }
        }
    }

    public IEnumerator Knockback()
    {
        knockedBack = true;

        if (GetComponent<PlayerInput>().lastDirecInput.x > 0.0f)
        {
            GameObject.Find("MasterUI").GetComponentInChildren<JoystickHandler>().thisbool = false;
            GameObject.Find("MasterUI").GetComponentInChildren<JoystickHandler>().InputDirection = new Vector3 (0,0,0);
            theplayer.GetComponent<Controller2D>().collisions.velocityOld = new Vector2(0, 0);
            theplayer.GetComponent<Player>().accelerationTimeGrounded = 0;
            theplayer.GetComponent<Player>().accelerationTimeAirborne = 0;
            theplayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            theplayer.transform.Translate(new Vector2(-1, 0.5f) * 3);
            anime.SetTrigger("TakeDmg");
        }
        if (GetComponent<PlayerInput>().lastDirecInput.x < 0.0f)
        {
            GameObject.Find("MasterUI").GetComponentInChildren<JoystickHandler>().thisbool = false;
            GameObject.Find("MasterUI").GetComponentInChildren<JoystickHandler>().InputDirection = new Vector3(0, 0, 0);
            theplayer.GetComponent<Controller2D>().collisions.velocityOld = new Vector2(0, 0);
            theplayer.GetComponent<Player>().accelerationTimeGrounded = 0;
            theplayer.GetComponent<Player>().accelerationTimeAirborne = 0;
            theplayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            theplayer.transform.Translate(new Vector2(1, 0.5f) * 3);
            anime.SetTrigger("TakeDmg");
        }

        yield return new WaitForSeconds(0.5f);
        anime.ResetTrigger("TakeDmg");
        theplayer.GetComponent<Player>().accelerationTimeGrounded = 0.1f;
        theplayer.GetComponent<Player>().accelerationTimeAirborne = 0.2f;
        GameObject.Find("MasterUI").GetComponentInChildren<JoystickHandler>().thisbool = true;
        knockedBack = false;
    }
}
