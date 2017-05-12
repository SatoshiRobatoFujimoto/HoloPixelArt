using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkitExtensions.Messaging
{
    public delegate void MessengerCallback<in T>(T arg);
}
