using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkitExtensions.Messaging;
using HoloPixelArt.Messages;

namespace HoloPixelArt
{
    public class SpeechCommandHandler : MonoBehaviour
    {
        public void CreateNewGrid()
        {
            Messenger.Instance.Broadcast(new CreateNewGridMessage());
        }

        public void ChangeColorToBlue()
        {
            Messenger.Instance.Broadcast(new ChangeColorMessage() {Color = Color.blue});
        }

        public void ChangeColorToRed()
        {
            Messenger.Instance.Broadcast(new ChangeColorMessage() { Color = Color.red });
        }

        public void ChangeColorToYellow()
        {
            Messenger.Instance.Broadcast(new ChangeColorMessage() { Color = Color.yellow });
        }

        public void ChangeColorToGreen()
        {
            Messenger.Instance.Broadcast(new ChangeColorMessage() { Color = Color.green });
        }

        public void ChangeColorToGray()
        {
            Messenger.Instance.Broadcast(new ChangeColorMessage() { Color = Color.gray });
        }
    }
}

