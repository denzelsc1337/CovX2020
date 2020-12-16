using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSelection : MonoBehaviour
{
    public bool isUnlock = false;
    public GameObject lockGo;
    public GameObject unlockGo;

    public int mapIndex;//el index de este mapa
    public int questNum;//Cuantas mascarillas puede desbloquear este mapa
    public int startLevel;
    public int endLevel;

    private void Update()
    {
        UpdateMapStatus();
        UnlockMap();
    }
    private void UpdateMapStatus()
    {
        if (isUnlock) //poder jugar este mapa
        {
            unlockGo.gameObject.SetActive(true);
            lockGo.gameObject.SetActive(false);
        }
        else // este mapa sigue bloqueado
        {
            unlockGo.gameObject.SetActive(false);
            lockGo.gameObject.SetActive(true);
        }
    }

    private void UnlockMap()//si el numero de mascarillas actuales es mayor que lo requerido se desbloqueara tambien 
    {
        if (UIManager.instance.masc >= questNum)
        {
            isUnlock = true;
        }
        else
        {
            isUnlock = false;
        }
    }
}
