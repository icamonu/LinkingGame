using ScriptableObjects.EventChannel;
using UnityEngine;

namespace Core
{
    public class TouchController : MonoBehaviour
    {
        public ChipSelectionEventChannel chipSelectionEventChannel;
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                chipSelectionEventChannel.RaiseTouchEndedEvent();
            }
        }
    }
}

