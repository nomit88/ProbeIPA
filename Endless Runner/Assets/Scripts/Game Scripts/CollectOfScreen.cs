using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOfScreen : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Ground"){
            if (other.tag == "backgroundObj")
            {
                GameObject.Find("BackgroundObjSpawner").GetComponent<BackgroundObjSpawner>().removeSpawnedBackgroundObj(other.gameObject);
            }
            else { 
                GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawnerScript>().removeSpawnedObstacle(other.gameObject);
            }
            if (other.tag != "backgroundObj")
            {
                Destroy(other.gameObject, 1);
            }
            else { 
                Destroy(other.gameObject, 3);
            }

        }
     }
}
