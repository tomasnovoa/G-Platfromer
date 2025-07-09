using UnityEngine;
using UnityEngine.Events;
public class HpSystem : MonoBehaviour
{
 public int hp;
    public UnityEvent onHit, onMuere;
    public bool destruirAlMorir;

   

    public void TakeDamage(int damage)
    {
        hp -= damage;
        AudioManager.Instance.PlaySFX("Dead");
        CheckHP();
    }

    void CheckHP()
    {
        if (hp > 0)
            Hit();
        else
            Muere();
    }

    void Hit()
    {
        onHit.Invoke();
    }
    void Muere()
    {
        onMuere.Invoke();
        if (destruirAlMorir) Destroy(gameObject);
    }
}
