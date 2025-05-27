using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("nuevo punto de guardado");
            animator.SetTrigger("Activate");
            CheckPointSystem.instance.ActualizarUltimaPos(transform.position);
        }
    }
}
