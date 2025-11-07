using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed;   //プレイヤーの移動速度
    private bool reverse = false;               //操作反転のフラグ

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (!reverse)
        {
            PlayerMove();
        }
        else
        {
            ReversePlayerMove();
        }
    }

    /// <summary>
    /// 通常時のプレイヤーの移動処理
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

    /// <summary>
    /// 反転時のプレイヤーの移動処理
    /// </summary>
    private void ReversePlayerMove()
    {
        Vector2 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos += new Vector2(rb.linearVelocity.x, -moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos += new Vector2(rb.linearVelocity.x, moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos += new Vector2(-moveSpeed, rb.linearVelocity.y) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos += new Vector2(moveSpeed, rb.linearVelocity.y) * Time.deltaTime;
        }
        transform.position = pos;
    }

    //トラップに当たったらゲームオーバー
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //コインを取ったら操作反転&コイン削除
        if (collision.gameObject.CompareTag("Coin1"))
        {
            reverse = true;
            GameObject coin1 = GameObject.Find("Coin1");
            Destroy(coin1);
        }
        if (collision.gameObject.CompareTag("Coin2"))
        {
            reverse = false;
            GameObject coin2 = GameObject.Find("Coin2");
            Destroy(coin2);
        }

        //宝箱にふれたらゴール
        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
