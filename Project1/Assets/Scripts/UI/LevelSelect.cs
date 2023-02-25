using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] int numberLv;
    public void LvSelect()
    {
        SceneManager.LoadScene("Level" + numberLv.ToString());
    }
}
