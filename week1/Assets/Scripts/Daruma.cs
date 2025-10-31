using UnityEngine;
using UnityEngine.SceneManagement;

public class Daruma : MonoBehaviour
{
    [SerializeField]private Control control;

    Rigidbody2D rb;
    [SerializeField] private float shootPower = 300;
    public bool hitFlag = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// ÇæÇÈÇ‹ÇêÅÇ´îÚÇŒÇ∑èàóù
    /// </summary>
    public void DARUMAShoot ()
    {
        if (hitFlag) return;

        hitFlag = true;

        if (control.direction == Vector2.left)
        {
            rb.AddForce(Vector2.left * shootPower);
        }
        if (control.direction == Vector2.right)
        {
            rb.AddForce(Vector2.right * shootPower);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Over"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
