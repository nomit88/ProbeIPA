using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{

    public GameObject[] obstacles;
    public List<GameObject> obstaclesToSpawn = new List<GameObject>();

    float speedToSupstract;

    float minSpawnTime = 1.5f;
    float maxSpawnTime = 4.5f;

    void Awake() { 
        InitObstacles();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNextObstacle());
        StartCoroutine(IncreaseSpeed());
    }

    void InitObstacles() {

        for (int i = 0; i < 3; i++) {
            addRandomObstacleToSpawn();
        }
    }

    private void addRandomObstacleToSpawn() {
        GameObject obj =  Instantiate( obstacles[Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);
        obj.SetActive(false);
        if (obj.tag == "fly_deadly") { 
            obj.transform.position = new Vector3(obj.transform.position.x, -1 );
        }
        obj.GetComponent<ObstacleMovement>().speed -= speedToSupstract;

        obstaclesToSpawn.Add(obj);        
    }

    public void removeSpawnedObstacle(GameObject objToRemove) {
        
        obstaclesToSpawn.Remove(objToRemove);
    }

    IEnumerator SpawnNextObstacle() {
        //Warte gewisse Zeit befor etwas spawned
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

        int index = 0;

        while (true) {
            if (!obstaclesToSpawn[index].activeInHierarchy){
                obstaclesToSpawn[index].SetActive(true);
                addRandomObstacleToSpawn();
                break;
            }
            else {
                index ++;
            }
        }
        StartCoroutine(SpawnNextObstacle());
    }
    //Erhöht die geschwindigkeit der Objecten
    IEnumerator IncreaseSpeed() {
        speedToSupstract += 1f;
        if (minSpawnTime > 0.8) { 
         minSpawnTime -= 0.1f;
        }
        if (maxSpawnTime > 1.5f)
        {
            maxSpawnTime -= 0.2f;
        }

        yield return new WaitForSeconds(10f);

        StartCoroutine(IncreaseSpeed());
    }
}
