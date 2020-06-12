using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour {

    [SerializeField]
    private HealthBar healthBar;

    private static PlayerUIManager instance;

    public static PlayerUIManager Instance
    {
        get
        {
            if(null != instance)
            {
                return instance;
            }

            GameObject singletons = GameObject.Find("Singletons");
            if (null == singletons)
            {
                singletons = new GameObject("Singletons");
            }
            instance = singletons.AddComponent<PlayerUIManager>();
            return instance;
        }
    }
    void Awake() {
        instance = this;
		
	}
	
    public void UpdatePlayerHpBar(float aCurrentHp)
    {
        healthBar.UpdateHealth(aCurrentHp);
    }
    public void UpdatePlayerArmorBar(float aCurrentArmor)
    {
        healthBar.UpdateArmor(aCurrentArmor);
    }
    /*public void UpdateHPNumber(float aHPNumber)
    {
        testStub.GetComponents<Text>(aHPNumber);
    }*/
}
