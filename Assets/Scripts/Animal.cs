using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour 
{
    public int curHp;
    public int MaxHp;
    public int moneyToGive;
    public Image healthBarFill;

    private float velx;
    private float vely;
    private float speed = 0.02f;
    private bool up;
    private bool right;
    private bool left;

    void Awake()
    {
        if (up == true)
        {
            vely = -speed;
        }   
        else
        {
            vely = speed;
        }

        if (right == true)
        {
            velx = speed;
        }
        else
        {
            velx = -speed;
        }
    }

    public void FixedUpdate()
    {
        if (transform.position.x <= -5 || transform.position.x >= 5)
        {
            velx = -velx;
        }
    }

    public void Damage()
    {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)MaxHp;

        if (curHp <= 0)
        {
            Caught();
        }
    }

    public void NotDamage()
    {
        curHp++;
        healthBarFill.fillAmount = (float)curHp / (float)MaxHp;

        if (curHp <= 0)
        {
            Caught();
        }
    }

    public void Caught()
    {
        GameManager.instance.AddMoney(moneyToGive);
        AnimalManager.instance.ReplaceAnimal(gameObject);
    }

    public void OnMouseOver()
    {
        transform.Translate(velx, 0, 0);
        Damage();
    }

    public void OnMouseExit()
    {
        NotDamage();
    }
}
