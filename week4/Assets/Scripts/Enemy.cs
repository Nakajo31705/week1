using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] public GameObject[] enemyWeapons;       //武器の配列
    private GameObject getWeapon;       //選んだ武器を取得  

    private void Start()
    {
    }

    private void Update()
    {
        EnemySelect();
    }

    /// <summary>
    /// 選択した武器が切り替わるようにする関数
    /// </summary>
    /// <param name="index"></param>
    private void SetWeapon(int index)
    {
        for (int i = 0; i < enemyWeapons.Length; i++)
        {
            enemyWeapons[i].SetActive(i == index);
        }
    }

    private void EnemySelect()
    {
        if (gameManager.turn == "Enemy")
        {
            Debug.Log("エネミーのターン");
            int randomIndex = Random.Range(0, enemyWeapons.Length);
            SetWeapon(randomIndex);
            getWeapon = enemyWeapons[randomIndex];
            Debug.Log(getWeapon.name);
            gameManager.turn = "Player";
            gameManager.judgeingEnd = false;
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
        for (int i = 0; i < enemyWeapons.Length; i++)
        {
            if (enemyWeapons[i].activeSelf)
            {
                return i;
            }
        }

        //見つからなかった場合は-1
        return -1;
    }
}
