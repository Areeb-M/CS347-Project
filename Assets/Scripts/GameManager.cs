using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public PlayerController pc;

    public Text score_labal;
    public Text oxygen_label;

    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        // Store a reference to be able to change values upon static function calls
        game_manager = this;

        // Create player
        player = Instantiate(PlayerPrefab);

        // Reset Game
        ResetGame();

        // Load Level 0
        LoadLevel();

        // Load Sounds
        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.transform.position.z);

        if (!player.GetComponent<PlayerController>().isDead)
        {
            oxygen_timer -= Time.deltaTime;

            if (oxygen_timer < 0)
                KillPlayer();
        }

        if (Input.GetKeyDown(KeyCode.N) && Input.GetKey(KeyCode.LeftShift))
            AdvanceLevel();

        score_labal.text = "Score: " + points;
        oxygen_label.text = "Oxygen: " + (int)oxygen_timer;
    }

    private void ResetPlayer()
    {
        player.transform.position = new Vector3(0, 1, 0);
        player.GetComponent<Rigidbody>().velocity = new Vector3();
        player.GetComponent<PlayerController>().PlayerReset();
        oxygen_timer = OxygenTimeLimits[level_id];
    }

    private void ResetGame()
    {
        level_id = 0;
        points = 0;
    }

    private void LoadLevel()
    {
        Destroy(level);

        level = Instantiate(LevelPrefabs[level_id]);
        oxygen_timer = OxygenTimeLimits[level_id];
        ResetPlayer();
    }

    private void Win()
    {
        SceneManager.LoadScene("Win Scene");
    }

    public static void AddPoints(int points)
    {
        game_manager.sounds[0].Play();
        game_manager.points += points;
        Debug.Log(game_manager.points);
    }

    public static void AdvanceLevel()
    {
        AddPoints((int)game_manager.oxygen_timer * 25);

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
        game_manager.player.GetComponent<PlayerController>().Death();
        game_manager.Invoke("ResetPlayer", 4f);
    }

    public static int GetPoints()
    {
        return game_manager.points;
    }    
}
