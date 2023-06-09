; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "DJ_application"
#define MyAppVersion "1"
#define MyAppExeName "Dj_application.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{350561E3-FF9F-4CEA-B09B-922BC6FA697D}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={userdocs}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\Maxen\Downloads\setup_Dj_application
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Maxen\Downloads\DJ_application\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Dj_application.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Dj_application.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Dj_application.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Dj_application.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\libmp3lame.32.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\libmp3lame.64.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Microsoft.Web.WebView2.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Microsoft.Web.WebView2.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Microsoft.Web.WebView2.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.Asio.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.Lame.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.Midi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.Wasapi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\NAudio.WinMM.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\OxyPlot.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\OxyPlot.WindowsForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\RestSharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\System.Data.SqlClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Utf8Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Maxen\Downloads\DJ_application\Dj_application.exe.WebView2\*"; DestDir: "{app}\Dj_application.exe.WebView2"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\Maxen\Downloads\DJ_application\lib\*"; DestDir: "{app}\lib"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\Maxen\Downloads\DJ_application\runtimes\*"; DestDir: "{app}\runtimes"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

