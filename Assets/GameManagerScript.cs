using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    //�z��̐錾
    int[] map;

    // Start is called before the first frame update

    void PrintArray()
    {
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            //�v�f��������o��
            // Debug.Log(map[i] + ",");

            //�ύX�B������Ɍ������Ă���
            debugText += map[i].ToString() + ",";
        }

        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }

        return -1;
    }

    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }

        if (map[moveTo] == 2)
        {
            int velocity = moveTo - moveFrom;

            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            if(!success)
            {
                return false;
            }
        }

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    void Start()  //Initialize
    {
        //�z��̎��Ԃ̐����Ə�����
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int PlayerIndex = GetPlayerIndex();

            MoveNumber(1, PlayerIndex, PlayerIndex + 1);

            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            int PlayerIndex = GetPlayerIndex();

            MoveNumber(1, PlayerIndex, PlayerIndex - 1);

            PrintArray();
        }

    }
}
