using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
   public static bool IsGameStarted = false;
   public GameObject Logo, PlayImage, CountMoves, LoseText;

    private bool IsLoseGame = false;
   
   public void PlayGame()
   {
    if(!IsLoseGame)
   {
      IsGameStarted = true;
      Logo.SetActive(false);
      PlayImage.SetActive(false);
      CountMoves.SetActive(true);
   }else
      SceneManager.LoadScene( SceneManager.GetActiveScene().name);
   
   }

public void LoseGame()
{
    IsLoseGame = true;
    IsGameStarted = false;
    Logo.SetActive(true);
    PlayImage.SetActive(true);
    CountMoves.SetActive(false);
    LoseText.SetActive(true);

}





  
   




}
