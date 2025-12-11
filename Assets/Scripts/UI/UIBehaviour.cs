using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

namespace vp.deviceManager.UI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject deviceEntry;
        [SerializeField] private GameObject deviceList;
        [SerializeField] private GameObject scrollView;


        private bool listCollapsed = false;

        public void AddDevice(string name)
        {
            GameObject entry = Instantiate(deviceEntry, deviceList.transform);
            EntryBehaviour entryBehaviour = entry.GetComponent<EntryBehaviour>();
            entryBehaviour.SetEntryName(name);
        }

        public void UpdateDevicePosition(string name, string variable, float[] pose)
        {
            EntryBehaviour entry = GetEntry(name);
            if(entry != null)
            {
                entry.UpdatePose(pose);
            }
        }

        public void UpdateDeviceState(string name, string variable, bool state)
        {
            EntryBehaviour entry = GetEntry(name);
            if (entry != null)
            {
                string[] variableParse = variable.Split("/");
                entry.UpdateState(variableParse[2], state);
            }
        }

        public void UpdateDeviceInput(string name, string variable, string input)
        {
            Debug.Log("Updating " + variable + "on " + name + " - " + input);
        }

        public EntryBehaviour GetEntry(string name)
        {
            foreach (Transform entry in deviceList.transform)
            {
                EntryBehaviour entryBehaviour = entry.gameObject.GetComponent<EntryBehaviour>();
                if (entryBehaviour != null && entryBehaviour.GetEntryName() == name)
                {
                    return entryBehaviour;
                }
            }
            return null;
        }

        public void OnListCollapse()
        {
            scrollView.SetActive(listCollapsed);
            listCollapsed = !listCollapsed;
        }
    }
}