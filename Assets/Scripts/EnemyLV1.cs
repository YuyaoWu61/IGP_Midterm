using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLV1 : EnemyBase
{
    public float speed = 3.5f;
    protected override void Start()
    {
        base.Start();
        nav.speed = speed;
        gameManager = GameObject.FindWithTag("GM");
    }
    protected override void TimerContent()
    {
        //Recover health
        nav.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            gameManager.GetComponent<GameManager>().killTotal -= 2;
            Destroy(this.gameObject);
        }else if(other.CompareTag("Bullet")){
            gameManager.GetComponent<GameManager>().killTotal += 1;
        }
        
    }
}
