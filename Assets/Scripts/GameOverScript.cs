using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
 

    public int finalScore;
	public int finalWave;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
    }

    public void setFinalGameScores(int finalScore, int finalWave)
    {
        this.finalScore = finalScore;
        this.finalWave = finalWave;
    }


}
