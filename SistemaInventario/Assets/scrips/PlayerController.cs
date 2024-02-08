using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 10;
    Rigidbody2D player_rb;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            player_rb.velocity = new Vector2(velocidad, player_rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player_rb.velocity = new Vector2(-velocidad, player_rb.velocity.y);
        }
       
}


}
