using System;
using System.Threading.Tasks;

namespace ExternalStorageBuddy
{
	public interface IExternalStorageHelper
	{
		bool IsExternalStorageAvailable { get; }

		/// <summary>
		/// This is a flag used to tell if we have a result from asking permission.
		/// </summary>
		bool HasResult { get; set; }

		bool HasPermission { get; }

		Task AskPermission();

		event EventHandler<ExternalStoragePermissionEventArgs> StoragePermissionGranted;
	}
}
