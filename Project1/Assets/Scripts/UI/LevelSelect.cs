using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelSelect : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] int numberLv;
    [SerializeField] public AudioClip click;
    public void LvSelect()
    {
       
        SceneManager.LoadScene("Level" + numberLv.ToString());
       

    }
    public void OnPointerEnter(PointerEventData even)
    {
        SoundManager.Instance.PlaySound(click);

    }
}
