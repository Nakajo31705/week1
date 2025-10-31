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


    [SerializeField] private float moveSpeed;               //��������
    [SerializeField] private float top;                     //�������̏���l
    [SerializeField] private float bottom;                  //�������̉����l
    [SerializeField] private float nowPos;                  //���݂̏ꏊ
    [SerializeField] private float nowPosY;                 //���݂�y���W
    [SerializeField] private direction nowDirection;        //���݂̌���




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
    /// �n���}�[�̈ړ�����
    /// </summary>
    private void HammerMove()
    {
        //����Ɖ����Ō�����ύX
        if (nowPos >= top)
        {
            nowDirection = direction.down;
        }
        else if (nowPos <= bottom)
        {
            nowDirection = direction.up;
        }


        //�ړ�����
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
