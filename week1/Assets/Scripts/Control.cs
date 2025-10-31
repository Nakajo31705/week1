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
    /// ����܂𐁂���΂�����
    /// </summary>
    private void Shoot()
    {
        //�n���}�[�̌����ɍ��킹�ăq�b�g����̌���������
        if (hammer.position.x > darumaPos.x)
        {
            direction = Vector2.left;
        }
        if (hammer.position.x < darumaPos.x)
        {
            direction = Vector2.right;
        }

        /*Space�������ă��C���΂��A����܂�����Ȃ炻�̂���܂𐁂���΂�*/

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
    /// �n���}�[�̈ʒu��؂�ւ���
    /// </summary>
    private void HammerPosChange()
    {
        //�n���}�[�̈ʒu��؂�ւ�
        if (Input.GetMouseButtonDown(1))    
        {
            Vector2 ChangePos = new Vector2(-origin.x, origin.y);
            transform.position = ChangePos;
        }
    }
}
