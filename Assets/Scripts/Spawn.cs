using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public static Spawn instance;
    int randomNumber;
    
    public GameObject[] prefab_Enemies;


    [SerializeField]
    Transform[] spawnPoints;


    struct SpawnRate
	{
        public int spawnRate_EnemyLV1;
        public int spawnRate_EnemyLV2;

        public SpawnRate(int currentLevel)
		{
            if(currentLevel == 1)
            {
                spawnRate_EnemyLV1 = 3;
                spawnRate_EnemyLV2 = 6;
            }
            else
            {
                spawnRate_EnemyLV1 = 0;
                spawnRate_EnemyLV2 = 0;
            }
        }
    }
    SpawnRate spawnRate = new SpawnRate(1);

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        StartCoroutine(GetRandomNum(.75f));
    }

	private void FixedUpdate()
	{     

		if(randomNumber > spawnRate.spawnRate_EnemyLV1)
		{
            if (randomNumber > spawnRate.spawnRate_EnemyLV2)
            {
                Transform spawnPoint = FindAvailableSpawnPoint();
                if (spawnPoint != null)
                {
                    SpawnEnemies(1, spawnPoint.position, Quaternion.identity);
                }
                randomNumber = 0;
            }
            else{
                Transform spawnPoint = FindAvailableSpawnPoint();
                if (spawnPoint != null)
                {
                    SpawnEnemies(0, spawnPoint.position, Quaternion.identity);
                }
                randomNumber = 0;
            }    
        }     
        
    }

    IEnumerator GetRandomNum(float delay)
    {
        // yield return new WaitForSeconds(delay);
        // randomNumber = Random.Range(1, 11);
        while (true)
        {
            // Generate a random number between 1 and 10 (inclusive)
            randomNumber = Random.Range(1, 11);

            // Wait for one second before generating the next random number
            yield return new WaitForSeconds(delay);
        }
    }


    private Transform FindAvailableSpawnPoint()
    {
        List<Transform> availableSpawnPoints = new List<Transform>();
        foreach(Transform sP in spawnPoints)
		{
            availableSpawnPoints.Add(sP);    
        }
        if(availableSpawnPoints.Count == 0)
		{
            return null;
		}
        return availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
    }


    public void SpawnEnemies(int id, Vector3 pos, Quaternion rot)
    {
        GameObject enemy = Instantiate(prefab_Enemies[id], pos, Quaternion.identity);

    }

}
