using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour
{

    [SerializeField] GameObject[] obstaclePrefab;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float minTrans;
    [SerializeField] float maxTrans;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }


    IEnumerator ObstacleSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTrans, maxTrans);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
            Destroy(gameObject, 5f);
        }
      
    }


}
