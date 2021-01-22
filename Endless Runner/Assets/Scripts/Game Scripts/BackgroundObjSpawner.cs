using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjSpawner : MonoBehaviour
{

    public GameObject[] backgroundObjects;
    public List<GameObject> backgroundObjectsToSpawn = new List<GameObject>();

    void Awake()
    {
        InitBackgoundObjects();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNextBackgroundObj());
    }

    void InitBackgoundObjects()
    {

        for (int i = 0; i < 4; i++)
        {
            addRandomBackgroundObjToSpawn();
        }
    }

    private void addRandomBackgroundObjToSpawn()
    {
        GameObject obj = Instantiate(backgroundObjects[Random.Range(0, backgroundObjects.Length)], transform.position, Quaternion.identity);
        float scale = Random.Range(2.5f, 4.5f);
        obj.transform.localScale = new Vector3(scale, scale);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + Random.Range(-0.5f, 1.5f));
        obj.SetActive(false);
        backgroundObjectsToSpawn.Add(obj);
    }

    public void removeSpawnedBackgroundObj(GameObject objToRemove)
    {
        backgroundObjectsToSpawn.Remove(objToRemove);
    }

    IEnumerator SpawnNextBackgroundObj()
    {
        //Warte gewisse Zeit befor etwas spawned
        yield return new WaitForSeconds(Random.Range(1f, 6f));

        int index = 0;

        while (true)
        {
            if (!backgroundObjectsToSpawn[index].activeInHierarchy)
            {
                backgroundObjectsToSpawn[index].SetActive(true);
                addRandomBackgroundObjToSpawn();
                break;
            }
            else
            {
                index++;
            }
        }
        StartCoroutine(SpawnNextBackgroundObj());
    }
 }
