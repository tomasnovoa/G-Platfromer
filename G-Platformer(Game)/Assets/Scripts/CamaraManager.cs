using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
   
    public CinemachineCamera camara;
    public void switchPriority( int prioridad)
    {
        camara.Priority = prioridad;
    }

}
