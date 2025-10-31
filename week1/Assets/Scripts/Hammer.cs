using UnityEngine;

 enum direction
{
    defaultDirection,
    up,
    down,
};


public class Hammer : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Control control;


    [SerializeField] private float moveSpeed;               //動く速さ
    [SerializeField] private float top;                     //動く幅の上限値
    [SerializeField] private float bottom;                  //動く幅の下限値
    [SerializeField] private float nowPos;                  //現在の場所
    [SerializeField] private float nowPosY;                 //現在のy座標
    [SerializeField] private direction nowDirection;        //現在の向き




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        nowDirection = direction.defaultDirection;
    }

    private void Update()
    {
        nowPos = transform.position.y;

        HammerMove();
    }


    /// <summary>
    /// ハンマーの移動処理
    /// </summary>
    private void HammerMove()
    {
        //上限と下限で向きを変更
        if (nowPos >= top)
        {
            nowDirection = direction.down;
        }
        else if (nowPos <= bottom)
        {
            nowDirection = direction.up;
        }


        //移動処理
        if (nowDirection == direction.down)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, nowPosY * -moveSpeed * Time.deltaTime);
        }
        if (nowDirection == direction.up)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, nowPosY * moveSpeed * Time.deltaTime);
        }
        if (nowDirection == direction.defaultDirection)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, nowPosY * -moveSpeed * Time.deltaTime);
        }
    }
}
