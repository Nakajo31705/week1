using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    [SerializeField] public GameObject[] weapons;        //武器の配列
    private GameObject getWeapon;                       //選んだ武器を取得  
    public int weaponIndex;                             //武器の番号

    private void Start()
    {
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
        if (gameManager.turn == "Player" && gameManager.judgeingEnd)
        {
            Debug.Log("プレイヤーのターン");
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("弓");
                SetWeapon(0);
                getWeapon = weapons[0];
                gameManager.turn = "Enemy";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("槍");
                SetWeapon(1);
                getWeapon = weapons[1];
                gameManager.turn = "Enemy";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("剣");
                SetWeapon(2);
                getWeapon = weapons[2];
                gameManager.turn = "Enemy";
            }
        }
    }


    /// <summary>
    /// 選ばれた武器の番号を取得
    /// </summary>
    /// <returns>
    /// 武器の番号(0:弓、1:槍、2:剣)
    ///どの武器でもない場合は-1を返す
    /// </returns>
    public int GetWeaponIndex()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].activeSelf)
            {
                return i;

            }
        }
        //見つからなかった場合は-1
        return -1;
    }
}
