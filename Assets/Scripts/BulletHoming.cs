using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : MonoBehaviour
{
    
    float speed = 17;
    // float damage = 20;
    [SerializeField]
    // ParticleSystem particle;
    MeshRenderer bulletMesh;

    float timer = 0;
    float timerTotal = 6;
    bool isBulletTriggered = false;

    public GameObject gameManager;

    public GameObject closestTarget;

	private void Start()
	{
        bulletMesh = GetComponent<MeshRenderer>();
        gameManager = GameObject.FindWithTag("GM");
    }

	// Update is called once per frame
	void Update()
    {
        FindClosestTarget();
        if (!isBulletTriggered)
        {
            if (timer > timerTotal)
            {
                BulletTriggered();
            }
            else
            {
                if (closestTarget != null)
                {
                    // Move towards the closest target
                    transform.position = Vector3.MoveTowards(transform.position, closestTarget.transform.position, speed * Time.deltaTime);
                }
                else{
                    transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime, Space.Self);
                }
                
                timer += Time.deltaTime;
            }
        }
    }

    void FindClosestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestTarget = target;
            }
        }

        closestTarget = nearestTarget;
    }


    void BulletTriggered()
    {
        isBulletTriggered = true;
        // bulletMesh.enabled = false;
        Invoke("DestroySelf", 1);
    }

    void DestroySelf()
	{
        
        // GameManager.instance.RemoveBullet(this);
        Destroy(this.gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!isBulletTriggered && !other.CompareTag("Player") && !other.CompareTag("Bullet"))
        {
            if (other.CompareTag("Enemy"))
			{
                Destroy(other.gameObject);
                // gameManager.GetComponent<GameManager>().killTotal += 1;
                Debug.Log("killed 1");
                DestroySelf();
                // var enemy = other.GetComponent<EnemyBase>();
                // enemy.Damaged(damage);
                // particle.Play();
            }
            DestroySelf();
			
        }
        DestroySelf();
	}
}
