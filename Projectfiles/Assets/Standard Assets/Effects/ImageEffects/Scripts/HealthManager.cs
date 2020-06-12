using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    private float currentHp = 100f;
    private float damageHp = 0.3f;
    private float damageArmor = 0.7f;
    public float damage = 40f;
    private float targetHp;
    private float currentArmor = 100f;
    private float targetArmor;
    public float delay = 0.1f;
    public Text chpText;
    public Text thpText;
    public Text carmorText;
    public Text tarmorText;
    public GameObject joku;
    

    
    void Start()
    {
        //StartCoroutine(DelayFrame());
    }
    
    /*void Update()
    {

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
                /*chpText.text = ("Current HP " + currentHp);
                thpText.text = ("Target HP " + targetHp);
                carmorText.text = ("Current Armor " + currentArmor);
                tarmorText.text = ("Target Armor " + targetArmor);*//*
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
    */
}
