using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] int numberLv;
    [SerializeField] public AudioClip click;
    private bool isLocked;
  
    public void LvSelect()
    {

        if (!isLocked)
        {
            SceneManager.LoadScene("Level " + numberLv.ToString());
            Time.timeScale = 1;
        }
       

    }
    public void OnPointerEnter(PointerEventData even)
    {
        if (!isLocked) SoundManager.Instance.PlaySound(click);

    }
    public void Lock()
    {
        isLocked = true;
        gameObject.GetComponent<Image>().color = Color.black;
    }
    public void Unlock()
    {
        isLocked = false;
        gameObject.GetComponent<Image>().color = Color.white;

    }
}
