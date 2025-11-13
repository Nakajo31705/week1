using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]Player player;
    [SerializeField]Enemy enemy;

    public string turn;                //ターン
    public bool judgeingEnd;           //ジャッジの終了を判定
    private bool Win;                   //勝利の判定

    private void Start()
    {
        turn = "Player";
        judgeingEnd = true;
    }

    private void Update()
    {
        PlayJudge();
    }

    /// <summary>
    /// 試合の勝敗処理
    /// </summary>
    private void PlayJudge()
    {
        if (judgeingEnd) return;

        int playerWeapon = player.GetWeaponIndex();
        int enemyWeapon = enemy.GetWeaponIndex();

        if (playerWeapon == -1 || enemyWeapon == -1)
            return;

        int result = (enemyWeapon - playerWeapon + 3) % 3;

        switch (result)
        {
            case 0:
                Debug.Log("相殺");
                break;
            case 1:
                Debug.Log("勝ち");
                break;
            case 2:
                Debug.Log("負け");
                break;
        }
        judgeingEnd = true;
    }
}
