using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gc_PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    [SerializeField] private float damage;
    [SerializeField] private float MaxHp;
    [SerializeField] private float currentHp;

    private void Awake()
    {
        MaxHp = 1;
    }
    private void Update()
    {
            if(Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float HitPoints)
    {

        currentHp = MaxHp += HitPoints;
        HealthBar.fillAmount = MaxHp;
    }

    public IEnumerator lerpHPbar()
    {
        while(MaxHp > currentHp)
        {
            yield return null;
        }
    }
}
   
