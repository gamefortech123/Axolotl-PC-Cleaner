using System;
using System.DirectoryServices.AccountManagement;

namespace AXOLOTL_PC_CLEANER.Helper
{
    internal class Locations
    {
        public static string username = Environment.UserName;

        public static string Recent_Documents = @"C:\Users\" + username + @"\AppData\Roaming\Microsoft\Windows\Recent";
        public static string Thumnail_Cache = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Windows\Explorer";
        public static string Mini_Dumps = @"C:\Windows\Minidump";

        #region Windows Log Files
        public static string WinLogs = @"C:\Windows";
        public static string WinLogs1 = @"C:\Windows\Logs";
        public static string WinLogs2 = WinLogs1 + @"\CBS";
        public static string WinLogs3 = WinLogs1 + @"\DISM";
        public static string WinLogs4 = WinLogs1 + @"\NetSetup";
        public static string WinLogs5 = WinLogs1 + @"\SIH";
        public static string WinLogs6 = WinLogs1 + @"\SystemRestore";
        public static string WinLogs7 = WinLogs1 + @"\waasmedic";
        public static string WinLogs8 = WinLogs1 + @"\waasmediccapsule";
        public static string WinLogs9 = WinLogs1 + @"\WindowsBackup";
        public static string WinLogs10 = WinLogs1 + @"\WindowsUpdate";
        public static string WinLogs11 = WinLogs1 + @"\WinREAgent";
        public static string WinLogs12 = @"C:\Windows\ServiceProfiles\NetworkService\AppData\Local\Temp";
        public static string WinLogs13 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Windows\WebCache";
        public static string WinLogs14 = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319";
        public static string WinLogs15 = @"C:\Windows\Microsoft.NET\Framework\v3.5";
        public static string WinLogs16 = @"C:\Windows\Microsoft.NET\Framework\v3.0";
        public static string WinLogs17 = @"C:\Windows\Microsoft.NET\Framework\v2.0.50727";
        public static string WinLogs18 = @"C:\Windows\Microsoft.NET\Framework\v1.1.4322";
        public static string WinLogs19 = @"C:\Windows\Microsoft.NET\Framework\v1.0.3705";
        public static string WinLogs20 = @"C:\Windows\Panther\UnattendGC";
        public static string WinLogs21 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v2.0";
        public static string WinLogs22 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v2.0_32";
        public static string WinLogs23 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v4.0";
        public static string WinLogs24 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v4.0_32";
        public static string WinLogs25 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v2.0\UsageLogs";
        public static string WinLogs26 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v2.0_32\UsageLogs";
        public static string WinLogs27 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v4.0\UsageLogs";
        public static string WinLogs28 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\CLR_v4.0_32\UsageLogs";
        public static string WinLogs29 = @"C:\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0";
        public static string WinLogs30 = @"C:\Windows\System32\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0\UsageLogs";
        public static string WinLogs31 = @"C:\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32";
        public static string WinLogs32 = @"C:\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32\UsageLogs";
        public static string WinLogs33 = @"C:\Windows\SoftwareDistribution\DataStore\Logs";
        public static string WinLogs34 = WinLogs1 + @"\DPX";
        public static string WinLogs35 = WinLogs1 + @"\HomeGroup";
        public static string WinLogs36 = WinLogs1 + @"\MeasuredBoot";
        public static string WinLogs37 = WinLogs1 + @"\MoSetup";
        public static string WinLogs38 = WinLogs1 + @"\SettingSync";
        public static string WinLogs39 = WinLogs1 + @"\SetupCleanupTask";
        public static string WinLogs40 = WinLogs1 + @"\Telephony";
        #endregion

        public static string Recyle_Bin = @"C:\$Recycle.Bin\" + Properties.Settings.Default.Sid;
        public static string Temp_Files = @"C:\Users\" + username + @"\AppData\Local\Temp";
        public static string Win_Temp_Files = @"C:\Windows\Temp";
        public static string Memory_Dumps = @"C:\Users\" + username + @"\AppData\Local\CrashDumps";
        public static string Error_Reports = @"C:\ProgramData\Microsoft\Windows\WER";
        public static string Driver_Installtion = @"C:\Windows\INF";
        public static string Delivery_Optimization = @"C:\Windows\ServiceProfiles\NetworkService\AppData\Local\Microsoft\Windows\DeliveryOptimization";
        public static string Network_Data = @"C:\Windows\System32\sru";

