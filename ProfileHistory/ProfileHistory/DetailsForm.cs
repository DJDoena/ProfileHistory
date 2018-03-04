namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using DateTimePickerWithBackColor;
    using DVDProfilerHelper;
    using DVDProfilerXML.Version400;

    public partial class DetailsForm : Form
    {
        private readonly DVD _LeftDvd;

        private readonly DVD _RightDvd;

        public DetailsForm(DVD leftDvd, DVD rightDvd)
        {
            InitializeComponent();

            CultureInfo ci = CultureInfo.CurrentCulture;

            String format = ci.DateTimeFormat.ShortDatePattern + "\t" + ci.DateTimeFormat.LongTimePattern;

            LeftProfileTimestampPicker.CustomFormat = format;
            LeftLastEditedPicker.CustomFormat = format;

            RightProfileTimestampPicker.CustomFormat = format;
            RightLastEditedPicker.CustomFormat = format;

            _LeftDvd = leftDvd;
            _RightDvd = rightDvd;

            DateTime newestLeftTimeStamp = (leftDvd.LastEdited > leftDvd.ProfileTimestamp) ? leftDvd.LastEdited : leftDvd.ProfileTimestamp;

            Boolean leftIsNewer = ((newestLeftTimeStamp > rightDvd.ProfileTimestamp) && (newestLeftTimeStamp > rightDvd.LastEdited));

            LeftUpcTextBox.Text = leftDvd.UPC;
            RightUpcTextBox.Text = rightDvd.UPC;

            LeftTitleTextBox.Text = leftDvd.Title;
            RightTitleTextBox.Text = rightDvd.Title;
            ColourizeTextBox(leftIsNewer, LeftTitleTextBox, RightTitleTextBox);

            LeftEditionTextBox.Text = leftDvd.Edition;
            RightEditionTextBox.Text = rightDvd.Edition;
            ColourizeTextBox(leftIsNewer, LeftEditionTextBox, RightEditionTextBox);

            LeftOriginalTitleTextBox.Text = leftDvd.OriginalTitle;
            RightOriginalTitleTextBox.Text = rightDvd.OriginalTitle;
            ColourizeTextBox(leftIsNewer, LeftOriginalTitleTextBox, RightOriginalTitleTextBox);

            LeftLocalityTextBox.Text = leftDvd.ID_LocalityDesc;
            RightLocalityTextBox.Text = rightDvd.ID_LocalityDesc;

            LeftProfileTimestampPicker.Value = leftDvd.ProfileTimestamp;
            RightProfileTimestampPicker.Value = rightDvd.ProfileTimestamp;
            ColourizePicker(leftIsNewer, LeftProfileTimestampPicker, RightProfileTimestampPicker);

            LeftLastEditedPicker.Value = leftDvd.LastEditedSpecified ? leftDvd.LastEdited : LeftLastEditedPicker.MinDate;
            RightLastEditedPicker.Value = rightDvd.LastEditedSpecified ? rightDvd.LastEdited : LeftLastEditedPicker.MinDate;
            ColourizePicker(leftIsNewer, LeftLastEditedPicker, RightLastEditedPicker);

            LeftPurchaseDatePicker.Value = PurchaseDateIsSpecified(leftDvd) ? leftDvd.PurchaseInfo.Date : LeftLastEditedPicker.MinDate;
            RightPurchaseDatePicker.Value = PurchaseDateIsSpecified(rightDvd) ? rightDvd.PurchaseInfo.Date : LeftLastEditedPicker.MinDate;
            ColourizePicker(leftIsNewer, LeftPurchaseDatePicker, RightPurchaseDatePicker);

            LeftPurchasePlaceTextBox.Text = PurchaseIsNotNull(leftDvd) ? leftDvd.PurchaseInfo.Place : String.Empty;
            RightPurchasePlaceTextBox.Text = PurchaseIsNotNull(rightDvd) ? rightDvd.PurchaseInfo.Place : String.Empty;
            ColourizeTextBox(leftIsNewer, LeftPurchasePlaceTextBox, RightPurchasePlaceTextBox);

            LeftPurchasePriceTextBox.Text = PriceIsNotNull(leftDvd) ? leftDvd.PurchaseInfo.Price.FormattedValue : String.Empty;
            RightPurchasePriceTextBox.Text = PriceIsNotNull(rightDvd) ? rightDvd.PurchaseInfo.Price.FormattedValue : String.Empty;
            ColourizeTextBox(leftIsNewer, LeftPurchasePriceTextBox, RightPurchasePriceTextBox);

            FillCastTextBox(leftIsNewer, leftDvd.CastList, rightDvd.CastList, LeftCastTextBox, RightCastTextBox);

            FillCrewTextBox(leftIsNewer, leftDvd.CrewList, rightDvd.CrewList, LeftCrewTextBox, RightCrewTextBox);

            FillEventsTextBox(leftIsNewer, leftDvd, rightDvd, LeftEventsTextBox, RightEventsTextBox);

            FillTagsTextBox(leftIsNewer, leftDvd, rightDvd, LeftTagsTextBox, RightTagsTextBox);

            FillMyLinksTextBox(leftIsNewer, leftDvd, rightDvd, LeftMyLinksTextBox, RightMyLinksTextBox);

            FillBoxSetTextBox(leftIsNewer, leftDvd, rightDvd, LeftBoxSetTextBox, RightBoxSetTextBox);
        }

        private static Boolean PurchaseDateIsSpecified(DVD leftDvd)
            => (leftDvd.PurchaseInfo?.DateSpecified == true);

        private static Boolean PurchaseIsNotNull(DVD dvd)
            => (dvd.PurchaseInfo != null);

        private static Boolean PriceIsNotNull(DVD dvd)
            => (dvd.PurchaseInfo?.Price != null);

        private void FillBoxSetTextBox(Boolean leftIsNewer, DVD leftDvd, DVD rightDvd, TextBox leftTextBox, TextBox rightTextBox)
        {
            GetBoxSetContent(leftDvd, out String leftBoxSetParent, out Int32 leftBoxSetParentCount, out String[] leftBoxSetContents, out Int32 leftBoxSetContentsLength);
            GetBoxSetContent(rightDvd, out String rightBoxSetParent, out Int32 rightBoxSetParentCount, out String[] rightBoxSetContents, out Int32 rightBoxSetContentsLength);

            WriteBoxSetEntry(leftBoxSetParentCount, leftBoxSetContentsLength, leftTextBox);
            WriteBoxSetEntry(rightBoxSetParentCount, rightBoxSetContentsLength, rightTextBox);
            ColourizeTextBox(leftIsNewer, leftTextBox, rightTextBox);

            if ((leftBoxSetParentCount == rightBoxSetParentCount) && (leftBoxSetContentsLength == rightBoxSetContentsLength))
            {
                String leftBoxSet = DVDProfilerSerializer<BoxSet>.ToString(leftDvd.BoxSet ?? new BoxSet());

                String rightBoxSet = DVDProfilerSerializer<BoxSet>.ToString(rightDvd.BoxSet ?? new BoxSet());

                CheckListSpecific(leftIsNewer, leftBoxSet, rightBoxSet, leftTextBox, rightTextBox);
            }
        }

        private static void GetBoxSetContent(DVD dvd, out String boxSetParent, out Int32 boxSetParentCount, out String[] boxSetContents, out Int32 boxSetContentsLength)
        {
            boxSetParent = null;

            boxSetParentCount = 0;

            boxSetContents = null;

            boxSetContentsLength = 0;

            if (dvd.BoxSet != null)
            {
                if (String.IsNullOrEmpty(dvd.BoxSet.Parent) == false)
                {
                    boxSetParent = dvd.BoxSet.Parent;

                    boxSetParentCount = 1;
                }

                boxSetContents = dvd.BoxSet.ContentList;

                if (boxSetContents != null)
                {
                    boxSetContentsLength = boxSetContents.Length;
                }
            }
        }

        private void WriteBoxSetEntry(Int32 boxSetParentCount, Int32 boxSetContentsLength, TextBox textBox)
        {
            StringBuilder sb = new StringBuilder(boxSetParentCount.ToString());

            sb.Append((boxSetParentCount == 1) ? Texts.Parent : Texts.Parents);
            sb.Append(", ");
            sb.Append(boxSetContentsLength.ToString());
            sb.Append((boxSetContentsLength == 1) ? Texts.Child : Texts.Children);

            textBox.Text = sb.ToString();
        }

        private void FillMyLinksTextBox(Boolean leftIsNewer, DVD leftDvd, DVD rightDvd, TextBox leftTextBox, TextBox rightTextBox)
        {
            UserLink[] leftMyLinkList = leftDvd.MyLinks?.UserLinkList;
            UserLink[] rightMyLinkList = rightDvd.MyLinks?.UserLinkList;

            if (CheckListInGeneral(leftIsNewer, leftMyLinkList, rightMyLinkList, leftTextBox, rightTextBox))
            {
                String leftMyLinks = DVDProfilerSerializer<MyLinks>.ToString(leftDvd.MyLinks ?? new MyLinks());
                String rightMyLinks = DVDProfilerSerializer<MyLinks>.ToString(rightDvd.MyLinks ?? new MyLinks());

                CheckListSpecific(leftIsNewer, leftMyLinks, rightMyLinks, leftTextBox, rightTextBox);
            }
        }

        private void FillTagsTextBox(Boolean leftIsNewer, DVD leftDvd, DVD rightDvd, TextBox leftTextBox, TextBox rightTextBox)
        {
            if (CheckListInGeneral(leftIsNewer, leftDvd.TagList, rightDvd.TagList, leftTextBox, rightTextBox))
            {
                String leftTags = DVDProfilerSerializer<Tags>.ToString(new Tags() { TagList = leftDvd.TagList });

                String rightTags = DVDProfilerSerializer<Tags>.ToString(new Tags() { TagList = rightDvd.TagList });

                CheckListSpecific(leftIsNewer, leftTags, rightTags, leftTextBox, rightTextBox);
            }
        }

        private void FillEventsTextBox(Boolean leftIsNewer, DVD leftDvd, DVD rightDvd, TextBox leftTextBox, TextBox rightTextBox)
        {
            if (CheckListInGeneral(leftIsNewer, leftDvd.EventList, rightDvd.EventList, leftTextBox, rightTextBox))
            {
                String leftEvents = DVDProfilerSerializer<Events>.ToString(new Events() { EventList = leftDvd.EventList });

                String rightEvents = DVDProfilerSerializer<Events>.ToString(new Events() { EventList = rightDvd.EventList });

                CheckListSpecific(leftIsNewer, leftEvents, rightEvents, leftTextBox, rightTextBox);
            }
        }

        private static void FillCrewTextBox(Boolean leftIsNewer, Object[] leftList, Object[] rightList, TextBox leftTextBox, TextBox rightTextBox)
        {
            if (CheckListInGeneral(leftIsNewer, leftList, rightList, leftTextBox, rightTextBox))
            {
                String leftInfo = DVDProfilerSerializer<CrewInformation>.ToString(new CrewInformation() { CrewList = leftList }, CrewInformation.DefaultEncoding);

                String rightInfo = DVDProfilerSerializer<CrewInformation>.ToString(new CrewInformation() { CrewList = rightList }, CrewInformation.DefaultEncoding);

                CheckListSpecific(leftIsNewer, leftInfo, rightInfo, leftTextBox, rightTextBox);
            }
        }

        private static void FillCastTextBox(Boolean leftIsNewer, Object[] leftList, Object[] rightList, TextBox leftTextBox, TextBox rightTextBox)
        {
            if (CheckListInGeneral(leftIsNewer, leftList, rightList, leftTextBox, rightTextBox))
            {
                String leftInfo = DVDProfilerSerializer<CastInformation>.ToString(new CastInformation() { CastList = leftList }, CastInformation.DefaultEncoding);

                String rightInfo = DVDProfilerSerializer<CastInformation>.ToString(new CastInformation() { CastList = rightList }, CastInformation.DefaultEncoding);

                CheckListSpecific(leftIsNewer, leftInfo, rightInfo, leftTextBox, rightTextBox);
            }
        }

        private static void CheckListSpecific(Boolean leftIsNewer, String leftInfo, String rightInfo, TextBox leftTextBox, TextBox rightTextBox)
        {
            if (leftInfo != rightInfo)
            {
                leftTextBox.Text += leftIsNewer ? Texts.ButDifferent : Texts.ButDifferent;
                ColourizeTextBox(leftIsNewer, leftTextBox, rightTextBox);
            }
        }

        private static Boolean CheckListInGeneral(Boolean leftIsNewer, Object[] leftList, Object[] rightList, TextBox leftTextBox, TextBox rightTextBox)
        {
            Int32 leftLength = leftList?.Length ?? 0;
            Int32 rightLength = rightList?.Length ?? 0;

            WriteEntry(rightLength, rightTextBox);

            if (leftLength != rightLength)
            {
                ColourizeTextBox(leftIsNewer, leftTextBox, rightTextBox);

                return (false);
            }

            return (true);
        }

        private static void WriteEntry(Int32 length, TextBox textBox)
        {
            textBox.Text = length.ToString() + ((length != 1) ? Texts.Entries : Texts.Entry);
        }

        private static void ColourizeTextBox(Boolean leftIsNewer, TextBox leftTextBox, TextBox rightTextBox)
        {
            if (leftTextBox.Text != rightTextBox.Text)
            {
                if (leftIsNewer)
                {
                    leftTextBox.BackColor = Color.LightGreen;
                    rightTextBox.BackColor = Color.Salmon;
                }
                else
                {
                    rightTextBox.BackColor = Color.LightGreen;
                    leftTextBox.BackColor = Color.Salmon;
                }
            }
        }

        private static void ColourizePicker(Boolean leftIsNewer, BCDateTimePicker leftPicker, BCDateTimePicker rightPicker)
        {
            if (leftPicker.Value != rightPicker.Value)
            {
                if (leftPicker.Value > rightPicker.Value)
                {
                    leftPicker.BackDisabledColor = Color.LightGreen;
                    rightPicker.BackDisabledColor = Color.Salmon;
                }
                else
                {
                    rightPicker.BackDisabledColor = Color.LightGreen;
                    leftPicker.BackDisabledColor = Color.Salmon;
                }
            }
        }

        private void OnWinMergeButtonClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                _LeftDvd.Serialize(leftFile);

                String rightFile = Path.GetTempFileName();

                _RightDvd.Serialize(rightFile);

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }

        private static void StartWinMerge(String fullPath, String leftFile, String rightFile)
        {
            StringBuilder parameters = new StringBuilder("/e /u /wl /wr ");
            parameters.Append("\"");
            parameters.Append(leftFile);
            parameters.Append("\" \"");
            parameters.Append(rightFile);
            parameters.Append("\"");

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo(fullPath, parameters.ToString())
            };

            process.Start();
        }

        private Boolean CheckWinMergeExistence(out String fullPath)
        {
            fullPath = Environment.ExpandEnvironmentVariables(Program.Settings.DefaultValues.WinMergePath);

            if (File.Exists(fullPath) == false)
            {
                MessageBox.Show(this, MessageBoxTexts.WinMergeMissingError, MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return (false);
            }

            return (true);
        }

        private void OnDetailsFormShown(Object sender, EventArgs e)
        {
            WinMergeButton.Focus();
        }

        private void OnCloseButtonClick(Object sender, EventArgs e)
        {
            Close();
        }

        private void OnCrewMembersClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                DVDProfilerSerializer<CrewInformation>.Serialize(leftFile, new CrewInformation { Title = _LeftDvd.Title, CrewList = _LeftDvd.CrewList }, CrewInformation.DefaultEncoding);

                String rightFile = Path.GetTempFileName();

                DVDProfilerSerializer<CrewInformation>.Serialize(rightFile, new CrewInformation { Title = _RightDvd.Title, CrewList = _RightDvd.CrewList }, CrewInformation.DefaultEncoding);

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }

        private void OnEventsClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                DVDProfilerSerializer<Events>.Serialize(leftFile, new Events() { EventList = _LeftDvd.EventList });

                String rightFile = Path.GetTempFileName();

                DVDProfilerSerializer<Events>.Serialize(leftFile, new Events() { EventList = _RightDvd.EventList });

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }

        private void OnCastMembersClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                DVDProfilerSerializer<CastInformation>.Serialize(leftFile, new CastInformation { Title = _LeftDvd.Title, CastList = _LeftDvd.CastList }, CastInformation.DefaultEncoding);

                String rightFile = Path.GetTempFileName();

                DVDProfilerSerializer<CastInformation>.Serialize(rightFile, new CastInformation { Title = _RightDvd.Title, CastList = _RightDvd.CastList }, CastInformation.DefaultEncoding);

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }

        private void OnLeftTagsClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                DVDProfilerSerializer<Tags>.Serialize(leftFile, new Tags() { TagList = _LeftDvd.TagList });

                String rightFile = Path.GetTempFileName();

                DVDProfilerSerializer<Tags>.Serialize(leftFile, new Tags() { TagList = _RightDvd.TagList });

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }

        private void OnLeftMyLinksClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                DVDProfilerSerializer<MyLinks>.Serialize(leftFile, _LeftDvd.MyLinks ?? new MyLinks());

                String rightFile = Path.GetTempFileName();

                DVDProfilerSerializer<MyLinks>.Serialize(leftFile, _RightDvd.MyLinks ?? new MyLinks());

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }

        private void OnLeftBoxSetButtonClick(Object sender, EventArgs e)
        {
            if (CheckWinMergeExistence(out String fullPath))
            {
                String leftFile = Path.GetTempFileName();

                DVDProfilerSerializer<BoxSet>.Serialize(leftFile, _LeftDvd.BoxSet ?? new BoxSet());

                String rightFile = Path.GetTempFileName();

                DVDProfilerSerializer<BoxSet>.Serialize(leftFile, _RightDvd.BoxSet ?? new BoxSet());

                StartWinMerge(fullPath, leftFile, rightFile);
            }
        }
    }
}