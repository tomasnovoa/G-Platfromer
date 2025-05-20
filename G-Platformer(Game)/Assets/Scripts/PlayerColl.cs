using UnityEngine;
using UnityEngine.Events;
public class PlayerColl : MonoBehaviour
{
  public string eltag;
  public UnityEvent onEnter, onStay, onExit;
 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(eltag))
        {
           
            onEnter.Invoke();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            
            onStay.Invoke();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            
            onExit.Invoke();
        }


    }

}
