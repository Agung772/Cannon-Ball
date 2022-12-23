using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject[] wallGroupPrefab;
    public Transform wallGroupSpawnPosition;

    public int fallenBrickAmount, fallenBrickNeeded;

    public event Action setAmmo;

    public TextMeshProUGUI levelText;
    public static int level = 1;

    private void Start()
    {
        SpawnWallGroup(Random.Range(0, wallGroupPrefab.Length));

        levelText.text = "Level : " + level;  
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestratGame();
        }
    }

    

    void SpawnWallGroup(int wallGroupIndex)
    {
        Instantiate(wallGroupPrefab[wallGroupIndex], wallGroupSpawnPosition.position, Quaternion.identity);
    } 


    public void BrickFall()
    {
        fallenBrickAmount++;
        
        if(fallenBrickAmount >= fallenBrickNeeded)
        {
            level++;
            RestratGame();
            print("YOU WIN");
        }
    }

    public void RestratGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetAmmo()
    {
        setAmmo?.Invoke();
    }


}
