using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int PointPenalty;
    public bool KillPlayer;
    public bool RespawnObstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.AddPoints(-PointPenalty);
        if (KillPlayer)
            GameManager.KillPlayer();

        if (!RespawnObstacle)
            Destroy(this.gameObject, 0.1f);
    }
}
