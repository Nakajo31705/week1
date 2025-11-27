using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Transform player;  //プレイヤーを回転させる用
    [SerializeField] private float mouseSpeed;  //マウス感度
    private float xRotatiton = 0f;              //X軸の回転用

    private void Update()
    {
        //マウスの操作を取得
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        //縦回転
        xRotatiton -= mouseY;
        xRotatiton = Mathf.Clamp(xRotatiton, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotatiton, 0f, 0f);

        //横回転
        player.Rotate(Vector3.up *  mouseX);
    }
}
