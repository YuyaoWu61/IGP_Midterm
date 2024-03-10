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
    float timerTotal = 3;
    bool isBulletTriggered = false;

	private void Start()
	{
        bulletMesh = GetComponent<MeshRenderer>();

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
        bulletMesh.enabled = false;
        Invoke("DestroySelf", 2);
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
            BulletTriggered();
			if (other.CompareTag("Enemy"))
			{
                Destroy(other.gameObject);
                // var enemy = other.GetComponent<EnemyBase>();
                // enemy.Damaged(damage);
                // particle.Play();
            }
        }
	}
}
