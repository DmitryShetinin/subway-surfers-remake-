using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Button _restar;
    public Button _exit;
    // Start is called before the first frame update
    void Start()
    {
        _restar.onClick.AddListener(Restart);
        _exit.onClick.AddListener(Exit);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void Exit()
    {
        Application.Quit();
    }
}
