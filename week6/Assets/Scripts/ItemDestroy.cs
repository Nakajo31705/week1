using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    //ƒvƒŒƒCƒ„[‚ÉG‚ê‚½‚çíœ
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
