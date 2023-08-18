using UnityEngine;

public static class ProbabilitiesController
{
    public static bool CheckProbability(int probabilityNumber)
    {
        int randomNumber = Random.Range(0, 101);

        if (randomNumber <= probabilityNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}