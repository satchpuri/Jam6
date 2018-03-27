using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
	public class Wave
    {
        public string name;
        public Transform sushiPlatter;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 3f;
    public float waveCountdown;

    private SpawnState state = SpawnState.COUNTING;

    SushiPooler sushiPooler;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        sushiPooler = SushiPooler.Instance;
    }

    void FixedUpdate()
    {
        sushiPooler.SpawnFromPool("Sushi", transform.position); 
    }

    private void Update()
    {
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start Spawning Wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _sushi)
    {

        state = SpawnState.SPAWNING;

        for(int i = 0; i<_sushi.count; i++)
        {
            SpawnSushi(_sushi.sushiPlatter);
            yield return new WaitForSeconds(1f / _sushi.rate) ;
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnSushi(Transform _sushiPlatter)
    {
        Debug.Log("Spawning Sushi:" + _sushiPlatter.name);
    }
}
