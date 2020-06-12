using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private Image healthBarImage;
    [SerializeField]
    private Image armorBarImage;

    [SerializeField]
    private float testValue = 1f;

    public float maxHP;
    private float minHp = 0f;

    private float maxArmor = 100f;

    void Start ()
    {
        maxHP = 75f;
    }

    public void UpdateHealth(float aCurrentHp)
    {
        // laskee fillamountin, fillamount voi olla vain 0-1
        float currentHpBarValue = aCurrentHp / maxHP;
        healthBarImage.fillAmount = currentHpBarValue;
    }
    public void UpdateArmor(float aCurrentArmor)
    {
        float currentArmorBarValue = aCurrentArmor / maxArmor;
        armorBarImage.fillAmount = currentArmorBarValue;
    }

    /*
    private void Update()
    {
        healthBarImage.fillAmount = testValue;
    }
    */


}
