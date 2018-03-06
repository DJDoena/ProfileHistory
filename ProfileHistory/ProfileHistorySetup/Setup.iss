[Setup]
AppName=DVD Profiler Profile History
AppId=ProfileHistory
AppVerName=DVD Profiler Profile History 1.0.0.0
AppCopyright=Copyright � Doena Soft. 2018
AppPublisher=Doena Soft.
AppPublisherURL=http://doena-journal.net/en/dvd-profiler-tools/
DefaultDirName={pf32}\Doena Soft.\ProfileHistory
DefaultGroupName=DVD Profiler Profile History
DirExistsWarning=No
SourceDir=..\ProfileHistory\bin\x64\ProfileHistory
Compression=zip/9
AppMutex=InvelosDVDPro
OutputBaseFilename=ProfileHistorySetup
OutputDir=..\..\..\..\ProfileHistorySetup\Setup\ProfileHistory
MinVersion=0,5.1
PrivilegesRequired=admin
WizardImageFile=compiler:wizmodernimage-is.bmp
WizardSmallImageFile=compiler:wizmodernsmallimage-is.bmp
DisableReadyPage=yes
ShowLanguageDialog=no
VersionInfoCompany=Doena Soft.
VersionInfoCopyright=2018
VersionInfoDescription=DVD Profiler Profile History Setup
VersionInfoVersion=1.0.0.0
UninstallDisplayIcon={app}\djdsoft.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Messages]
WinVersionTooLowError=This program requires Windows XP or above to be installed.%n%nWindows 9x, NT and 2000 are not supported.

[Types]
Name: "full"; Description: "Full installation"

[Files]
Source: "djdsoft.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "DVDProfilerHelper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DVDProfilerHelper.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "DVDProfilerXML.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DVDProfilerXML.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "ProfileHistory.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "ProfileHistory.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "de\DVDProfilerHelper.resources.dll"; DestDir: "{app}\de"; Flags: ignoreversion
Source: "de\ProfileHistory.resources.dll"; DestDir: "{app}\de"; Flags: ignoreversion

;Source: "ReadMe\readme.html"; DestDir: "{app}\ReadMe"; Flags: ignoreversion

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\DVD Profiler Profile History"; Filename: "{app}\ProfileHistory.exe"; WorkingDir: "{app}"; IconFilename: "{app}\djdsoft.ico"
Name: "{userdesktop}\DVD Profiler Profile History"; Filename: "{app}\ProfileHistory.exe"; WorkingDir: "{app}"; IconFilename: "{app}\djdsoft.ico"

;[Run]

;[UninstallDelete]

;[UninstallRun]

;[Registry]

[Code]
function IsDotNET40Detected(): boolean;
// Function to detect dotNet framework version 4.0
// Returns true if it is available, false it's not.
var
dotNetStatus: boolean;
begin
dotNetStatus := RegKeyExists(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4');
Result := dotNetStatus;
end;

function InitializeSetup(): Boolean;
// Called at the beginning of the setup package.
begin

if not IsDotNET40Detected then
begin
MsgBox( 'The Microsoft .NET Framework version 4.0 is not installed. Please install it and try again.', mbInformation, MB_OK );
Result := false;
end
else
Result := true;
end;
