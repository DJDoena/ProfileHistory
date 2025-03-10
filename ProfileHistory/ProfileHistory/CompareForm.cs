﻿namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using DoenaSoft.ToolBox.Generics;
    using DVDProfilerXML.Version400;

    internal partial class CompareForm : Form
    {
        public CompareForm(IEnumerable<ProfileTuple> profiles)
        {
            this.InitializeComponent();

            String profileXml = profiles.First().ProfileXml;

            DVD profile = XmlSerializer<DVD>.FromString(profileXml, Collection.DefaultEncoding);

            this.Text += ": " + profile.Title;

            this.AddRows(LeftListView, profiles);
            this.AddRows(RightListView, profiles);
        }

        private void AddRows(ListView listView, IEnumerable<ProfileTuple> profiles)
        {
            ListViewItem[] rows = profiles.Select(this.AddRow).ToArray();

            listView.Items.AddRange(rows);
        }

        private ListViewItem AddRow(ProfileTuple profile)
        {
            DateTimeFormatInfo formatInfo = Thread.CurrentThread.CurrentCulture.DateTimeFormat;

            String dateFormat = formatInfo.ShortDatePattern;

            String timeFormat = formatInfo.ShortTimePattern;

            String[] cells = new[] { profile.FileInfo.LastWriteTime.ToString(dateFormat + " " + timeFormat), profile.FileInfo.Name };

            ListViewItem row = new ListViewItem(cells)
            {
                Tag = profile.ProfileXml
            };

            return (row);
        }

        private void OnCompareButtonClick(Object sender, EventArgs e)
        {
            if (LeftListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show(MessageBoxTexts.NoLeftProfileSelected, MessageBoxTexts.WarningHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (RightListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show(MessageBoxTexts.NoRightProfileSelected, MessageBoxTexts.WarningHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DVD left = GetDvd(LeftListView);

            DVD right = GetDvd(RightListView);

            using (DetailsForm form = new DetailsForm(left, right))
            {
                form.ShowDialog();
            }
        }

        private static DVD GetDvd(ListView listView)
        {
            Int32 selectedIndex = listView.SelectedIndices[0];

            String xml = (String)(listView.Items[selectedIndex].Tag);

            DVD dvd = XmlSerializer<DVD>.FromString(xml, Collection.DefaultEncoding);

            return (dvd);
        }
    }
}