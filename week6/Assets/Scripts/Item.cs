using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject item;       //生成するアイテム
    [SerializeField] private GameObject DItem;      //生成するダメージアイテム    
    private Vector3 rangeA;                         //生成範囲A
    private Vector3 rangeB;                         //生成範囲B
    private GameObject currentItem;                 //現在のアイテムを格納
    private GameObject currentDItem;                //現在のダメージアイテムを格納

    //時間関係
    [SerializeField] private float instanceTime;    //アイテムの生成間隔
    [SerializeField] private float DItemTime;       //ダメージアイテムの生成間隔
    [SerializeField] private float DestroyTime;     //アイテムの削除時間
    private float currentTime = 0f;                 //アイテム生成の経過時間
    private float DcurrentTime = 0f;                //ダメージアイテム生成の経過時間

    private void Start()
    {
        //生成範囲を設定
        rangeA = new Vector3(-24.5f, 20.0f, -14.5f);
        rangeB = new Vector3(24.5f, 20.0f, 14.5f);
    }

    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        DcurrentTime = DcurrentTime + Time.deltaTime;
        InstantiateItem();
    }

    /// <summary>
    /// アイテムを生成する関数
    /// </summary>
    private void InstantiateItem()
    {
        //通常アイテム
        if (currentTime > instanceTime)
        {
            float x = Random.Range(rangeA.x, rangeB.x);
            float y = Random.Range(rangeA.y, rangeB.y);
            float z = Random.Range(rangeA.z, rangeB.z);

            currentItem = Instantiate(item, new Vector3(x, y, z), item.transform.rotation);
            Destroy(currentItem, DestroyTime);

            currentTime = 0f;
        }

        //ダメージアイテム
        if (DcurrentTime > DItemTime)
        {
            float x = Random.Range(rangeA.x, rangeB.x);
            float y = Random.Range(rangeA.y, rangeB.y);
            float z = Random.Range(rangeA.z, rangeB.z);

            currentDItem = Instantiate(DItem, new Vector3(x, y, z), DItem.transform.rotation);
            Destroy(currentDItem, DestroyTime);

            DcurrentTime = 0f;
        }
    }
}
