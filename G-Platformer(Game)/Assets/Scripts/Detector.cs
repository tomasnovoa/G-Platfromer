using UnityEngine;
using UnityEngine.Events;
public class Detector : MonoBehaviour
{

    public UnityEvent action;


    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            action.Invoke();
        
        
    }
}
