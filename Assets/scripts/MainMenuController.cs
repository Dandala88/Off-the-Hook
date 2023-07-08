using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void LoadGame()
  {
    SceneManager.LoadScene("Main");
  }

  public void QuitGame()
  {
    Debug.Log("Quitting Game");
    EngineUtils.QuitGame();
  }
}