        public static string Prefetch = @"C:\Windows\Prefetch";
        public static string Store_Install_Service = @"C:\Windows\System32\config\systemprofile\AppData\Local\Microsoft\InstallService";
        public static string QtFramework = @"C:\Users\" + username + @"\AppData\Local\cache";
        public static string Power_Efficiency = @"C:\ProgramData\Microsoft\Windows\Power Efficiency Diagnostics";
        public static string Notifications = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Windows\ActionCenterCache";
        public static string MS_Search = @"C:\ProgramData\Microsoft\Search\Data\Applications\Windows";
        public static string MS_Search2 = @"C:\ProgramData\Microsoft\Search\Data\Applications\Windows\GatherLogs\SystemIndex";
        public static string MS_Search3 = @"C:\Users\" + username + @"\Searches";
        public static string MS_Search4 = @"C:\Users\" + username + @"\Searches\Everywhere";//.search-ms";
        public static string MS_Search5 = @"C:\Users\" + username + @"\Searches\Indexed Locations";//.search-ms";
        public static string Jump_List = @"C:\Users\" + username + @"\AppData\Roaming\Microsoft\Windows\Recent\AutomaticDestinations";
        public static string Font_Cache = @"C:\Windows\ServiceProfiles\LocalService\AppData\Local\FontCache";

        public static string Win_Defender = @"C:\ProgramData\Microsoft\Windows Defender\Scans\History\CacheManager";
        public static string Win_Defender2 = @"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Service";
        public static string Win_Defender3 = @"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Service\DetectionHistory";
        public static string Win_Defender4 = @"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Store";
        public static string Win_Defender5 = @"C:\ProgramData\Microsoft\Windows Defender\Scans\RtSigs\Data";
        public static string Win_Defender6 = @"C:\ProgramData\Microsoft\Windows Defender\Support";
        public static string Win_Defender7 = @"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Results";
        public static string Origin_Installers = @"C:\Users\" + username + @"\AppData\Local\Origin\ThinSetup";
        public static string Visual_Studio = @"C:\ProgramData\Microsoft\VisualStudio\Packages";
        public static string One_Drive = @"C:\Users\" + username + @"\AppData\Local\Microsoft\OneDrive\logs";
        public static string One_Drive2 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\OneDrive\setup";
        public static string One_Drive3 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\OneDrive\setup\logs";
        public static string Easy_AntiCheat = @"C:\Users\" + username + @"\AppData\Roaming\EasyAntiCheat";
        public static string Battlenet = @"C:\ProgramData\Blizzard Entertainment\Battle.net\Cache";
        public static string Battlenet2 = @"C:\Users\" + username + @"\AppData\Local\Battle.net\BrowserCache";
        public static string Battlenet3 = @"C:\Users\" + username + @"\AppData\Local\Battle.net\BrowserCache\Cache";
        public static string Battlenet4 = @"C:\Users\" + username + @"\AppData\Local\Battle.net\BrowserCache\GPUCache";
        public static string Battlenet5 = @"C:\Users\" + username + @"\AppData\Local\Battle.net\BrowserCache\Code Cache\js";
        public static string Ccleaner = @"C:\Program Files\CCleaner\LOG";
        public static string Steam = @"C:\Program Files (x86)\Steam";
        public static string Steam2 = @"C:\Program Files (x86)\Steam\dumps";
        public static string Steam3 = @"C:\Program Files (x86)\Steam\steamapps\temp";

        public static string DirectX = @"C:\Windows\System32\config\systemprofile\AppData\Local\D3DSCache";
        public static string DirectX2 = @"C:\Users\" + username + @"\AppData\Local\D3DSCache";
        public static string Windows_Update = @"C:\Windows\SoftwareDistribution\Download";
        public static string Windows_Font_Cache = @"C:\Windows\System32\FNTCACHE.DAT";
        public static string Windows_Debug = @"C:\Windows\debug";
        public static string Windows_Cache = @"C:\Users\" + username + @"\AppData\LocalLow\Microsoft\CryptnetUrlCache\Content";
        public static string Windows_Cache2 = @"C:\Users\" + username + @"\AppData\LocalLow\Microsoft\CryptnetUrlCache\MetaData";
        public static string Windows_Cache3 = @"C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow\Microsoft\CryptnetUrlCache\Content";
        public static string Windows_Cache4 = @"C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow\Microsoft\CryptnetUrlCache\MetaData";
        public static string Windows_Cache5 = @"C:\Windows\System32\config\systemprofile\AppData\Local\Microsoft\Windows\Caches";
        public static string Windows_Installer = @"C:\Windows\Installer";
        public static string Windows_Experience = @"C:\Windows\Performance\WinSAT";
        public static string Windows_Experience2 = @"C:\Windows\Performance\WinSAT\DataStore";
        public static string Windows_Auto_Video_Experience = @"C:\Windows\ServiceProfiles\LocalService\AppData\Local\Microsoft\Windows";
        public static string Windows_Internet_Cache = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Windows\INetCache\IE";

