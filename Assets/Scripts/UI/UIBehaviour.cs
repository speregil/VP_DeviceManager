using UnityEngine;

namespace vp.deviceManager.UI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject deviceEntry;
        [SerializeField] private GameObject deviceList;
        

        private bool listCollapsed = false;

        public void OnListCollapse()
        {
            foreach (Transform entry in deviceList.transform)
            {
                entry.gameObject.SetActive(listCollapsed);
            }
            listCollapsed = !listCollapsed;
        }

        public void OnDeviceCollapse(string deviceTag)
        {

        }
    }
}