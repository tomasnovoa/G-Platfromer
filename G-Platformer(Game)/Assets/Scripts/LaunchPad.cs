using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float fuerza = 10f;
    public Animator animator;
   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, 0f);
                rb2d.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
                animator.Play("Jumper");
                AudioManager.Instance.PlaySFX("Jumpad");
            }
        }
    }

  

    

   


}