        #region Edge Chromium
        public static string Edge_Master = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\";

        public static string Edge_Cache = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cache\Cache_Data"; // < all files
        public static string Edge_Cache2 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\GPUCache"; //  < all files
        public static string Edge_Cache3 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Code Cache\js"; //  < all files
        public static string Edge_Cache4 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Code Cache\js\index-dir"; //  < all files
        public static string Edge_Cache5 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\CacheStorage"; //  < files and folders
        public static string Edge_Cache6 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\Database"; //  < all files
        public static string Edge_Cache7 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\ScriptCache"; //  < all files
        public static string Edge_Cache8 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\ScriptCache\index-dir"; //  < all files
        public static string Edge_Cache9 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\GrShaderCache\GPUCache"; //  < all files
        public static string Edge_Cache10 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\ShaderCache\GPUCache"; //  < all files

        public static string Edge_Cache11 = Edge_Master + "Favicons-journal";
        public static string Edge_Cache12 = Edge_Master + "History-journal";
        public static string Edge_Cache13 = Edge_Master + "Login Data-journal";
        public static string Edge_Cache14 = Edge_Master + "Network Action Predictor-journal";
        public static string Edge_Cache15 = Edge_Master + "Shortcuts-journal";
        public static string Edge_Cache16 = Edge_Master + "Top Sites-journal";
        public static string Edge_Cache17 = Edge_Master + "Web Data-journal";
        public static string Edge_Cache18 = Edge_Master + "WebAssistDatabase-journal";
        public static string Edge_Cache19 = Edge_Master + @"Network\Cookies-journal";
        public static string Edge_Cache20 = Edge_Master + @"Network\Reporting and NEL-journal";
        public static string Edge_Cache21 = Edge_Master + @"WebStorage\QuotaManager-journal";

        public static string Edge_Cookies = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\IndexedDB"; // < all files and folders
        public static string Edge_Cookies1 = Edge_Master + @"Network\Cookies";

        public static string Edge_History = Edge_Master + "Favicons";
        public static string Edge_History2 = Edge_Master + "History";
        public static string Edge_History3 = Edge_Master + "Network Action Predictor";
        public static string Edge_History4 = Edge_Master + "Shortcuts";
        public static string Edge_History5 = Edge_Master + "Top Sites";
        public static string Edge_History6 = Edge_Master + "Visited Links";
        public static string Edge_History7 = Edge_Master + "Web Data";
        public static string Edge_History8 = Edge_Master + "WebAssistDatabase";
        public static string Edge_History9 = Edge_Master + @"Network\Network Persistent State";
        public static string Edge_History10 = Edge_Master + @"Network\NetworkDataMigrated";
        public static string Edge_History11 = Edge_Master + @"Network\Reporting and NEL";
        public static string Edge_History12 = Edge_Master + @"Network\Token Bindings";
        public static string Edge_History13 = Edge_Master + @"Network\TransportSecurity";
        public static string Edge_History14 = Edge_Master + @"WebStorage\QuotaManager";

        public static string Edge_Session = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Session Storage"; // < all files
        public static string Edge_Session2 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Extension State"; // < all files
        public static string Edge_Session3 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\Default\Sessions"; // < all files

        public static string Edge_Passwords = Edge_Master + "Login Data";

        public static string Edge_Metrics = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data"; // < pma files
        public static string Edge_Metrics2 = @"C:\Users\" + username + @"\AppData\Local\Microsoft\Edge\User Data\BrowserMetrics"; // < pma files
        #endregion

        #region Google Chrome
        public static string Chrome_Master = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\";

