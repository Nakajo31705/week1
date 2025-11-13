using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LogManager logManager;
    [SerializeField] GameManager gameManager;

    [SerializeField] public GameObject[] weapons;       //武器の配列
    private GameObject getWeapon;                       //選んだ武器を取得  
    public int weaponIndex;                             //武器の番号
    private bool selected;                              //武器が選ばれたかどうか
    private bool showLog;                               //ログが表示されたかどうか

    private void Awake()
    {
        selected = false;
        showLog = false;
    }

    private void Update()
    {
        PlayerSelect();
    }

    /// <summary>
    /// 選択した武器が切り替わるようにする関数
    /// </summary>
    /// <param name="index"></param>
    private void SetWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }

    /// <summary>
    /// プレイヤーが武器を選択するときの処理
    /// </summary>
    void PlayerSelect()
    {
        if (gameManager.turn == "Player" && !gameManager.playerTurnEnd)
        {
            if (!showLog)
            {
                
                StartCoroutine(Log());
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0, "弓");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWeapon(1, "槍");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectWeapon(2, "剣");
            }
        }
        else
        {
            showLog = false;
        }
    }

    /// <summary>
    /// 武器の選択後の処理
    /// </summary>
    /// <param name="index"></param>
    /// <param name="weaponName"></param>
    public void  SelectWeapon(int index, string weaponName)
    {
       selected = true;
        SetWeapon(index);
        getWeapon = weapons[index];
        logManager.AddLog(weaponName + "を選んだ");
        StartCoroutine(TurnEnd());
    }


    /// <summary>
    /// 選択した武器の番号を取得
    /// </summary>
    /// <returns></returns>
    public int GetWeaponIndex()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].activeSelf)
            {
                return i;  // 現在選ばれている武器番号を返す
            }
        }
        return -1; // どの武器も選ばれていないときは-1を返す
    }

    /// <summary>
    /// 2秒後にエネミーのターンに変更
    /// </summary>
    IEnumerator TurnEnd()
    {
        yield return new WaitForSeconds(2f);
        gameManager.playerTurnEnd = true;
        gameManager.enemyTurnEnd = false;
        selected = false;
        gameManager.turn = "Enemy";
        logManager.AddLog("相手のターン!");
    }

    IEnumerator Log()
    {
        yield return new WaitForSeconds(1.0f);
        logManager.AddLog("数字を押して武器を選んでください。(1:弓、2:槍、3:剣)");
        showLog = true;
    }
}
