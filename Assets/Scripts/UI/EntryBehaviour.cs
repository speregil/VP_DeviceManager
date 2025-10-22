using UnityEngine;

namespace vp.deviceManager.UI
{
    public class EntryBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject poseGroup;
        [SerializeField] private GameObject trackGroup1;
        [SerializeField] private GameObject trackGroup2;
        [SerializeField] private float collapsedHeight = 50.0f;
        [SerializeField] private float fullHeight = 150.0f;

        private RectTransform rectTransform;
        private bool isCollapsed = false;

        public void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnDeviceCollapse()
        {
            poseGroup.SetActive(isCollapsed);
            trackGroup1.SetActive(isCollapsed);
            trackGroup2.SetActive(isCollapsed);

            float currentHeight = isCollapsed? fullHeight: collapsedHeight;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, currentHeight);

            isCollapsed = !isCollapsed;
        }
    }
}