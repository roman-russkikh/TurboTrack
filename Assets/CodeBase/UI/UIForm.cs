using UnityEngine;

namespace Codebase.UI
{
    /// <summary>
    ///   <para> UIForm is a base class for all UI elements - windows, buttons, widgets etc..</para>
    /// </summary>
    public class UIForm : MonoBehaviour 
    {
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}