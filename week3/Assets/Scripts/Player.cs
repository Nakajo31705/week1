using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed;   //プレイヤーの移動速度

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }

    /// <summary>
    /// プレイヤーの移動の処理
    /// </summary>
    private void PlayerMove()
    {
        Vector2 pos = transform.position;

        if(Input.GetKey(KeyCode.W))
        {
            pos += new Vector2(rb.linearVelocity.x, moveSpeed) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            pos += new Vector2(rb.linearVelocity.x, -moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos += new Vector2(moveSpeed, rb.linearVelocity.y) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos += new Vector2(-moveSpeed, rb.linearVelocity.y) * Time.deltaTime;
        }

        transform.position = pos;
    }
}
