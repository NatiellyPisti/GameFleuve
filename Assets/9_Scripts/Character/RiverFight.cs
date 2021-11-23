using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverFight : BattleActor
{
    [SerializeField]
    VCamController vcamController;
    Vida health;
    public BattleManager battleManager;

    new void Awake()
    {
        base.Awake();
        health = GetComponent<Vida>();
    }

    void OnEnable()
    {
        GameManager.instance.LoadGamplayStuffs();
        Debug.Log($"current health{GameManager.instance.CurrentGameData.CurrentPlayerHealth}");
        //GameManager.instance.GetHealthBar.SetHealth(GameManager.instance.CurrentGameData.CurrentPlayerHealth);
        //Debug.Log($"current health{GameManager.instance.CurrentGameData.CurrentPlayerHealth}");
        //GameManager.instance.LastSceneName = "Battle";
    }

    void Update()
    {
        if(ImDead)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("Death");
                battleManager.GameOver();
            }
            return;
        }
    }

    void ShakeCamera() => vcamController.Shake();

    public void GetDamage()
    {
        anim.SetTrigger("Hurt");
    }

    void MakeDamage()
    {
        if(ImDead) return;
        BattleManager.instance.GetBattleEnemy.GetDamage(damage);
    }

    public void Attack()
    {
        if(ImDead) return;
        anim.SetTrigger("Attack");
    }

    public void Defense()
    {
        if(ImDead){
            Defend=false;
            return;
        } 
        anim.SetTrigger("Defense");
        Defend=true;

    }

    bool ImDead => health.CurrentHealth == 0;
    public static bool Defend;
}
