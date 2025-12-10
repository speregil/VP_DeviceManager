using System.Collections.Generic;
using System.Text;
using vp.deviceManager.UI;

public interface IDevice
{
	public string GetDeviceName();
	public void   GetDeviceInformation(StringBuilder sb, string prefix, UIBehaviour listener);
}

public class IDeviceComparer : IComparer<IDevice>
{
	public int Compare(IDevice x, IDevice y)
	{
		return string.Compare(x.GetDeviceName(), y.GetDeviceName());
	}

	public static readonly IDeviceComparer Instance = new IDeviceComparer();
}
