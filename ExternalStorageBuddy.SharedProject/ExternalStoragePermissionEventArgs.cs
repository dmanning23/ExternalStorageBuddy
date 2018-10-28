using System;

namespace ExternalStorageBuddy
{
	public class ExternalStoragePermissionEventArgs : EventArgs
	{
		public bool PermissionGranted { get; set; }
		public string ErrorMessage { get; set; }

		public ExternalStoragePermissionEventArgs()
		{
		}

		public ExternalStoragePermissionEventArgs(bool permissionGranted, string errorMessage = "")
		{
			PermissionGranted = permissionGranted;
			ErrorMessage = errorMessage;
		}
	}
}
