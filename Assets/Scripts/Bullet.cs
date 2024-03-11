using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    float damage = 20;
    [SerializeField]
    // ParticleSystem particle;
    MeshRenderer bulletMesh;

    float timer = 0;
    float timerTotal = 10;
    bool isBulletTriggered = false;

    public GameObject gameManager;

	private void Start()
	{
        bulletMesh = GetComponent<MeshRenderer>();
        gameManager = GameObject.FindWithTag("GM");
    }

	// Update is called once per frame
	void Update()
    {
        if (!isBulletTriggered)
        {
            if (timer > timerTotal)
            {
                BulletTriggered();
            }
            else
            {
                transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime, Space.Self);
                timer += Time.deltaTime;
            }
        }
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
        Destroy(gameObject);
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
        else if(other.CompareTag("Player")){
            // DestroySelf();
        }
        
	}
}
