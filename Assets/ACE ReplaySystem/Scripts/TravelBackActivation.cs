using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Replay;

namespace ReplayExmpleScripts
{
    public class TravelBackActivation : MonoBehaviour
    {
        public ReplayManager replay;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                replay.StartTravelBack(20f);
            }



            if (Input.GetKeyDown(KeyCode.F))
            {
                replay.StartTravelBack();
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                replay.ExitTravelBack();
            }
        }
    }
}


