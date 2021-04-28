using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager game_manager;

    private int level_id = 0;
    private GameObject level;
    private GameObject player;

    private int points = 0;
    private float oxygen_timer = 0;

    public GameObject[] LevelPrefabs;
    public float[] OxygenTimeLimits;
    public GameObject PlayerPrefab;
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        // Store a reference to be able to change values upon static function calls
        game_manager = this;

        // Create player
        player = Instantiate(PlayerPrefab);

        // Load Level 0
        LoadLevel();

    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.transform.position.z);
        oxygen_timer -= Time.deltaTime;
    }

    private void ResetPlayer()
    {
        player.transform.position = new Vector3();
        player.GetComponent<Rigidbody>().velocity = new Vector3();
    }

    private void LoadLevel()
    {
        level = Instantiate(LevelPrefabs[level_id]);
        oxygen_timer = OxygenTimeLimits[level_id];
        ResetPlayer();
    }

    private void Win()
    {
        // Transition to winning scene
    }

    public static void AddPoints(int points)
    {
        game_manager.points += points;
        Debug.Log(game_manager.points);
    }

    public static void AdvanceLevel()
    {
        if (game_manager.level_id < game_manager.LevelPrefabs.Length - 1)
        {
            game_manager.level_id += 1;
            game_manager.LoadLevel();
        }
        else
            game_manager.Win();
    }

    public static void KillPlayer()
    {
        game_manager.ResetPlayer();
    }
}
