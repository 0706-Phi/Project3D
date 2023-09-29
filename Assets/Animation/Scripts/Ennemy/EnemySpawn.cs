using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    void Start()
    {
        InvokeRepeating("Spawnnow", 5, 5);
    }

   Vector3 RandomPos()
    {
        float x = Random.Range(250, 400);
        float y = 0.62f; 
        float z = Random.Range(300, 400); 

        Vector3 newPos = new Vector3(x, y, z);
        return newPos;
    }
    void Spawnnow()
    {
        Instantiate(enemyToSpawn[0],RandomPos(),Quaternion.identity);
    }
}
