using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveSettings {
    public float enemySpeedMultiplier = 1.0f;

    public int increaseOfEnemies = 1;

    public float enemyScoreMultiplier = 1.0f;
	public float enemyDamageMultiplier = 1.0f;

	public float waveDelay = 1.0f;

    public EnemySpawner[] enemySpawners;
}

public class WaveController : MonoBehaviour {
    [SerializeField]
    Text waveText = null;
    [SerializeField]
    WaveSettings[] waveSettings = null;

    int waveNumber = 0;

	SimpleTimer waveTimer = new SimpleTimer();

	public static int numberOfEnemiesLeft = -1;

	private void Start() {
		waveTimer.SetTimer(waveSettings[waveNumber].waveDelay);
		waveTimer.StartTimer();
	}

	private void Update() {
		if (waveNumber  < waveSettings.Length) {
			if (numberOfEnemiesLeft < 0) {
				waveTimer.Update();
				waveText.text = "Wave: " + waveNumber.ToString("F0") +
					"\nNext Wave in: " + waveTimer.TimeRemaining().ToString("F1");
				
				if (waveTimer.IsFinished()) {
					SpawnWave();
				}
			}
			else {
				waveText.text = "Wave: " + waveNumber.ToString("F0") +
					"\nEnemies Left: " + (1 + numberOfEnemiesLeft).ToString();
			}
		}
		else {
			waveText.text = "Wave: " + waveNumber.ToString("F0") +
				"\nFinished";
		}
	}

    private void SpawnWave() {        
        numberOfEnemiesLeft = 0;
        foreach (EnemySpawner spawner in waveSettings[waveNumber].enemySpawners) {
            numberOfEnemiesLeft += spawner.StartNewWave(waveSettings[waveNumber]);			
        }		
		waveNumber++;
		if (waveNumber < waveSettings.Length) {
			waveTimer.SetTimer(waveSettings[waveNumber].waveDelay);
			waveTimer.StartTimer();
		}
		waveText.text = "Wave: " + waveNumber.ToString("F0") +
					"\nEnemies Left: " + (1+numberOfEnemiesLeft).ToString();
	}
}
