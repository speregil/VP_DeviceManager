using UnityEngine;

namespace vp.deviceManager.UI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject deviceEntry;
        [SerializeField] private GameObject deviceList;
        

        private bool listCollapsed = false;

        public void AddDevice(string name)
        {
            GameObject entry = Instantiate(deviceEntry, deviceList.transform);
            EntryBehaviour entryBehaviour = entry.GetComponent<EntryBehaviour>();
            entryBehaviour.SetEntryName(name);
        }

        public bool IsDeviceOnList(string name)
        {
            foreach(Transform entry in deviceList.transform)
            {
                EntryBehaviour entryBehaviour = entry.gameObject.GetComponent<EntryBehaviour>();
                if (entryBehaviour != null && entryBehaviour.GetEntryName() == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void OnListCollapse()
        {
            foreach (Transform entry in deviceList.transform)
            {
                entry.gameObject.SetActive(listCollapsed);
            }
            listCollapsed = !listCollapsed;
        }
    }
}