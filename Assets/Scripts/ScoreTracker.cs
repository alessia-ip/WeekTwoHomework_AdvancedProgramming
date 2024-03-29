using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker
{
   public enum Winner
   {
      Red,
      Blue,
      Tie
   }
   
   public int redScore = 0;
   public int blueScore = 0;

   //this is so we know who wins, and how to score at the end
   public Winner isRedScoreGreater()
   {
      if (redScore < blueScore)
      {
         return Winner.Blue;
      } else if (redScore > blueScore)
      {
         return Winner.Red;
      }
      else
      {
         return Winner.Tie;
      }
   }

   public void ClearScore()
   {
      redScore = 0;
      blueScore = 0;
   }

   //we add points based on which team scored
   public void AddToScore(GameObject playerThatScored)
   {
      if (playerThatScored.tag == "Red")
      {
         redScore++;
      }
      else
      {
         blueScore++;
      }
   }

   
}
