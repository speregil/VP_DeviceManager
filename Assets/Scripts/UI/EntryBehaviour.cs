using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace vp.deviceManager.UI
{
    public class EntryBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameLbl;
        [SerializeField] private GameObject collapseButton;
        [SerializeField] private GameObject poseGroup;
        [SerializeField] private GameObject trackGroup1;
        [SerializeField] private GameObject trackGroup2;
        [SerializeField] private float collapsedHeight = 50.0f;
        [SerializeField] private float fullHeight = 150.0f;
        [SerializeField] private Sprite openSprite;
        [SerializeField] private Sprite closeSprite;

        private string entryName;
        private RectTransform rectTransform;
        private Image collapseButtonSprite;
        private Dictionary<string, GameObject> stateMaps = new Dictionary<string, GameObject>();

        private bool isCollapsed = false;

        public void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            collapseButtonSprite = collapseButton.GetComponent<Image>();
            CreateStateMap();
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

            collapseButtonSprite.sprite = isCollapsed ? closeSprite : openSprite;

            isCollapsed = !isCollapsed;
        }

        public void UpdatePose(float[] pose)
        {
            if (!isCollapsed)
            {
                Transform poseX = poseGroup.transform.GetChild(1);
                Transform poseY = poseGroup.transform.GetChild(2);
                Transform poseZ = poseGroup.transform.GetChild(3);

                poseX.gameObject.GetComponent<TMP_Text>().text = "X: " + pose[0].ToString("F2");
                poseY.gameObject.GetComponent<TMP_Text>().text = "Y: " + pose[1].ToString("F2");
                poseZ.gameObject.GetComponent<TMP_Text>().text = "Z: " + pose[2].ToString("F2");
            }
        }

        public void UpdateState(string field, bool state)
        {
            if (!isCollapsed)
            {
                GameObject toggle;
                if (stateMaps.TryGetValue(field, out toggle))
                {
                    toggle.GetComponent<Toggle>().isOn = state;
                }
            }
        }

        private void CreateStateMap()
        {
            stateMaps.Add("tracked", trackGroup1.transform.Find("TrackedTgl").gameObject);
            stateMaps.Add("output1", trackGroup1.transform.Find("OutputTgl").gameObject);
            stateMaps.Add("input1", trackGroup2.transform.Find("Input1Tgl").gameObject);
            stateMaps.Add("input2", trackGroup2.transform.Find("Input2Tgl").gameObject);
            stateMaps.Add("input3", trackGroup2.transform.Find("Input3Tgl").gameObject);
            stateMaps.Add("input4", trackGroup2.transform.Find("Input4Tgl").gameObject);
        }
    }
}