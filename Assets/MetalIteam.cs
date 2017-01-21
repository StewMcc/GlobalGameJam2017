using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalIteam : MonoBehaviour {


    [Tooltip("The amount of metal level the iteam is ")]
    [SerializeField]
    protected int metalAmmount = 10;


    [Tooltip("The chance of spawn.")]
    [Range(0,100)]
    [SerializeField]
    protected int rarityOfSpawn = 10;


    public int MetalAmmount()
    {
        return metalAmmount;
    }
    public int RarityOfSpawn()
    {
        return rarityOfSpawn;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
