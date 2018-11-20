using System;
using System.Threading.Tasks;
using Android.OS;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Environment = Android.OS.Environment;

namespace ExternalStorageBuddy.Android
{
	public class ExternalStorageHelper : IExternalStorageHelper
	{
		#region Properties

		public bool IsExternalStorageAvailable
		{
			get
			{
				return Environment.MediaMounted.Equals(Environment.ExternalStorageState);
			}
		}

		public bool HasPermission
		{
			get
			{
				return CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage).Result == PermissionStatus.Granted;
			}
		}

		public bool HasResult { get; set; }

		public event EventHandler<ExternalStoragePermissionEventArgs> StoragePermissionGranted;

		#endregion //Properties

		#region Methods

		public ExternalStorageHelper()
		{
			HasResult = false;

			StoragePermissionGranted += ExternalStorageHelper_StoragePermissionGranted;
		}

		private void ExternalStorageHelper_StoragePermissionGranted(object sender, ExternalStoragePermissionEventArgs e)
		{
			HasResult = true;
		}

		public async Task AskPermission()
		{
			if (!IsExternalStorageAvailable)
			{
				//There is no external storage available!!!
				if (null != StoragePermissionGranted)
				{
					StoragePermissionGranted(this, new ExternalStoragePermissionEventArgs(false, "No external storage available"));
				}
			}
			else if (HasPermission)
			{
				//The app already has external storage permission!!!
				if (null != StoragePermissionGranted)
				{
					StoragePermissionGranted(this, new ExternalStoragePermissionEventArgs(true));
				}
			}
			else
			{
				var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
				if (null != StoragePermissionGranted)
				{
					if (results[Permission.Storage] == PermissionStatus.Granted)
					{
						StoragePermissionGranted(this, new ExternalStoragePermissionEventArgs(true));
					}
					else
					{
						StoragePermissionGranted(this, new ExternalStoragePermissionEventArgs(false, $"Permission status: {results[Permission.Storage].ToString()}"));
					}
				}
			}
		}

		#endregion //Methods
	}
}
