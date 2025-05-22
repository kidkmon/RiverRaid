using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Combinação de obstáculos")]
	public List<GameObject> enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
		GameObject selectedPrefab = enemyPrefabs[randomIndex];
        selectedPrefab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
