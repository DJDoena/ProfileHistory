namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Windows.Forms;
    using DVDProfilerHelper;
    using Microsoft.WindowsAPICodePack.Taskbar;

    internal sealed class ProgressBarHandler : IDisposable
    {
        private readonly ProgressWindow _ProgressWindow;

        private readonly Control _Host;

        public ProgressBarHandler(Control host)
        {
            _Host = host;

            _ProgressWindow = new ProgressWindow();
            _ProgressWindow.ProgressBar.Minimum = 0;
            _ProgressWindow.ProgressBar.Step = 1;
        }

        public void Start(Int32 maximum)
        {
            _Host.Invoke(new Action(() => StartInternal(maximum)));
        }
        
        public void Update()
        {
            _Host.Invoke(new Action(UpdateInternal));
        }

        public void Close()
        {
            _Host.Invoke(new Action(CloseInternal));
}

        public void Dispose()
        {
            _ProgressWindow.Dispose();
        }

        private void StartInternal(Int32 maximum)
        {
            _ProgressWindow.ProgressBar.Maximum = maximum;
            _ProgressWindow.CanClose = false;
            _ProgressWindow.Show();

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.OwnerHandle = _Host.Handle;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                TaskbarManager.Instance.SetProgressValue(0, _ProgressWindow.ProgressBar.Maximum);
            }
        }

        private void UpdateInternal()
        {
            _ProgressWindow.ProgressBar.PerformStep();

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressValue(_ProgressWindow.ProgressBar.Value, _ProgressWindow.ProgressBar.Maximum);
            }
        }

        private void CloseInternal()
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                TaskbarManager.Instance.OwnerHandle = IntPtr.Zero;
            }

            _ProgressWindow.CanClose = true;
            _ProgressWindow.Close();
        }
    }
}