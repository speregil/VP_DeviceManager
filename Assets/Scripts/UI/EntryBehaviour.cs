using TMPro;
using UnityEngine;

namespace vp.deviceManager.UI
{
    public class EntryBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameLbl;
        [SerializeField] private GameObject poseGroup;
        [SerializeField] private GameObject trackGroup1;
        [SerializeField] private GameObject trackGroup2;
        [SerializeField] private float collapsedHeight = 50.0f;
        [SerializeField] private float fullHeight = 150.0f;

        private string entryName;

        private RectTransform rectTransform;
        
        private bool isCollapsed = false;

        public void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public string GetEntryName()
        {
            return entryName;
        }

        public void SetEntryName(string name)
        {
            entryName = name;
            nameLbl.text = entryName;
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