        public static string Chrome_Cache = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Cache\Cache_Data";
        public static string Chrome_Cache2 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Cache\Cache_Data";
        public static string Chrome_Cache3 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\GPUCache";
        public static string Chrome_Cache4 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Code Cache\js";
        public static string Chrome_Cache5 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Code Cache\js\index-dir";
        public static string Chrome_Cache6 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\File System\001\t\Paths";
        public static string Chrome_Cache7 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\File System\Origins";
        public static string Chrome_Cache8 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Service Worker\CacheStorage"; //< files and folders
        public static string Chrome_Cache9 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\GrShaderCache\GPUCache";
        public static string Chrome_Cache10 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\ShaderCache\GPUCache";
        public static string Chrome_Cache11 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\JumpListIconsRecentClosed";
        public static string Chrome_Cache12 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Safe Browsing Network";

        public static string Chrome_Cache13 = Chrome_Master + "History-journal";
        public static string Chrome_Cache14 = Chrome_Master + "Login Data-journal";
        public static string Chrome_Cache15 = Chrome_Master + "Network Action Predictor-journal";
        public static string Chrome_Cache16 = Chrome_Master + "Shortcuts-journal";
        public static string Chrome_Cache17 = Chrome_Master + "Top Sites-journal";
        public static string Chrome_Cache18 = Chrome_Master + "Web Data-journal";
        public static string Chrome_Cache19 = Chrome_Master + "Visited Links-journal";
        public static string Chrome_Cache20 = Chrome_Master + @"\Network\Cookies-journal";
        public static string Chrome_Cache21 = Chrome_Master + @"\Network\Reporting and NEL-journal";
        public static string Chrome_Cache22 = Chrome_Master + "Favicons-journal";

        public static string Chrome_History = Chrome_Master + "Visited Links";
        public static string Chrome_History2 = Chrome_Master + "History";
        public static string Chrome_History3 = Chrome_Master + "Network Action Predictor";
        public static string Chrome_History4 = Chrome_Master + "Shortcuts";
        public static string Chrome_History5 = Chrome_Master + "Top Sites";
        public static string Chrome_History6 = Chrome_Master + "Trusted Vault";
        public static string Chrome_History7 = Chrome_Master + "Visited Links";
        public static string Chrome_History8 = Chrome_Master + "Web Data";
        public static string Chrome_History9 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\JumpListIconsRecentClosed";

        public static string Chrome_Cookies = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\IndexedDB";
        public static string Chrome_Cookies2 = Chrome_Master + @"\Network\Cookies";

        public static string Chrome_Download = Chrome_Master + "DownloadMetadata";

        public static string Chrome_Metrics = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\BrowserMetrics"; //pma files

        public static string Chrome_Session = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Session Storage";
        public static string Chrome_Session2 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Extension State";
        public static string Chrome_Session3 = @"C:\Users\" + username + @"\AppData\Local\Google\Chrome\User Data\Default\Sessions";

        public static string Chrome_Passwords = Chrome_Master + "Login Data";
        #endregion

        #region Firefox
        public static string Firefox_Cache = @"C:\Users\" + username + @"\AppData\Local\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\cache2";
        public static string Firefox_Cache2 = @"C:\Users\" + username + @"\AppData\Local\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\cache2\doomed";
        public static string Firefox_Cache3 = @"C:\Users\" + username + @"\AppData\Local\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\cache2\entries";
        public static string Firefox_Cache4 = @"C:\Users\" + username + @"\AppData\Local\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\jumpListCache";
        public static string Firefox_Cache5 = @"C:\Users\" + username + @"\AppData\Local\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\startupCache";

        public static string Firefox_History = @"C:\Users\" + username + @"\AppData\Local\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\thumbnails";

        public static string Firefox_Cookies = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\storage\default";

        public static string Firefox_Session = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\sessionstore-backups";
        public static string Firefox_Session2 = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\sessionCheckpoints.json";

        public static string Firefox_Site_Pref = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\SiteSecurityServiceState.txt";

        public static string Firefox_Saved_Form = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\formhistory.sqlite";

        public static string Firefox_Login = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\logins.json";
        public static string Firefox_Login2 = @"C:\Users\" + username + @"\AppData\Roaming\Mozilla\Firefox\Profiles\" + Properties.Settings.Default.FirefoxPath + @"\logins-backup.json";
        #endregion
    }
}
