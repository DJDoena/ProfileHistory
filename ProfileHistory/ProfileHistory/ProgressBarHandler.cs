namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Windows.Forms;
    using DVDProfilerHelper;
    using Microsoft.WindowsAPICodePack.Taskbar;

    internal sealed class ProgressBarHandler : IDisposable
    {
        private readonly ProgressWindow _ProgressWindow;

        private readonly IntPtr _Handle;

        public ProgressBarHandler(IntPtr handle)
        {
            _Handle = handle;

            _ProgressWindow = new ProgressWindow();
            _ProgressWindow.ProgressBar.Minimum = 0;
            _ProgressWindow.ProgressBar.Step = 1;
        }

        public void Start(Int32 maximum)
        {
            _ProgressWindow.ProgressBar.Maximum = maximum;
            _ProgressWindow.CanClose = false;
            _ProgressWindow.Show();

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.OwnerHandle = _Handle;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                TaskbarManager.Instance.SetProgressValue(0, _ProgressWindow.ProgressBar.Maximum);
            }

            Application.DoEvents();
        }

        public void Update()
        {
            _ProgressWindow.ProgressBar.PerformStep();

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressValue(_ProgressWindow.ProgressBar.Value, _ProgressWindow.ProgressBar.Maximum);
            }

            Application.DoEvents();
        }

        public void Close()
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                TaskbarManager.Instance.OwnerHandle = IntPtr.Zero;
            }

            _ProgressWindow.CanClose = true;
            _ProgressWindow.Close();
        }

        public void Dispose()
        {
            _ProgressWindow.Dispose();
        }
    }
}