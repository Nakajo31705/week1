using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LogManager logManager;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    public string turn;             //ターン
    public bool judgeingEnd;        //ジャッジの終了を判定
    private bool Win;               //勝敗の判定
    private bool Draw;              //引き分け判定

    public bool playerTurnEnd;      //プレイヤーターンの終了判定
    public bool enemyTurnEnd;       //エネミーターンの終了判定

    private void Awake()
    {
        playerTurnEnd = false;
        enemyTurnEnd = false;
        turn = "Player";
        judgeingEnd = false;
    }

    private void Update()
    {
        PlayJudge();
        WinCheck();
    }

    /// <summary>
    /// 試合の勝敗処理
    /// </summary>
    private void  PlayJudge()
    {
        //プレイヤーとエネミーの選んだ武器の番号を取得
        int playerWeapon = player.GetWeaponIndex();
        int enemyWeapon = enemy.GetWeaponIndex();

        //両者のターンが終了しているなら勝敗判定を行う
        if (playerTurnEnd && enemyTurnEnd)
        {
            //勝敗判定の計算
            int result = (playerWeapon - enemyWeapon + 3) % 3;

            //勝敗判定の表示
            switch (result)
            {
                case 0:
                    logManager.AddLog("相殺");
                    Draw = true;
                    break;
                case 1:
                    logManager.AddLog("勝ち");
                    Win = true;
                    break;
                case 2:
                    logManager.AddLog("負け");
                    Win = false;
                    break;
            }
            StartCoroutine(WinCheck());
        }
    }

    /// <summary>
    /// 勝敗判定
    /// </summary>
    IEnumerator WinCheck()
    {
        yield return new WaitForSeconds(2f);

        if (playerTurnEnd && enemyTurnEnd && !judgeingEnd)
        {
            if (Draw)
            {
                StartCoroutine(Reset());
            }
            else if (Win)
            {
                logManager.AddLog("プレイヤーの勝ち!");
                StartCoroutine(Reset());
            }
            else
            {
                logManager.AddLog("エネミーの勝ち!");
                StartCoroutine(Reset());
            }
            judgeingEnd = true;
        }
    }

    /// <summary>
    /// 3秒後にゲームをリセットする
    /// </summary>
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3f);
        playerTurnEnd = false;
        turn = "Player";
        Draw = false;
        judgeingEnd = false;
    }
}
