using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private TextMeshProUGUI _countDownTimerText;
    private float _countDown = 2f;//time for spawning first wave
    private int waveIndex = 0;
    
    
    // Update is called once per frame
    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }

        _countDown -= Time.deltaTime;
        _countDownTimerText.text = Mathf.Round(_countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
