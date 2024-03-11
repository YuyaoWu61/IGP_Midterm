using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLV1 : EnemyBase
{
    public float speed = 3.5f;
    Quaternion initialRotation;
    protected override void Start()
    {
        base.Start();
        nav.speed = speed;
        gameManager = GameObject.FindWithTag("GM");

        initialRotation = transform.rotation;
    }
    protected override void TimerContent()
    {
        //Recover health
        nav.SetDestination(target.position);
        nav.updateRotation = false;
        transform.rotation = initialRotation;
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
