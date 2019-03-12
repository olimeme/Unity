using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves;
    private float countdownTimer;
    private int waveNumber = 1;

    [SerializeField]
    private Text countDownText;

    private void Start(){
        // countdownTimer = timeBetweenWaves;
    }


    private void Update(){
        if(countdownTimer <= 0){
           StartCoroutine(SpawnWave());
           countdownTimer = timeBetweenWaves;
        }
        countdownTimer -= Time.deltaTime;
        countDownText.text = countdownTimer.ToString("0");
    }

    private IEnumerator SpawnWave(){
        waveNumber++;
        for (int i = 0; i < waveNumber; i++){
           SpawnEnemy(); 
           yield return new WaitForSeconds(1.5f);
        }
    }

    private void SpawnEnemy(){
        // создаем объект в определенной точке на карте
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
