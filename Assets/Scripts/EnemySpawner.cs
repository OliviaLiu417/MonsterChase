using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedMonsters());
    }

    //call it over and over again
    IEnumerator SpawnedMonsters()
    {

        while (true)
        {
            //a coroutine needs to wait
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                //monsters from the left
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemies>().speed = Random.Range(4, 10);

            }
            else
            {
                //monsters from the right
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemies>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }//while loop
    }
}
