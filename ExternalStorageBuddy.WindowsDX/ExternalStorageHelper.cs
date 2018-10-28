using System;
using System.Threading.Tasks;

namespace ExternalStorageBuddy.WindowsDX
{
	public class ExternalStorageHelper : IExternalStorageHelper
	{
		public bool IsExternalStorageAvailable => true;

		public bool HasPermission => true;

		public event EventHandler<ExternalStoragePermissionEventArgs> StoragePermissionGranted;

		public Task AskPermission()
		{
			if (null != StoragePermissionGranted)
			{
				StoragePermissionGranted(this, new ExternalStoragePermissionEventArgs(true));
			}
			return Task.CompletedTask;
		}
	}
}
