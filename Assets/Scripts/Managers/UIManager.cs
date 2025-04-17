using UnityEngine.UIElements;
using Utils;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private UIDocument _uiDoc;

        protected override void Awake()
        {
            base.Awake();
            if (!TryGetComponent(out _uiDoc))
            {
                _uiDoc =  gameObject.AddComponent<UIDocument>();
            }
        }

        public void ChangeUI(VisualTreeAsset visualTreeAsset)
        {
            _uiDoc.visualTreeAsset = visualTreeAsset;
        }
        
        /*public void AddUI(VisualTreeAsset visualTreeAsset)
        {
            var root = _uiDoc.rootVisualElement;
            VisualElement uiInstance = visualTreeAsset.CloneTree();
            root.Add(uiInstance);
        }
        
        public void RemoveUI(VisualTreeAsset visualTreeAsset)
        {
            var root = _uiDoc.rootVisualElement;
            VisualElement uiInstance = visualTreeAsset.CloneTree();
            root.Remove(uiInstance);
        }*/
    }
}
