using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
   public static bool IsGameStarted = false;
   public GameObject Logo, PlayImage, CountMoves, LoseText, WinText, ShopImage;

    private bool IsLoseGame = false, IsWinGame = false;
   
   public void PlayGame()
   {
     if(!IsLoseGame && !IsWinGame)
   {
      IsGameStarted = true;
      Logo.SetActive(false);
      PlayImage.SetActive(false);
      CountMoves.SetActive(true);
   }else
      SceneManager.LoadScene( SceneManager.GetActiveScene().name);
   
   }

   public void WinGame()
   {
      IsWinGame = true;
      Logo.SetActive(true);
      PlayImage.SetActive(true);
      WinText.SetActive(true);
      ShopImage.SetActive(true);
      CountMoves.SetActive(false);
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
