using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject item;       //生成するアイテム
    [SerializeField] private GameObject DItem;      //生成するダメージアイテム
    [SerializeField] private float instanceTime;    //アイテムの生成間隔
    [SerializeField] private float DItemTime;       //ダメージアイテムの生成間隔    
    private Vector3 rangeA;                         //生成範囲A
    private Vector3 rangeB;                         //生成範囲B
    private float currentTime = 0f;                 //アイテム生成の経過時間
    private float DcurrentTime = 0f;                //ダメージアイテム生成の経過時間

    private void Start()
    {
        rangeA = new Vector3(-24.5f, 20.0f, -14.5f);
        rangeB = new Vector3(24.5f, 20.0f, 14.5f);
    }

    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        DcurrentTime = DcurrentTime + Time.deltaTime;

        if (currentTime > instanceTime)
        {
            float x = Random.Range(rangeA.x, rangeB.x);
            float y = Random.Range(rangeA.y, rangeB.y);
            float z = Random.Range(rangeA.z, rangeB.z);

            Instantiate(item, new Vector3(x, y, z), item.transform.rotation);

            currentTime = 0f;
        }

        if (DcurrentTime > DItemTime)
        {
            float x = Random.Range(rangeA.x, rangeB.x);
            float y = Random.Range(rangeA.y, rangeB.y);
            float z = Random.Range(rangeA.z, rangeB.z);

            Instantiate(DItem, new Vector3(x, y, z), DItem.transform.rotation);

            DcurrentTime = 0f;
        }
    }
}
