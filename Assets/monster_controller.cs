
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Rigidbody2D RB;
    public PlayerScript Player;

    void Update()
{
        Vector2 vel = new Vector2(0, 0);

        
        if (transform.position.x < Player.transform.position.x)
        { 
            vel.x = 5;
        }

        RB.linearVelocity = vel;
}
}
