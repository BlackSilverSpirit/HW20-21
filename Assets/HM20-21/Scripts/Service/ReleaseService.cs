using UnityEngine;

namespace HM20_21.Scripts
{
    public class ReleaseService
    {
        public void Release(IGrabbable grabbable)
        {
            if (grabbable != null)
                grabbable.OnRelease();
        }
    }
}