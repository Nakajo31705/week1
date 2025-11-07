using UnityEngine;
using UnityEngine.Tilemaps;

public class Key : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap1;       //変更したいタイル
    [SerializeField] private TileBase newTile1;      //差し替えたいタイル

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //鍵を取ったときに指定座標のタイルを入れ替える
        if (gameObject.name == "Player" && collision.CompareTag("Key1"))
        {
            Vector3Int cellPosition1 = new Vector3Int(-22, -13, 0);
            Vector3Int cellPosition2 = new Vector3Int(-23, -13, 0);

            tileMap1.SetTile(cellPosition1, newTile1);
            tileMap1.SetTile(cellPosition2, newTile1);

            GameObject DelKey1 = GameObject.Find("Key1");
            Destroy(DelKey1);
        }

        if (gameObject.name == "Player" && collision.CompareTag("Key2"))
        {
            Vector3Int cellPosition1 = new Vector3Int(-38, 7, 0);
            Vector3Int cellPosition2 = new Vector3Int(-38, 6, 0);

            tileMap1.SetTile(cellPosition1, newTile1);
            tileMap1.SetTile(cellPosition2, newTile1);

            GameObject DelKey2 = GameObject.Find("Key2");
            Destroy(DelKey2);
        }

        if (gameObject.name == "Player" && collision.CompareTag("Key3"))
        {
            Vector3Int cellPosition1 = new Vector3Int(-23, 7, 0);
            Vector3Int cellPosition2 = new Vector3Int(-23, 6, 0);

            tileMap1.SetTile(cellPosition1, newTile1);
            tileMap1.SetTile(cellPosition2, newTile1);

            GameObject DelKey3 = GameObject.Find("Key3");
            Destroy(DelKey3);
        }
    }
}
