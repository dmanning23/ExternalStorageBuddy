using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExternalStorageBuddy
{
	public interface IExternalStorageHelper
	{
		bool IsExternalStorageAvailable { get; }

		bool HasPermission { get; }

		Task AskPermission();

		event EventHandler<ExternalStoragePermissionEventArgs> StoragePermissionGranted;
	}
}
