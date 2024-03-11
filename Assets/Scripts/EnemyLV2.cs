using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLV2 : EnemyBase
{
    public float speed = 5f;

    Quaternion initialRotation;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nav.speed = speed;
        gameManager = GameObject.FindWithTag("GM");
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        nav.updateRotation = false;
        transform.rotation = initialRotation;
    }
    protected override void TimerContent()
    {
        //Recover health
        // hp = Mathf.Min(hp + Time.deltaTime, hpTotal);
        nav.SetDestination(target.position);
        nav.updateRotation = false;
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
