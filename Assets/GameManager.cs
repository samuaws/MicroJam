using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public GameObject playerMesh;
    public Abilities currentAbility = Abilities.nothing;
    private void Awake()
    {
        Instance = this;
    }
}
