using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class ButtonBeheviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("Highlighted");
       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
      
    }
   
}
