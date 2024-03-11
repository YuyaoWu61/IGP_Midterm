using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLV2 : EnemyBase
{
    public float speed = 5f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nav.speed = speed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void TimerContent()
    {
        //Recover health
        // hp = Mathf.Min(hp + Time.deltaTime, hpTotal);
        nav.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other) {
        gameManager.GetComponent<GameManager>().killTotal += 1;
    }
}