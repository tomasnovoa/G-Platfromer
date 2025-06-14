using UnityEngine;

public class PjAn : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.Play("Dance");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.Play("Nose");
        }
    }
}
