using ERMM.GenericData.GUIs;
using UnityEngine;
/* GUIPanelRoot that will manage common functionalities for GUI panels like showing, 
 * hiding, and toggling visibility, we will design it in such a way that it can be 
 * extended by any specific panel classes.
 * */
/* Demo usage */
/*
public class SpecificGUIPanel : GUIPanelRoot
{
    protected override void OnShow()
    {
        // Additional behavior specific to this panel when it's shown
        Debug.Log("Specific Panel is now shown!");
    }

    protected override void OnHide()
    {
        // Additional behavior specific to this panel when it's hidden
        Debug.Log("Specific Panel is now hidden!");
    }
}
*/


namespace ERMM.GenericData.GUIs
{
    public class GUIPanelRoot : MonoBehaviour
    {
        // Public property to control initial visibility on start
        public bool isVisibleOnStart = true;

        // Property to track the current visibility state of the panel
        public bool IsVisible { get; private set; }

        // Unity Start method to set initial visibility based on isVisibleOnStart
        void Start()
        {
            OnStart();

            if (isVisibleOnStart)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        #region Enable DisableHook

        private void OnEnable()
        {
            Show();
        }
        private void OnDisable()
        {
            Hide();
        }
        #endregion

        // Method to show the panel
        public void Show()
        {
            this.gameObject.SetActive(true);
            IsVisible = true;
            OnShow();  // Optional: Hook for derived classes to add extra behavior when shown
        }

        // Method to hide the panel
        public void Hide()
        {
            this.gameObject.SetActive(false);
            IsVisible = false;
            OnHide();  // Optional: Hook for derived classes to add extra behavior when hidden
        }

        // Method to toggle the visibility of the panel
        public void Toggle()
        {
            if (IsVisible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        // Virtual methods to be overridden in subclasses if additional actions are needed on show or hide
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }

        protected virtual void OnStart() {}
    }
}

