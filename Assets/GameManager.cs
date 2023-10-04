using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PoroType
{
    public int count;
    public List<GameObject> poro;
    public PoroType()
    {
        count = 0;
        poro = new List<GameObject>();
    }

}
[Serializable]
public class PoroPrefab
{
    public Abilities ability;
    public GameObject prefab;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public GameObject playerMesh;
    public Abilities currentAbility = Abilities.nothing;
    public List<PoroPrefab> prefabs = new List<PoroPrefab>();
    
    public Dictionary<Abilities,GameObject> poroPrefabs = new Dictionary<Abilities,GameObject>();
    public Dictionary<Abilities, PoroType> poroObtained = new Dictionary<Abilities, PoroType> {
        {Abilities.invisible , new PoroType() },
        {Abilities.grappel , new PoroType() },
        {Abilities.fireBall , new PoroType() },
        {Abilities.dash , new PoroType() }
    };
    public int initialWhitePoro;
    public int initialPinkPoro;
    public int initialRedPoro;
    public int initialBluePoro;

    public TextMeshProUGUI blue;
    public TextMeshProUGUI white;
    public TextMeshProUGUI pink;
    public TextMeshProUGUI red;
    public GameObject gameOverUi;
    public GameObject HUD;

    public bool invisible;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < initialWhitePoro; i++) 
        {
            SpawnPoro(Abilities.invisible, player.transform.position);
        }
        for (int i = 0; i < initialPinkPoro; i++) 
        {
            SpawnPoro(Abilities.grappel, player.transform.position);
        }
        for (int i = 0; i < initialRedPoro; i++) 
        {
            SpawnPoro(Abilities.fireBall, player.transform.position);
        }
        for (int i = 0; i < initialBluePoro; i++) 
        {
            SpawnPoro(Abilities.dash, player.transform.position);
        }

    }
    private void Update()
    {
        blue.text = "X" + poroObtained[Abilities.dash].count.ToString();
        white.text = "X" + poroObtained[Abilities.invisible].count.ToString();
        pink.text = "X" + poroObtained[Abilities.grappel].count.ToString();
        red.text = "X" + poroObtained[Abilities.fireBall].count.ToString();
    }
    public void SpawnPoro(Abilities ability , Vector3 position)
    {
        poroObtained[ability].count++;
        poroObtained[ability].poro.Add( Instantiate(prefabs.Single(obj => obj.ability == ability).prefab, position, Quaternion.identity));
    }
    public void GameOver()
    {
        gameOverUi.SetActive(true);
        HUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
