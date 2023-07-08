using UnityEngine;

public class EngineUtils
{
  public static void QuitGame()
  {
    // TODO: Save game data here as a backup.
    // In theory things should be saved as they happen in game.
    Application.Quit();
  }
}
