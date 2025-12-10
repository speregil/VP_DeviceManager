using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

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

        public void UpdateDevicePosition(string name, string variable, float[] pose)
        {
            Debug.Log("Updating " + variable + " on " + name + " - " + pose);
        }

        public void UpdateDeviceState(string name, string variable, bool state)
        {
            Debug.Log("Updating " + variable + "on " + name + " - " + state);
        }

        public void UpdateDeviceInput(string name, string variable, string input)
        {
            Debug.Log("Updating " + variable + "on " + name + " - " + input);
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