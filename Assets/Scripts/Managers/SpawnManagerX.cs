using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    static public SpawnManagerX instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("Spawn Info")]
    public GameObject m_SpawnObject;
    public int m_EnemySpawnAmount = 1;
    public Transform[] m_SpawnLocations;

    //private
    private IEnumerator spawnCoroutine;
    private bool spawning = false;

    void Start()
    {
        spawnCoroutine = SpawnCoroutine();
        StartCoroutine(spawnCoroutine);
    }

    private IEnumerator SpawnCoroutine()
    {
        spawning = true;

        while (spawning)
        {
            //set the m_EnemySpawnAmount appropriate to the score.
            if (UIManagerX.instance.GetScore() >= 5 && UIManagerX.instance.GetScore() < 18)
                m_EnemySpawnAmount = 3;
            else if (UIManagerX.instance.GetScore() >= 18 && UIManagerX.instance.GetScore() < 42)
                m_EnemySpawnAmount = 5;
            else if (UIManagerX.instance.GetScore() >= 42)
                m_EnemySpawnAmount = 8;

            //spawn enemies, and wait 3 seconds
            SpawnEnemy(m_EnemySpawnAmount);
            yield return new WaitForSeconds(3);
        }
    }

    /// <summary>
    /// Spawn enemyies on random locations at the provided amount. 
    /// </summary>
    /// <param name="_spawnAmount">The default amount of spawned enemyies</param>
    private void SpawnEnemy(int _spawnAmount = 1)
    {
        //make a list with all the spawn locations.
        List<Transform> spawnLocations = new List<Transform>();
        foreach (var location in m_SpawnLocations)
        {
            spawnLocations.Add(location);
        }

        //spawn eniemies _spawnAmount of times.
        for (int i = 0; i < _spawnAmount; i++)
        {
            //spawn enemies on random spawnlocations, and makes sure to not spawn two on the same space.
            int randomIndex = Random.Range(0, spawnLocations.Count);
            GameObject enemy = Instantiate(m_SpawnObject, spawnLocations[randomIndex]);
            spawnLocations.RemoveAt(randomIndex);

            //set the enemy as child of the manager object in the scene, and give it a random Z rotation.
            enemy.transform.parent = gameObject.transform;
            enemy.transform.rotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Random.Range(0.0f, 360.0f));
        }
    }
}
