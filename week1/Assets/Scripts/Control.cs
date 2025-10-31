using UnityEngine;

public class Control : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform hammer;
    public Transform daruma;

    private Vector2 darumaPos;
    private Vector2 origin;
    public Vector2 direction = Vector2.left;
    private float distance = 10f;


    private void Start()
    {
        darumaPos = daruma.position;
    }
    private void Update()
    {
        origin = hammer.position;
        Shoot();
        HammerPosChange();
    }

    /// <summary>
    /// だるまを吹き飛ばす処理
    /// </summary>
    private void Shoot()
    {
        //ハンマーの向きに合わせてヒット判定の向きも調整
        if (hammer.position.x > darumaPos.x)
        {
            direction = Vector2.left;
        }
        if (hammer.position.x < darumaPos.x)
        {
            direction = Vector2.right;
        }

        /*Spaceを押してレイを飛ばし、だるまがいるならそのだるまを吹き飛ばす*/

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance);
            if (hit.collider != null)
            {
                Daruma daruma = hit.collider.GetComponent<Daruma>();
                if (daruma != null && !daruma.hitFlag)
                {
                    daruma.DARUMAShoot();
                }
            }
        }
    }

    /// <summary>
    /// ハンマーの位置を切り替える
    /// </summary>
    private void HammerPosChange()
    {
        //ハンマーの位置を切り替え
        if (Input.GetMouseButtonDown(1))    
        {
            Vector2 ChangePos = new Vector2(-origin.x, origin.y);
            transform.position = ChangePos;
        }
    }
}
