using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float cameraSpeed;

    private void Update()
    {
        MoveInput();
    }

    /// <summary>
    /// キーの入力
    /// </summary>
    private void MoveInput()
    {
        //縦と横方向の入力を取得
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        //移動ベクトルの作成
        Vector3 dir = new Vector3(hor, 0, ver);

        Move(dir, speed);
    }

    /// <summary>
    /// 移動の処理
    /// 向きと速度を引数で渡す
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="speed"></param>
    private void Move(Vector3 direction, float speed)
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
