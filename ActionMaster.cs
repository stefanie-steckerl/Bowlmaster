using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{

    public enum Action { Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction (List<int> pinFalls){
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls){
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }

    public Action Bowl(int pins) //TODO Make private
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins!");
        }

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.EndGame;
        }

        // Handle last frame special cases
        if (bowl >= 19 && pins == 10)
        {
            bowl += 1;
            return Action.Reset;
        }
        else if (bowl == 20)
        {
            bowl += 1;
            if (bowls[19-1]==10 && bowls[20-1] !=10){
                return Action.Tidy;
            }
            else if (bowls[19 - 1] + bowls[20 - 1] == 10)
            {
            return Action.Reset;
            }
            else if (Bowl21Awarded())
            {
            return Action.Tidy;
            }
            else
            {
            return Action.EndGame;
            }
        }

        //If first bowl of frame and not a strike, return Action.Tidy
        //If two bowls of frame have been bowled, return Action.EndTurn
        if (bowl % 2 != 0) {
            if (pins == 10)
            {
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                bowl += 1;
                return Action.Tidy;
            } 
        }   else if (bowl % 2 == 0){
            bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded(){
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }



}
