
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectControl : MonoBehaviour
{
    public static LevelSelectControl instance { get; private set; }
    [SerializeField] List<GameObject> lv;
    public static int lockLv = 2; 
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
        
        //lock from lv lockLv
        for (int i = lockLv; i <= lv.Count; i++)
        {
            lv[i - 1].GetComponent<LevelSelect>().Lock();
        }
        for (int i = 1; i < lockLv; i++)
        {
            UnLockLevel(i);
        }
    }
    private void Start()
    {
       
    }
    public void UnLockLevel(int x)
    {
        if (lv.Count >= x) lv[x - 1].GetComponent<LevelSelect>().Unlock();
        else return;
    }

}
