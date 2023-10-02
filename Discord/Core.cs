using System.Runtime.InteropServices;
using System.Text;
using MonoGame3D;

namespace Discord;

public enum Result
{
    Ok = 0,
    ServiceUnavailable = 1,
    InvalidVersion = 2,
    LockFailed = 3,
    InternalError = 4,
    InvalidPayload = 5,
    InvalidCommand = 6,
    InvalidPermissions = 7,
    NotFetched = 8,
    NotFound = 9,
    Conflict = 10,
    InvalidSecret = 11,
    InvalidJoinSecret = 12,
    NoEligibleActivity = 13,
    InvalidInvite = 14,
    NotAuthenticated = 15,
    InvalidAccessToken = 16,
    ApplicationMismatch = 17,
    InvalidDataUrl = 18,
    InvalidBase64 = 19,
    NotFiltered = 20,
    LobbyFull = 21,
    InvalidLobbySecret = 22,
    InvalidFilename = 23,
    InvalidFileSize = 24,
    InvalidEntitlement = 25,
    NotInstalled = 26,
    NotRunning = 27,
    InsufficientBuffer = 28,
    PurchaseCanceled = 29,
    InvalidGuild = 30,
    InvalidEvent = 31,
    InvalidChannel = 32,
    InvalidOrigin = 33,
    RateLimited = 34,
    OAuth2Error = 35,
    SelectChannelTimeout = 36,
    GetGuildTimeout = 37,
    SelectVoiceForceRequired = 38,
    CaptureShortcutAlreadyListening = 39,
    UnauthorizedForAchievement = 40,
    InvalidGiftCode = 41,
    PurchaseError = 42,
    TransactionAborted = 43,
    DrawingInitFailed = 44
}

public enum CreateFlags
{
    Default = 0,
    NoRequireDiscord = 1
}

public enum LogLevel
{
    Error = 1,
    Warn,
    Info,
    Debug
}

public enum UserFlag
{
    Partner = 2,
    HypeSquadEvents = 4,
    HypeSquadHouse1 = 64,
    HypeSquadHouse2 = 128,
    HypeSquadHouse3 = 256
}

public enum PremiumType
{
    None = 0,
    Tier1 = 1,
    Tier2 = 2
}

public enum ImageType
{
    User
}

public enum ActivityPartyPrivacy
{
    Private = 0,
    Public = 1
}

public enum ActivityType
{
    Playing,
    Streaming,
    Listening,
    Watching
}

public enum ActivityActionType
{
    Join = 1,
    Spectate
}

public enum ActivitySupportedPlatformFlags
{
    Desktop = 1,
    Android = 2,
    // ReSharper disable once InconsistentNaming
    iOS = 4
}

public enum ActivityJoinRequestReply
{
    No,
    Yes,
    Ignore
}

public enum Status
{
    Offline = 0,
    Online = 1,
    Idle = 2,
    DoNotDisturb = 3
}

public enum RelationshipType
{
    None,
    Friend,
    Blocked,
    PendingIncoming,
    PendingOutgoing,
    Implicit
}

public enum LobbyType
{
    Private = 1,
    Public
}

public enum LobbySearchComparison
{
    LessThanOrEqual = -2,
    LessThan,
    Equal,
    GreaterThan,
    GreaterThanOrEqual,
    NotEqual
}

public enum LobbySearchCast
{
    String = 1,
    Number
}

public enum LobbySearchDistance
{
    Local,
    Default,
    Extended,
    Global
}

public enum KeyVariant
{
    Normal,
    Right,
    Left
}

public enum MouseButton
{
    Left,
    Middle,
    Right
}

public enum EntitlementType
{
    Purchase = 1,
    PremiumSubscription,
    DeveloperGift,
    TestModePurchase,
    FreePurchase,
    UserGift,
    PremiumPurchase
}

public enum SkuType
{
    Application = 1,
    Dlc,
    Consumable,
    Bundle
}

public enum InputModeType
{
    VoiceActivity = 0,
    PushToTalk
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct User
{
    public Int64 Id;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string Username;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public string Discriminator;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Avatar;

    public bool Bot;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct OAuth2Token
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string AccessToken;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
    public string Scopes;

    public Int64 Expires;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public partial struct ImageHandle
{
    public ImageType Type;

    public Int64 Id;

    public UInt32 Size;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ImageDimensions
{
    public UInt32 Width;

    public UInt32 Height;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ActivityTimestamps
{
    public Int64 Start;

    public Int64 End;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ActivityAssets
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string LargeImage;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string LargeText;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string SmallImage;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string SmallText;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct PartySize
{
    public Int32 CurrentSize;

    public Int32 MaxSize;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ActivityParty
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Id;

    public PartySize Size;

    public ActivityPartyPrivacy Privacy;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ActivitySecrets
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Match;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Join;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Spectate;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Activity
{
    public ActivityType Type;

    public Int64 ApplicationId;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Name;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string State;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Details;

    public ActivityTimestamps Timestamps;

    public ActivityAssets Assets;

    public ActivityParty Party;

    public ActivitySecrets Secrets;

    public bool Instance;

    public UInt32 SupportedPlatforms;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Presence
{
    public Status Status;

    public Activity Activity;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Relationship
{
    public RelationshipType Type;

    public User User;

    public Presence Presence;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Lobby
{
    public Int64 Id;

    public LobbyType Type;

    public Int64 OwnerId;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string Secret;

    public UInt32 Capacity;

    public bool Locked;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ImeUnderline
{
    public Int32 From;

    public Int32 To;

    public UInt32 Color;

    public UInt32 BackgroundColor;

    public bool Thick;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Rect
{
    public Int32 Left;

    public Int32 Top;

    public Int32 Right;

    public Int32 Bottom;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct FileStat
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string Filename;

    public UInt64 Size;

    public UInt64 LastModified;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Entitlement
{
    public Int64 Id;

    public EntitlementType Type;

    public Int64 SkuId;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct SkuPrice
{
    public UInt32 Amount;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string Currency;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Sku
{
    public Int64 Id;

    public SkuType Type;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string Name;

    public SkuPrice Price;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct InputMode
{
    public InputModeType Type;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string Shortcut;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct UserAchievement
{
    public Int64 UserId;

    public Int64 AchievementId;

    public byte PercentComplete;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string UnlockedAt;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)] [Obsolete]
public struct LobbyTransaction
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetTypeMethod(IntPtr methodsPtr, LobbyType type);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetOwnerMethod(IntPtr methodsPtr, long ownerId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetCapacityMethod(IntPtr methodsPtr, uint capacity);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string key, [MarshalAs(UnmanagedType.LPStr)]string value);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result DeleteMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string key);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetLockedMethod(IntPtr methodsPtr, bool locked);

        internal SetTypeMethod SetType;

        internal SetOwnerMethod SetOwner;

        internal SetCapacityMethod SetCapacity;

        internal SetMetadataMethod SetMetadata;

        internal DeleteMetadataMethod DeleteMetadata;

        internal SetLockedMethod SetLocked;
    }

    internal IntPtr MethodsPtr;

    internal object? MethodsStructure;

    private FfiMethods Methods
    {
        get
        {
            MethodsStructure ??= Marshal.PtrToStructure(MethodsPtr, typeof(FfiMethods));
            return (FfiMethods)(MethodsStructure ?? throw new InvalidOperationException());
        }

    }

    public void SetType(LobbyType type)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.SetType(MethodsPtr, type);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void SetOwner(long ownerId)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.SetOwner(MethodsPtr, ownerId);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void SetCapacity(uint capacity)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.SetCapacity(MethodsPtr, capacity);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void SetMetadata(string key, string value)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.SetMetadata(MethodsPtr, key, value);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void DeleteMetadata(string key)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.DeleteMetadata(MethodsPtr, key);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void SetLocked(bool locked)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.SetLocked(MethodsPtr, locked);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct LobbyMemberTransaction
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string key, [MarshalAs(UnmanagedType.LPStr)]string value);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result DeleteMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string key);

        internal SetMetadataMethod SetMetadata;

        internal DeleteMetadataMethod DeleteMetadata;
    }

    internal IntPtr MethodsPtr;

    internal object? MethodsStructure;

    private FfiMethods Methods
    {
        get
        {
            MethodsStructure ??= Marshal.PtrToStructure(MethodsPtr, typeof(FfiMethods));
            return (FfiMethods)(MethodsStructure ?? throw new InvalidOperationException());
        }

    }

    public void SetMetadata(string key, string value)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.SetMetadata(MethodsPtr, key, value);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void DeleteMetadata(string key)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.DeleteMetadata(MethodsPtr, key);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct LobbySearchQuery
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result FilterMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string key, LobbySearchComparison comparison, LobbySearchCast cast, [MarshalAs(UnmanagedType.LPStr)]string value);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SortMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string key, LobbySearchCast cast, [MarshalAs(UnmanagedType.LPStr)]string value);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result LimitMethod(IntPtr methodsPtr, uint limit);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result DistanceMethod(IntPtr methodsPtr, LobbySearchDistance distance);

        internal FilterMethod Filter;

        internal SortMethod Sort;

        internal LimitMethod Limit;

        internal DistanceMethod Distance;
    }

    internal IntPtr MethodsPtr;

    internal object? MethodsStructure;

    private FfiMethods Methods
    {
        get
        {
            MethodsStructure ??= Marshal.PtrToStructure(MethodsPtr, typeof(FfiMethods));
            return (FfiMethods)(MethodsStructure ?? throw new InvalidOperationException());
        }

    }

    public void Filter(string key, LobbySearchComparison comparison, LobbySearchCast cast, string value)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.Filter(MethodsPtr, key, comparison, cast, value);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void Sort(string key, LobbySearchCast cast, string value)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.Sort(MethodsPtr, key, cast, value);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void Limit(uint limit)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.Limit(MethodsPtr, limit);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }

    public void Distance(LobbySearchDistance distance)
    {
        if (MethodsPtr != IntPtr.Zero)
        {
            var res = Methods.Distance(MethodsPtr, distance);
            if (res != Result.Ok)
            {
                Debug.LogError(new ResultException(res));
            }
        }
    }
}

public class ResultException : Exception
{
    public readonly Result Result;

    public ResultException(Result result) : base(result.ToString())
    {
        Result = result;
    }
}

public class Discord : IDisposable
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DestroyHandler(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result RunCallbacksMethod(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetLogHookCallback(IntPtr ptr, LogLevel level, [MarshalAs(UnmanagedType.LPStr)]string message);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetLogHookMethod(IntPtr methodsPtr, LogLevel minLevel, IntPtr callbackData, SetLogHookCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetApplicationManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetUserManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetImageManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetActivityManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetRelationshipManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetLobbyManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetNetworkManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetOverlayManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetStorageManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetStoreManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetVoiceManagerMethod(IntPtr discordPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate IntPtr GetAchievementManagerMethod(IntPtr discordPtr);

        internal DestroyHandler Destroy;

        internal RunCallbacksMethod RunCallbacks;

        internal SetLogHookMethod SetLogHook;

        internal GetApplicationManagerMethod GetApplicationManager;

        internal GetUserManagerMethod GetUserManager;

        internal GetImageManagerMethod GetImageManager;

        internal GetActivityManagerMethod GetActivityManager;

        internal GetRelationshipManagerMethod GetRelationshipManager;

        internal GetLobbyManagerMethod GetLobbyManager;

        internal GetNetworkManagerMethod GetNetworkManager;

        internal GetOverlayManagerMethod GetOverlayManager;

        internal GetStorageManagerMethod GetStorageManager;

        internal GetStoreManagerMethod GetStoreManager;

        internal GetVoiceManagerMethod GetVoiceManager;

        internal GetAchievementManagerMethod GetAchievementManager;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiCreateParams
    {
        internal Int64 ClientId;

        internal UInt64 Flags;

        internal IntPtr Events;

        internal IntPtr EventData;

        internal IntPtr ApplicationEvents;

        internal UInt32 ApplicationVersion;

        internal IntPtr UserEvents;

        internal UInt32 UserVersion;

        internal IntPtr ImageEvents;

        internal UInt32 ImageVersion;

        internal IntPtr ActivityEvents;

        internal UInt32 ActivityVersion;

        internal IntPtr RelationshipEvents;

        internal UInt32 RelationshipVersion;

        internal IntPtr LobbyEvents;

        internal UInt32 LobbyVersion;

        internal IntPtr NetworkEvents;

        internal UInt32 NetworkVersion;

        internal IntPtr OverlayEvents;

        internal UInt32 OverlayVersion;

        internal IntPtr StorageEvents;

        internal UInt32 StorageVersion;

        internal IntPtr StoreEvents;

        internal UInt32 StoreVersion;

        internal IntPtr VoiceEvents;

        internal UInt32 VoiceVersion;

        internal IntPtr AchievementEvents;

        internal UInt32 AchievementVersion;
    }

    [DllImport(Constants.DllName, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    private static extern Result DiscordCreate(uint version, ref FfiCreateParams createParams, out IntPtr manager);

    public delegate void SetLogHookHandler(LogLevel level, string message);

    private GCHandle _selfHandle;

    private readonly IntPtr _eventsPtr;

    private readonly IntPtr _applicationEventsPtr;

    [Obsolete]
    private ApplicationManager.FfiEvents _applicationEvents;

    [Obsolete]
    internal ApplicationManager? ApplicationManagerInstance;

    private readonly IntPtr _userEventsPtr;

    private UserManager.FfiEvents _userEvents;

    internal UserManager? UserManagerInstance;

    private readonly IntPtr _imageEventsPtr;

    [Obsolete]
    private ImageManager.FfiEvents _imageEvents;

    [Obsolete]
    internal ImageManager? ImageManagerInstance;

    private readonly IntPtr _activityEventsPtr;

    private ActivityManager.FfiEvents _activityEvents;

    internal ActivityManager? ActivityManagerInstance;

    private readonly IntPtr _relationshipEventsPtr;

    private RelationshipManager.FfiEvents _relationshipEvents;

    internal RelationshipManager? RelationshipManagerInstance;

    private readonly IntPtr _lobbyEventsPtr;

    [Obsolete]
    private LobbyManager.FfiEvents _lobbyEvents;

    [Obsolete]
    internal LobbyManager? LobbyManagerInstance;

    private readonly IntPtr _networkEventsPtr;

    [Obsolete]
    private NetworkManager.FfiEvents _networkEvents;

    [Obsolete]
    internal NetworkManager? NetworkManagerInstance;

    private readonly IntPtr _overlayEventsPtr;

    private OverlayManager.FfiEvents _overlayEvents;

    internal OverlayManager? OverlayManagerInstance;

    private readonly IntPtr _storageEventsPtr;

    [Obsolete]
    private StorageManager.FfiEvents _storageEvents;

    [Obsolete]
    internal StorageManager? StorageManagerInstance;

    private readonly IntPtr _storeEventsPtr;

    [Obsolete]
    private StoreManager.FfiEvents _storeEvents;

    [Obsolete]
    internal StoreManager? StoreManagerInstance;

    private readonly IntPtr _voiceEventsPtr;

    private VoiceManager.FfiEvents _voiceEvents;

    internal VoiceManager? VoiceManagerInstance;

    private readonly IntPtr _achievementEventsPtr;

    [Obsolete]
    private AchievementManager.FfiEvents _achievementEvents;

    [Obsolete]
    internal AchievementManager? AchievementManagerInstance;

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    private GCHandle? _setLogHook;

#pragma warning disable CS0612 // Type or member is obsolete
    public Discord(long clientId, ulong flags)
    {
        FfiCreateParams createParams;
        createParams.ClientId = clientId;
        createParams.Flags = flags;
        var events = new FfiEvents();
        _eventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(events));
        createParams.Events = _eventsPtr;
        _selfHandle = GCHandle.Alloc(this);
        createParams.EventData = GCHandle.ToIntPtr(_selfHandle);
        _applicationEvents = new ApplicationManager.FfiEvents();
        _applicationEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_applicationEvents));
        createParams.ApplicationEvents = _applicationEventsPtr;
        createParams.ApplicationVersion = 1;
        _userEvents = new UserManager.FfiEvents();
        _userEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_userEvents));
        createParams.UserEvents = _userEventsPtr;
        createParams.UserVersion = 1;
        _imageEvents = new ImageManager.FfiEvents();
        _imageEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_imageEvents));
        createParams.ImageEvents = _imageEventsPtr;
        createParams.ImageVersion = 1;
        _activityEvents = new ActivityManager.FfiEvents();
        _activityEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_activityEvents));
        createParams.ActivityEvents = _activityEventsPtr;
        createParams.ActivityVersion = 1;
        _relationshipEvents = new RelationshipManager.FfiEvents();
        _relationshipEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_relationshipEvents));
        createParams.RelationshipEvents = _relationshipEventsPtr;
        createParams.RelationshipVersion = 1;
        _lobbyEvents = new LobbyManager.FfiEvents();
        _lobbyEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_lobbyEvents));
        createParams.LobbyEvents = _lobbyEventsPtr;
        createParams.LobbyVersion = 1;
        _networkEvents = new NetworkManager.FfiEvents();
        _networkEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_networkEvents));
        createParams.NetworkEvents = _networkEventsPtr;
        createParams.NetworkVersion = 1;
        _overlayEvents = new OverlayManager.FfiEvents();
        _overlayEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_overlayEvents));
        createParams.OverlayEvents = _overlayEventsPtr;
        createParams.OverlayVersion = 2;
        _storageEvents = new StorageManager.FfiEvents();
        _storageEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_storageEvents));
        createParams.StorageEvents = _storageEventsPtr;
        createParams.StorageVersion = 1;
        _storeEvents = new StoreManager.FfiEvents();
        _storeEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_storeEvents));
        createParams.StoreEvents = _storeEventsPtr;
        createParams.StoreVersion = 1;
        _voiceEvents = new VoiceManager.FfiEvents();
        _voiceEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_voiceEvents));
        createParams.VoiceEvents = _voiceEventsPtr;
        createParams.VoiceVersion = 1;
        _achievementEvents = new AchievementManager.FfiEvents();
        _achievementEventsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_achievementEvents));
        createParams.AchievementEvents = _achievementEventsPtr;
        createParams.AchievementVersion = 1;
        InitEvents(_eventsPtr, ref events);
        var result = DiscordCreate(3, ref createParams, out _methodsPtr);
        if (result != Result.Ok)
        {
            Dispose();
            throw new ResultException(result);
        }
    }
#pragma warning restore CS0612 // Type or member is obsolete

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public void Dispose()
    {
        if (_methodsPtr != IntPtr.Zero)
        {
            Methods.Destroy(_methodsPtr);
        }
        _selfHandle.Free();
        Marshal.FreeHGlobal(_eventsPtr);
        Marshal.FreeHGlobal(_applicationEventsPtr);
        Marshal.FreeHGlobal(_userEventsPtr);
        Marshal.FreeHGlobal(_imageEventsPtr);
        Marshal.FreeHGlobal(_activityEventsPtr);
        Marshal.FreeHGlobal(_relationshipEventsPtr);
        Marshal.FreeHGlobal(_lobbyEventsPtr);
        Marshal.FreeHGlobal(_networkEventsPtr);
        Marshal.FreeHGlobal(_overlayEventsPtr);
        Marshal.FreeHGlobal(_storageEventsPtr);
        Marshal.FreeHGlobal(_storeEventsPtr);
        Marshal.FreeHGlobal(_voiceEventsPtr);
        Marshal.FreeHGlobal(_achievementEventsPtr);
        _setLogHook?.Free();
    }

    public void RunCallbacks()
    {
        var res = Methods.RunCallbacks(_methodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    [MonoPInvokeCallback]
    private static void SetLogHookCallbackImpl(IntPtr ptr, LogLevel level, string message)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SetLogHookHandler;
        callback?.Invoke(level, message);
    }

    public void SetLogHook(LogLevel minLevel, SetLogHookHandler callback)
    {
        _setLogHook?.Free();
        _setLogHook = GCHandle.Alloc(callback);
        Methods.SetLogHook(_methodsPtr, minLevel, GCHandle.ToIntPtr(_setLogHook.Value), SetLogHookCallbackImpl);
    }

    [Obsolete]
    public ApplicationManager GetApplicationManager()
    {
        return ApplicationManagerInstance ??= new ApplicationManager(
            Methods.GetApplicationManager(_methodsPtr),
            _applicationEventsPtr,
            ref _applicationEvents
        );
    }

    public UserManager GetUserManager()
    {
        return UserManagerInstance ??= new UserManager(
            Methods.GetUserManager(_methodsPtr),
            _userEventsPtr,
            ref _userEvents
        );
    }

    [Obsolete]
    public ImageManager GetImageManager()
    {
        return ImageManagerInstance ??= new ImageManager(
            Methods.GetImageManager(_methodsPtr),
            _imageEventsPtr,
            ref _imageEvents
        );
    }

    public ActivityManager GetActivityManager()
    {
        return ActivityManagerInstance ??= new ActivityManager(
            Methods.GetActivityManager(_methodsPtr),
            _activityEventsPtr,
            ref _activityEvents
        );
    }

    public RelationshipManager GetRelationshipManager()
    {
        return RelationshipManagerInstance ??= new RelationshipManager(
            Methods.GetRelationshipManager(_methodsPtr),
            _relationshipEventsPtr,
            ref _relationshipEvents
        );
    }

    [Obsolete]
    public LobbyManager GetLobbyManager()
    {
        return LobbyManagerInstance ??= new LobbyManager(
            Methods.GetLobbyManager(_methodsPtr),
            _lobbyEventsPtr,
            ref _lobbyEvents
        );
    }

    [Obsolete]
    public NetworkManager GetNetworkManager()
    {
        return NetworkManagerInstance ??= new NetworkManager(
            Methods.GetNetworkManager(_methodsPtr),
            _networkEventsPtr,
            ref _networkEvents
        );
    }

    public OverlayManager GetOverlayManager()
    {
        return OverlayManagerInstance ??= new OverlayManager(
            Methods.GetOverlayManager(_methodsPtr),
            _overlayEventsPtr,
            ref _overlayEvents
        );
    }

    [Obsolete]
    public StorageManager GetStorageManager()
    {
        return StorageManagerInstance ??= new StorageManager(
            Methods.GetStorageManager(_methodsPtr),
            _storageEventsPtr,
            ref _storageEvents
        );
    }

    [Obsolete]
    public StoreManager GetStoreManager()
    {
        return StoreManagerInstance ??= new StoreManager(
            Methods.GetStoreManager(_methodsPtr),
            _storeEventsPtr,
            ref _storeEvents
        );
    }

    public VoiceManager GetVoiceManager()
    {
        return VoiceManagerInstance ??= new VoiceManager(
            Methods.GetVoiceManager(_methodsPtr),
            _voiceEventsPtr,
            ref _voiceEvents
        );
    }

    [Obsolete]
    public AchievementManager GetAchievementManager()
    {
        return AchievementManagerInstance ??= new AchievementManager(
            Methods.GetAchievementManager(_methodsPtr),
            _achievementEventsPtr,
            ref _achievementEvents
        );
    }
}

internal class MonoPInvokeCallbackAttribute : Attribute
{

}

[Obsolete]
public class ApplicationManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ValidateOrExitCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ValidateOrExitMethod(IntPtr methodsPtr, IntPtr callbackData, ValidateOrExitCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetCurrentLocaleMethod(IntPtr methodsPtr, StringBuilder locale);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetCurrentBranchMethod(IntPtr methodsPtr, StringBuilder branch);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetOAuth2TokenCallback(IntPtr ptr, Result result, ref OAuth2Token oauth2Token);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetOAuth2TokenMethod(IntPtr methodsPtr, IntPtr callbackData, GetOAuth2TokenCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetTicketCallback(IntPtr ptr, Result result, [MarshalAs(UnmanagedType.LPStr)]ref string data);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetTicketMethod(IntPtr methodsPtr, IntPtr callbackData, GetTicketCallback callback);

        internal ValidateOrExitMethod ValidateOrExit;

        internal GetCurrentLocaleMethod GetCurrentLocale;

        internal GetCurrentBranchMethod GetCurrentBranch;

        internal GetOAuth2TokenMethod GetOAuth2Token;

        internal GetTicketMethod GetTicket;
    }

    public delegate void ValidateOrExitHandler(Result result);

    public delegate void GetOAuth2TokenHandler(Result result, ref OAuth2Token oauth2Token);

    public delegate void GetTicketHandler(Result result, ref string data);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods))!;
            return (FfiMethods)_methodsStructure;
        }

    }

    internal ApplicationManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    [MonoPInvokeCallback]
    private static void ValidateOrExitCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ValidateOrExitHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void ValidateOrExit(ValidateOrExitHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ValidateOrExit(_methodsPtr, GCHandle.ToIntPtr(wrapped), ValidateOrExitCallbackImpl);
    }

    public string GetCurrentLocale()
    {
        var ret = new StringBuilder(128);
        Methods.GetCurrentLocale(_methodsPtr, ret);
        return ret.ToString();
    }

    public string GetCurrentBranch()
    {
        var ret = new StringBuilder(4096);
        Methods.GetCurrentBranch(_methodsPtr, ret);
        return ret.ToString();
    }

    [MonoPInvokeCallback]
    private static void GetOAuth2TokenCallbackImpl(IntPtr ptr, Result result, ref OAuth2Token oauth2Token)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as GetOAuth2TokenHandler;
        h.Free();
        callback?.Invoke(result, ref oauth2Token);
    }

    public void GetOAuth2Token(GetOAuth2TokenHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.GetOAuth2Token(_methodsPtr, GCHandle.ToIntPtr(wrapped), GetOAuth2TokenCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void GetTicketCallbackImpl(IntPtr ptr, Result result, ref string data)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as GetTicketHandler;
        h.Free();
        callback?.Invoke(result, ref data);
    }

    public void GetTicket(GetTicketHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.GetTicket(_methodsPtr, GCHandle.ToIntPtr(wrapped), GetTicketCallbackImpl);
    }
}

public class UserManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CurrentUserUpdateHandler(IntPtr ptr);

        internal CurrentUserUpdateHandler OnCurrentUserUpdate;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetCurrentUserMethod(IntPtr methodsPtr, ref User currentUser);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetUserCallback(IntPtr ptr, Result result, ref User user);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetUserMethod(IntPtr methodsPtr, long userId, IntPtr callbackData, GetUserCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetCurrentUserPremiumTypeMethod(IntPtr methodsPtr, ref PremiumType premiumType);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result CurrentUserHasFlagMethod(IntPtr methodsPtr, UserFlag flag, ref bool hasFlag);

        internal GetCurrentUserMethod GetCurrentUser;

        internal GetUserMethod GetUser;

        internal GetCurrentUserPremiumTypeMethod GetCurrentUserPremiumType;

        internal CurrentUserHasFlagMethod CurrentUserHasFlag;
    }

    public delegate void GetUserHandler(Result result, ref User user);

    public delegate void CurrentUserUpdateHandler();

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event CurrentUserUpdateHandler? OnCurrentUserUpdate;

    internal UserManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnCurrentUserUpdate = OnCurrentUserUpdateImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public User GetCurrentUser()
    {
        var ret = new User();
        var res = Methods.GetCurrentUser(_methodsPtr, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void GetUserCallbackImpl(IntPtr ptr, Result result, ref User user)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as GetUserHandler;
        h.Free();
        callback?.Invoke(result, ref user);
    }

    public void GetUser(long userId, GetUserHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.GetUser(_methodsPtr, userId, GCHandle.ToIntPtr(wrapped), GetUserCallbackImpl);
    }

    public PremiumType GetCurrentUserPremiumType()
    {
        var ret = new PremiumType();
        var res = Methods.GetCurrentUserPremiumType(_methodsPtr, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public bool CurrentUserHasFlag(UserFlag flag)
    {
        var ret = new bool();
        var res = Methods.CurrentUserHasFlag(_methodsPtr, flag, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void OnCurrentUserUpdateImpl(IntPtr ptr)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.UserManagerInstance?.OnCurrentUserUpdate?.Invoke();
    }
}

public partial class ImageManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchCallback(IntPtr ptr, Result result, ImageHandle handleResult);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchMethod(IntPtr methodsPtr, ImageHandle handle, bool refresh, IntPtr callbackData, FetchCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetDimensionsMethod(IntPtr methodsPtr, ImageHandle handle, ref ImageDimensions dimensions);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetDataMethod(IntPtr methodsPtr, ImageHandle handle, byte[] data, int dataLen);

        internal FetchMethod Fetch;

        internal GetDimensionsMethod GetDimensions;

        internal GetDataMethod GetData;
    }

    public delegate void FetchHandler(Result result, ImageHandle handleResult);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    internal ImageManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    [MonoPInvokeCallback]
    private static void FetchCallbackImpl(IntPtr ptr, Result result, ImageHandle handleResult)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as FetchHandler;
        h.Free();
        callback?.Invoke(result, handleResult);
    }

    public void Fetch(ImageHandle handle, bool refresh, FetchHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.Fetch(_methodsPtr, handle, refresh, GCHandle.ToIntPtr(wrapped), FetchCallbackImpl);
    }

    public ImageDimensions GetDimensions(ImageHandle handle)
    {
        var ret = new ImageDimensions();
        var res = Methods.GetDimensions(_methodsPtr, handle, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public void GetData(ImageHandle handle, byte[] data)
    {
        var res = Methods.GetData(_methodsPtr, handle, data, data.Length);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }
}

public partial class ActivityManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ActivityJoinHandler(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)]string secret);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ActivitySpectateHandler(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)]string secret);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ActivityJoinRequestHandler(IntPtr ptr, ref User user);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ActivityInviteHandler(IntPtr ptr, ActivityActionType type, ref User user, ref Activity activity);

        internal ActivityJoinHandler OnActivityJoin;

        internal ActivitySpectateHandler OnActivitySpectate;

        internal ActivityJoinRequestHandler OnActivityJoinRequest;

        internal ActivityInviteHandler OnActivityInvite;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result RegisterCommandMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string? command);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result RegisterSteamMethod(IntPtr methodsPtr, uint steamId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UpdateActivityCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UpdateActivityMethod(IntPtr methodsPtr, ref Activity activity, IntPtr callbackData, UpdateActivityCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ClearActivityCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ClearActivityMethod(IntPtr methodsPtr, IntPtr callbackData, ClearActivityCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SendRequestReplyCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SendRequestReplyMethod(IntPtr methodsPtr, long userId, ActivityJoinRequestReply reply, IntPtr callbackData, SendRequestReplyCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SendInviteCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SendInviteMethod(IntPtr methodsPtr, long userId, ActivityActionType type, [MarshalAs(UnmanagedType.LPStr)]string content, IntPtr callbackData, SendInviteCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void AcceptInviteCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void AcceptInviteMethod(IntPtr methodsPtr, long userId, IntPtr callbackData, AcceptInviteCallback callback);

        internal RegisterCommandMethod RegisterCommand;

        internal RegisterSteamMethod RegisterSteam;

        internal UpdateActivityMethod UpdateActivity;

        internal ClearActivityMethod ClearActivity;

        internal SendRequestReplyMethod SendRequestReply;

        internal SendInviteMethod SendInvite;

        internal AcceptInviteMethod AcceptInvite;
    }

    public delegate void UpdateActivityHandler(Result result);

    public delegate void ClearActivityHandler(Result result);

    public delegate void SendRequestReplyHandler(Result result);

    public delegate void SendInviteHandler(Result result);

    public delegate void AcceptInviteHandler(Result result);

    public delegate void ActivityJoinHandler(string secret);

    public delegate void ActivitySpectateHandler(string secret);

    public delegate void ActivityJoinRequestHandler(ref User user);

    public delegate void ActivityInviteHandler(ActivityActionType type, ref User user, ref Activity activity);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event ActivityJoinHandler? OnActivityJoin;

    public event ActivitySpectateHandler? OnActivitySpectate;

    public event ActivityJoinRequestHandler? OnActivityJoinRequest;

    public event ActivityInviteHandler? OnActivityInvite;

    internal ActivityManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnActivityJoin = OnActivityJoinImpl;
        events.OnActivitySpectate = OnActivitySpectateImpl;
        events.OnActivityJoinRequest = OnActivityJoinRequestImpl;
        events.OnActivityInvite = OnActivityInviteImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public void RegisterCommand(string? command)
    {
        var res = Methods.RegisterCommand(_methodsPtr, command);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public void RegisterSteam(uint steamId)
    {
        var res = Methods.RegisterSteam(_methodsPtr, steamId);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    [MonoPInvokeCallback]
    private static void UpdateActivityCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as UpdateActivityHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void UpdateActivity(Activity activity, UpdateActivityHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.UpdateActivity(_methodsPtr, ref activity, GCHandle.ToIntPtr(wrapped), UpdateActivityCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void ClearActivityCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ClearActivityHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void ClearActivity(ClearActivityHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ClearActivity(_methodsPtr, GCHandle.ToIntPtr(wrapped), ClearActivityCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void SendRequestReplyCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SendRequestReplyHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void SendRequestReply(long userId, ActivityJoinRequestReply reply, SendRequestReplyHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SendRequestReply(_methodsPtr, userId, reply, GCHandle.ToIntPtr(wrapped), SendRequestReplyCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void SendInviteCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SendInviteHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void SendInvite(long userId, ActivityActionType type, string content, SendInviteHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SendInvite(_methodsPtr, userId, type, content, GCHandle.ToIntPtr(wrapped), SendInviteCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void AcceptInviteCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as AcceptInviteHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void AcceptInvite(long userId, AcceptInviteHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.AcceptInvite(_methodsPtr, userId, GCHandle.ToIntPtr(wrapped), AcceptInviteCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void OnActivityJoinImpl(IntPtr ptr, string secret)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.ActivityManagerInstance?.OnActivityJoin?.Invoke(secret);
    }

    [MonoPInvokeCallback]
    private static void OnActivitySpectateImpl(IntPtr ptr, string secret)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.ActivityManagerInstance?.OnActivitySpectate?.Invoke(secret);
    }

    [MonoPInvokeCallback]
    private static void OnActivityJoinRequestImpl(IntPtr ptr, ref User user)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.ActivityManagerInstance?.OnActivityJoinRequest?.Invoke(ref user);
    }

    [MonoPInvokeCallback]
    private static void OnActivityInviteImpl(IntPtr ptr, ActivityActionType type, ref User user, ref Activity activity)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.ActivityManagerInstance?.OnActivityInvite?.Invoke(type, ref user, ref activity);
    }
}

public class RelationshipManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void RefreshHandler(IntPtr ptr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void RelationshipUpdateHandler(IntPtr ptr, ref Relationship relationship);

        internal RefreshHandler OnRefresh;

        internal RelationshipUpdateHandler OnRelationshipUpdate;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate bool FilterCallback(IntPtr ptr, ref Relationship relationship);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FilterMethod(IntPtr methodsPtr, IntPtr callbackData, FilterCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result CountMethod(IntPtr methodsPtr, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetMethod(IntPtr methodsPtr, long userId, ref Relationship relationship);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetAtMethod(IntPtr methodsPtr, uint index, ref Relationship relationship);

        internal FilterMethod Filter;

        internal CountMethod Count;

        internal GetMethod Get;

        internal GetAtMethod GetAt;
    }

    public delegate bool FilterHandler(ref Relationship relationship);

    public delegate void RefreshHandler();

    public delegate void RelationshipUpdateHandler(ref Relationship relationship);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event RefreshHandler? OnRefresh;

    public event RelationshipUpdateHandler? OnRelationshipUpdate;

    internal RelationshipManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnRefresh = OnRefreshImpl;
        events.OnRelationshipUpdate = OnRelationshipUpdateImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    [MonoPInvokeCallback]
    private static bool FilterCallbackImpl(IntPtr ptr, ref Relationship relationship)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as FilterHandler;
        return callback != null && callback(ref relationship);
    }

    public void Filter(FilterHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.Filter(_methodsPtr, GCHandle.ToIntPtr(wrapped), FilterCallbackImpl);
        wrapped.Free();
    }

    public int Count()
    {
        var ret = new int();
        var res = Methods.Count(_methodsPtr, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public Relationship Get(long userId)
    {
        var ret = new Relationship();
        var res = Methods.Get(_methodsPtr, userId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public Relationship GetAt(uint index)
    {
        var ret = new Relationship();
        var res = Methods.GetAt(_methodsPtr, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void OnRefreshImpl(IntPtr ptr)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.RelationshipManagerInstance?.OnRefresh?.Invoke();
    }

    [MonoPInvokeCallback]
    private static void OnRelationshipUpdateImpl(IntPtr ptr, ref Relationship relationship)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.RelationshipManagerInstance?.OnRelationshipUpdate?.Invoke(ref relationship);
    }
}

public partial class LobbyManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void LobbyUpdateHandler(IntPtr ptr, long lobbyId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void LobbyDeleteHandler(IntPtr ptr, long lobbyId, uint reason);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void MemberConnectHandler(IntPtr ptr, long lobbyId, long userId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void MemberUpdateHandler(IntPtr ptr, long lobbyId, long userId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void MemberDisconnectHandler(IntPtr ptr, long lobbyId, long userId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void LobbyMessageHandler(IntPtr ptr, long lobbyId, long userId, IntPtr dataPtr, int dataLen);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SpeakingHandler(IntPtr ptr, long lobbyId, long userId, bool speaking);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void NetworkMessageHandler(IntPtr ptr, long lobbyId, long userId, byte channelId, IntPtr dataPtr, int dataLen);

        internal LobbyUpdateHandler OnLobbyUpdate;

        internal LobbyDeleteHandler OnLobbyDelete;

        internal MemberConnectHandler OnMemberConnect;

        internal MemberUpdateHandler OnMemberUpdate;

        internal MemberDisconnectHandler OnMemberDisconnect;

        internal LobbyMessageHandler OnLobbyMessage;

        internal SpeakingHandler OnSpeaking;

        internal NetworkMessageHandler OnNetworkMessage;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyCreateTransactionMethod(IntPtr methodsPtr, ref IntPtr transaction);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyUpdateTransactionMethod(IntPtr methodsPtr, long lobbyId, ref IntPtr transaction);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetMemberUpdateTransactionMethod(IntPtr methodsPtr, long lobbyId, long userId, ref IntPtr transaction);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CreateLobbyCallback(IntPtr ptr, Result result, ref Lobby lobby);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CreateLobbyMethod(IntPtr methodsPtr, IntPtr transaction, IntPtr callbackData, CreateLobbyCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UpdateLobbyCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UpdateLobbyMethod(IntPtr methodsPtr, long lobbyId, IntPtr transaction, IntPtr callbackData, UpdateLobbyCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DeleteLobbyCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DeleteLobbyMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, DeleteLobbyCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ConnectLobbyCallback(IntPtr ptr, Result result, ref Lobby lobby);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ConnectLobbyMethod(IntPtr methodsPtr, long lobbyId, [MarshalAs(UnmanagedType.LPStr)]string secret, IntPtr callbackData, ConnectLobbyCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ConnectLobbyWithActivitySecretCallback(IntPtr ptr, Result result, ref Lobby lobby);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ConnectLobbyWithActivitySecretMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string activitySecret, IntPtr callbackData, ConnectLobbyWithActivitySecretCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DisconnectLobbyCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DisconnectLobbyMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, DisconnectLobbyCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyMethod(IntPtr methodsPtr, long lobbyId, ref Lobby lobby);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyActivitySecretMethod(IntPtr methodsPtr, long lobbyId, StringBuilder secret);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyMetadataValueMethod(IntPtr methodsPtr, long lobbyId, [MarshalAs(UnmanagedType.LPStr)]string key, StringBuilder value);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyMetadataKeyMethod(IntPtr methodsPtr, long lobbyId, int index, StringBuilder key);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result LobbyMetadataCountMethod(IntPtr methodsPtr, long lobbyId, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result MemberCountMethod(IntPtr methodsPtr, long lobbyId, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetMemberUserIdMethod(IntPtr methodsPtr, long lobbyId, int index, ref long userId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetMemberUserMethod(IntPtr methodsPtr, long lobbyId, long userId, ref User user);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetMemberMetadataValueMethod(IntPtr methodsPtr, long lobbyId, long userId, [MarshalAs(UnmanagedType.LPStr)]string key, StringBuilder value);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetMemberMetadataKeyMethod(IntPtr methodsPtr, long lobbyId, long userId, int index, StringBuilder key);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result MemberMetadataCountMethod(IntPtr methodsPtr, long lobbyId, long userId, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UpdateMemberCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UpdateMemberMethod(IntPtr methodsPtr, long lobbyId, long userId, IntPtr transaction, IntPtr callbackData, UpdateMemberCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SendLobbyMessageCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SendLobbyMessageMethod(IntPtr methodsPtr, long lobbyId, byte[] data, int dataLen, IntPtr callbackData, SendLobbyMessageCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetSearchQueryMethod(IntPtr methodsPtr, ref IntPtr query);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SearchCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SearchMethod(IntPtr methodsPtr, IntPtr query, IntPtr callbackData, SearchCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void LobbyCountMethod(IntPtr methodsPtr, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLobbyIdMethod(IntPtr methodsPtr, int index, ref long lobbyId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ConnectVoiceCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ConnectVoiceMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, ConnectVoiceCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DisconnectVoiceCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void DisconnectVoiceMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, DisconnectVoiceCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result ConnectNetworkMethod(IntPtr methodsPtr, long lobbyId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result DisconnectNetworkMethod(IntPtr methodsPtr, long lobbyId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result FlushNetworkMethod(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result OpenNetworkChannelMethod(IntPtr methodsPtr, long lobbyId, byte channelId, bool reliable);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SendNetworkMessageMethod(IntPtr methodsPtr, long lobbyId, long userId, byte channelId, byte[] data, int dataLen);

        internal GetLobbyCreateTransactionMethod GetLobbyCreateTransaction;

        internal GetLobbyUpdateTransactionMethod GetLobbyUpdateTransaction;

        internal GetMemberUpdateTransactionMethod GetMemberUpdateTransaction;

        internal CreateLobbyMethod CreateLobby;

        internal UpdateLobbyMethod UpdateLobby;

        internal DeleteLobbyMethod DeleteLobby;

        internal ConnectLobbyMethod ConnectLobby;

        internal ConnectLobbyWithActivitySecretMethod ConnectLobbyWithActivitySecret;

        internal DisconnectLobbyMethod DisconnectLobby;

        internal GetLobbyMethod GetLobby;

        internal GetLobbyActivitySecretMethod GetLobbyActivitySecret;

        internal GetLobbyMetadataValueMethod GetLobbyMetadataValue;

        internal GetLobbyMetadataKeyMethod GetLobbyMetadataKey;

        internal LobbyMetadataCountMethod LobbyMetadataCount;

        internal MemberCountMethod MemberCount;

        internal GetMemberUserIdMethod GetMemberUserId;

        internal GetMemberUserMethod GetMemberUser;

        internal GetMemberMetadataValueMethod GetMemberMetadataValue;

        internal GetMemberMetadataKeyMethod GetMemberMetadataKey;

        internal MemberMetadataCountMethod MemberMetadataCount;

        internal UpdateMemberMethod UpdateMember;

        internal SendLobbyMessageMethod SendLobbyMessage;

        internal GetSearchQueryMethod GetSearchQuery;

        internal SearchMethod Search;

        internal LobbyCountMethod LobbyCount;

        internal GetLobbyIdMethod GetLobbyId;

        internal ConnectVoiceMethod ConnectVoice;

        internal DisconnectVoiceMethod DisconnectVoice;

        internal ConnectNetworkMethod ConnectNetwork;

        internal DisconnectNetworkMethod DisconnectNetwork;

        internal FlushNetworkMethod FlushNetwork;

        internal OpenNetworkChannelMethod OpenNetworkChannel;

        internal SendNetworkMessageMethod SendNetworkMessage;
    }

    public delegate void CreateLobbyHandler(Result result, ref Lobby lobby);

    public delegate void UpdateLobbyHandler(Result result);

    public delegate void DeleteLobbyHandler(Result result);

    public delegate void ConnectLobbyHandler(Result result, ref Lobby lobby);

    public delegate void ConnectLobbyWithActivitySecretHandler(Result result, ref Lobby lobby);

    public delegate void DisconnectLobbyHandler(Result result);

    public delegate void UpdateMemberHandler(Result result);

    public delegate void SendLobbyMessageHandler(Result result);

    public delegate void SearchHandler(Result result);

    public delegate void ConnectVoiceHandler(Result result);

    public delegate void DisconnectVoiceHandler(Result result);

    public delegate void LobbyUpdateHandler(long lobbyId);

    public delegate void LobbyDeleteHandler(long lobbyId, uint reason);

    public delegate void MemberConnectHandler(long lobbyId, long userId);

    public delegate void MemberUpdateHandler(long lobbyId, long userId);

    public delegate void MemberDisconnectHandler(long lobbyId, long userId);

    public delegate void LobbyMessageHandler(long lobbyId, long userId, byte[] data);

    public delegate void SpeakingHandler(long lobbyId, long userId, bool speaking);

    public delegate void NetworkMessageHandler(long lobbyId, long userId, byte channelId, byte[] data);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event LobbyUpdateHandler? OnLobbyUpdate;

    public event LobbyDeleteHandler? OnLobbyDelete;

    public event MemberConnectHandler? OnMemberConnect;

    public event MemberUpdateHandler? OnMemberUpdate;

    public event MemberDisconnectHandler? OnMemberDisconnect;

    public event LobbyMessageHandler? OnLobbyMessage;

    public event SpeakingHandler? OnSpeaking;

    public event NetworkMessageHandler? OnNetworkMessage;

    internal LobbyManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnLobbyUpdate = OnLobbyUpdateImpl;
        events.OnLobbyDelete = OnLobbyDeleteImpl;
        events.OnMemberConnect = OnMemberConnectImpl;
        events.OnMemberUpdate = OnMemberUpdateImpl;
        events.OnMemberDisconnect = OnMemberDisconnectImpl;
        events.OnLobbyMessage = OnLobbyMessageImpl;
        events.OnSpeaking = OnSpeakingImpl;
        events.OnNetworkMessage = OnNetworkMessageImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public LobbyTransaction GetLobbyCreateTransaction()
    {
        var ret = new LobbyTransaction();
        var res = Methods.GetLobbyCreateTransaction(_methodsPtr, ref ret.MethodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public LobbyTransaction GetLobbyUpdateTransaction(long lobbyId)
    {
        var ret = new LobbyTransaction();
        var res = Methods.GetLobbyUpdateTransaction(_methodsPtr, lobbyId, ref ret.MethodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public LobbyMemberTransaction GetMemberUpdateTransaction(long lobbyId, long userId)
    {
        var ret = new LobbyMemberTransaction();
        var res = Methods.GetMemberUpdateTransaction(_methodsPtr, lobbyId, userId, ref ret.MethodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void CreateLobbyCallbackImpl(IntPtr ptr, Result result, ref Lobby lobby)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as CreateLobbyHandler;
        h.Free();
        callback?.Invoke(result, ref lobby);
    }

    public void CreateLobby(LobbyTransaction transaction, CreateLobbyHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.CreateLobby(_methodsPtr, transaction.MethodsPtr, GCHandle.ToIntPtr(wrapped), CreateLobbyCallbackImpl);
        transaction.MethodsPtr = IntPtr.Zero;
    }

    [MonoPInvokeCallback]
    private static void UpdateLobbyCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as UpdateLobbyHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void UpdateLobby(long lobbyId, LobbyTransaction transaction, UpdateLobbyHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.UpdateLobby(_methodsPtr, lobbyId, transaction.MethodsPtr, GCHandle.ToIntPtr(wrapped), UpdateLobbyCallbackImpl);
        transaction.MethodsPtr = IntPtr.Zero;
    }

    [MonoPInvokeCallback]
    private static void DeleteLobbyCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as DeleteLobbyHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void DeleteLobby(long lobbyId, DeleteLobbyHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.DeleteLobby(_methodsPtr, lobbyId, GCHandle.ToIntPtr(wrapped), DeleteLobbyCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void ConnectLobbyCallbackImpl(IntPtr ptr, Result result, ref Lobby lobby)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ConnectLobbyHandler;
        h.Free();
        callback?.Invoke(result, ref lobby);
    }

    public void ConnectLobby(long lobbyId, string secret, ConnectLobbyHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ConnectLobby(_methodsPtr, lobbyId, secret, GCHandle.ToIntPtr(wrapped), ConnectLobbyCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void ConnectLobbyWithActivitySecretCallbackImpl(IntPtr ptr, Result result, ref Lobby lobby)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ConnectLobbyWithActivitySecretHandler;
        h.Free();
        callback?.Invoke(result, ref lobby);
    }

    public void ConnectLobbyWithActivitySecret(string activitySecret, ConnectLobbyWithActivitySecretHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ConnectLobbyWithActivitySecret(_methodsPtr, activitySecret, GCHandle.ToIntPtr(wrapped), ConnectLobbyWithActivitySecretCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void DisconnectLobbyCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as DisconnectLobbyHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void DisconnectLobby(long lobbyId, DisconnectLobbyHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.DisconnectLobby(_methodsPtr, lobbyId, GCHandle.ToIntPtr(wrapped), DisconnectLobbyCallbackImpl);
    }

    public Lobby GetLobby(long lobbyId)
    {
        var ret = new Lobby();
        var res = Methods.GetLobby(_methodsPtr, lobbyId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public string GetLobbyActivitySecret(long lobbyId)
    {
        var ret = new StringBuilder(128);
        var res = Methods.GetLobbyActivitySecret(_methodsPtr, lobbyId, ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret.ToString();
    }

    public string GetLobbyMetadataValue(long lobbyId, string key)
    {
        var ret = new StringBuilder(4096);
        var res = Methods.GetLobbyMetadataValue(_methodsPtr, lobbyId, key, ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret.ToString();
    }

    public string GetLobbyMetadataKey(long lobbyId, int index)
    {
        var ret = new StringBuilder(256);
        var res = Methods.GetLobbyMetadataKey(_methodsPtr, lobbyId, index, ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret.ToString();
    }

    public int LobbyMetadataCount(long lobbyId)
    {
        var ret = new int();
        var res = Methods.LobbyMetadataCount(_methodsPtr, lobbyId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public int MemberCount(long lobbyId)
    {
        var ret = new int();
        var res = Methods.MemberCount(_methodsPtr, lobbyId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public long GetMemberUserId(long lobbyId, int index)
    {
        var ret = new long();
        var res = Methods.GetMemberUserId(_methodsPtr, lobbyId, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public User GetMemberUser(long lobbyId, long userId)
    {
        var ret = new User();
        var res = Methods.GetMemberUser(_methodsPtr, lobbyId, userId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public string GetMemberMetadataValue(long lobbyId, long userId, string key)
    {
        var ret = new StringBuilder(4096);
        var res = Methods.GetMemberMetadataValue(_methodsPtr, lobbyId, userId, key, ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret.ToString();
    }

    public string GetMemberMetadataKey(long lobbyId, long userId, int index)
    {
        var ret = new StringBuilder(256);
        var res = Methods.GetMemberMetadataKey(_methodsPtr, lobbyId, userId, index, ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret.ToString();
    }

    public int MemberMetadataCount(long lobbyId, long userId)
    {
        var ret = new int();
        var res = Methods.MemberMetadataCount(_methodsPtr, lobbyId, userId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void UpdateMemberCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as UpdateMemberHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void UpdateMember(long lobbyId, long userId, LobbyMemberTransaction transaction, UpdateMemberHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.UpdateMember(_methodsPtr, lobbyId, userId, transaction.MethodsPtr, GCHandle.ToIntPtr(wrapped), UpdateMemberCallbackImpl);
        transaction.MethodsPtr = IntPtr.Zero;
    }

    [MonoPInvokeCallback]
    private static void SendLobbyMessageCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SendLobbyMessageHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void SendLobbyMessage(long lobbyId, byte[] data, SendLobbyMessageHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SendLobbyMessage(_methodsPtr, lobbyId, data, data.Length, GCHandle.ToIntPtr(wrapped), SendLobbyMessageCallbackImpl);
    }

    public LobbySearchQuery GetSearchQuery()
    {
        var ret = new LobbySearchQuery();
        var res = Methods.GetSearchQuery(_methodsPtr, ref ret.MethodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void SearchCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SearchHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void Search(LobbySearchQuery query, SearchHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.Search(_methodsPtr, query.MethodsPtr, GCHandle.ToIntPtr(wrapped), SearchCallbackImpl);
        query.MethodsPtr = IntPtr.Zero;
    }

    public int LobbyCount()
    {
        var ret = new int();
        Methods.LobbyCount(_methodsPtr, ref ret);
        return ret;
    }

    public long GetLobbyId(int index)
    {
        var ret = new long();
        var res = Methods.GetLobbyId(_methodsPtr, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void ConnectVoiceCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ConnectVoiceHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void ConnectVoice(long lobbyId, ConnectVoiceHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ConnectVoice(_methodsPtr, lobbyId, GCHandle.ToIntPtr(wrapped), ConnectVoiceCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void DisconnectVoiceCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as DisconnectVoiceHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void DisconnectVoice(long lobbyId, DisconnectVoiceHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.DisconnectVoice(_methodsPtr, lobbyId, GCHandle.ToIntPtr(wrapped), DisconnectVoiceCallbackImpl);
    }

    public void ConnectNetwork(long lobbyId)
    {
        var res = Methods.ConnectNetwork(_methodsPtr, lobbyId);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public void DisconnectNetwork(long lobbyId)
    {
        var res = Methods.DisconnectNetwork(_methodsPtr, lobbyId);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public void FlushNetwork()
    {
        var res = Methods.FlushNetwork(_methodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public void OpenNetworkChannel(long lobbyId, byte channelId, bool reliable)
    {
        var res = Methods.OpenNetworkChannel(_methodsPtr, lobbyId, channelId, reliable);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public void SendNetworkMessage(long lobbyId, long userId, byte channelId, byte[] data)
    {
        var res = Methods.SendNetworkMessage(_methodsPtr, lobbyId, userId, channelId, data, data.Length);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    [MonoPInvokeCallback]
    private static void OnLobbyUpdateImpl(IntPtr ptr, long lobbyId)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.LobbyManagerInstance?.OnLobbyUpdate?.Invoke(lobbyId);
    }

    [MonoPInvokeCallback]
    private static void OnLobbyDeleteImpl(IntPtr ptr, long lobbyId, uint reason)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.LobbyManagerInstance?.OnLobbyDelete?.Invoke(lobbyId, reason);
    }

    [MonoPInvokeCallback]
    private static void OnMemberConnectImpl(IntPtr ptr, long lobbyId, long userId)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.LobbyManagerInstance?.OnMemberConnect?.Invoke(lobbyId, userId);
    }

    [MonoPInvokeCallback]
    private static void OnMemberUpdateImpl(IntPtr ptr, long lobbyId, long userId)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.LobbyManagerInstance?.OnMemberUpdate?.Invoke(lobbyId, userId);
    }

    [MonoPInvokeCallback]
    private static void OnMemberDisconnectImpl(IntPtr ptr, long lobbyId, long userId)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.LobbyManagerInstance?.OnMemberDisconnect?.Invoke(lobbyId, userId);
    }

    [MonoPInvokeCallback]
    private static void OnLobbyMessageImpl(IntPtr ptr, long lobbyId, long userId, IntPtr dataPtr, int dataLen)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        if (d?.LobbyManagerInstance?.OnLobbyMessage != null)
        {
            var data = new byte[dataLen];
            Marshal.Copy(dataPtr, data, 0, dataLen);
            d.LobbyManagerInstance.OnLobbyMessage.Invoke(lobbyId, userId, data);
        }
    }

    [MonoPInvokeCallback]
    private static void OnSpeakingImpl(IntPtr ptr, long lobbyId, long userId, bool speaking)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.LobbyManagerInstance?.OnSpeaking?.Invoke(lobbyId, userId, speaking);
    }

    [MonoPInvokeCallback]
    private static void OnNetworkMessageImpl(IntPtr ptr, long lobbyId, long userId, byte channelId, IntPtr dataPtr, int dataLen)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        if (d?.LobbyManagerInstance?.OnNetworkMessage != null)
        {
            var data = new byte[dataLen];
            Marshal.Copy(dataPtr, data, 0, dataLen);
            d.LobbyManagerInstance.OnNetworkMessage.Invoke(lobbyId, userId, channelId, data);
        }
    }
}

[Obsolete]
public class NetworkManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void MessageHandler(IntPtr ptr, ulong peerId, byte channelId, IntPtr dataPtr, int dataLen);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void RouteUpdateHandler(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)]string routeData);

        internal MessageHandler OnMessage;

        internal RouteUpdateHandler OnRouteUpdate;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void GetPeerIdMethod(IntPtr methodsPtr, ref ulong peerId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result FlushMethod(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result OpenPeerMethod(IntPtr methodsPtr, ulong peerId, [MarshalAs(UnmanagedType.LPStr)]string routeData);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result UpdatePeerMethod(IntPtr methodsPtr, ulong peerId, [MarshalAs(UnmanagedType.LPStr)]string routeData);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result ClosePeerMethod(IntPtr methodsPtr, ulong peerId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result OpenChannelMethod(IntPtr methodsPtr, ulong peerId, byte channelId, bool reliable);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result CloseChannelMethod(IntPtr methodsPtr, ulong peerId, byte channelId);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SendMessageMethod(IntPtr methodsPtr, ulong peerId, byte channelId, byte[] data, int dataLen);

        internal GetPeerIdMethod GetPeerId;

        internal FlushMethod Flush;

        internal OpenPeerMethod OpenPeer;

        internal UpdatePeerMethod UpdatePeer;

        internal ClosePeerMethod ClosePeer;

        internal OpenChannelMethod OpenChannel;

        internal CloseChannelMethod CloseChannel;

        internal SendMessageMethod SendMessage;
    }

    public delegate void MessageHandler(ulong peerId, byte channelId, byte[] data);

    public delegate void RouteUpdateHandler(string routeData);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event MessageHandler? OnMessage;

    public event RouteUpdateHandler? OnRouteUpdate;

    internal NetworkManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnMessage = OnMessageImpl;
        events.OnRouteUpdate = OnRouteUpdateImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    /// <summary>
    /// Get the local peer ID for this process.
    /// </summary>
    public ulong GetPeerId()
    {
        var ret = new ulong();
        Methods.GetPeerId(_methodsPtr, ref ret);
        return ret;
    }

    /// <summary>
    /// Send pending network messages.
    /// </summary>
    public void Flush()
    {
        var res = Methods.Flush(_methodsPtr);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    /// <summary>
    /// Open a connection to a remote peer.
    /// </summary>
    public void OpenPeer(ulong peerId, string routeData)
    {
        var res = Methods.OpenPeer(_methodsPtr, peerId, routeData);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    /// <summary>
    /// Update the route data for a connected peer.
    /// </summary>
    public void UpdatePeer(ulong peerId, string routeData)
    {
        var res = Methods.UpdatePeer(_methodsPtr, peerId, routeData);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    /// <summary>
    /// Close the connection to a remote peer.
    /// </summary>
    public void ClosePeer(ulong peerId)
    {
        var res = Methods.ClosePeer(_methodsPtr, peerId);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    /// <summary>
    /// Open a message channel to a connected peer.
    /// </summary>
    public void OpenChannel(ulong peerId, byte channelId, bool reliable)
    {
        var res = Methods.OpenChannel(_methodsPtr, peerId, channelId, reliable);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    /// <summary>
    /// Close a message channel to a connected peer.
    /// </summary>
    public void CloseChannel(ulong peerId, byte channelId)
    {
        var res = Methods.CloseChannel(_methodsPtr, peerId, channelId);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    /// <summary>
    /// Send a message to a connected peer over an opened message channel.
    /// </summary>
    public void SendMessage(ulong peerId, byte channelId, byte[] data)
    {
        var res = Methods.SendMessage(_methodsPtr, peerId, channelId, data, data.Length);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    [MonoPInvokeCallback]
    private static void OnMessageImpl(IntPtr ptr, ulong peerId, byte channelId, IntPtr dataPtr, int dataLen)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        if (d?.NetworkManagerInstance?.OnMessage != null)
        {
            var data = new byte[dataLen];
            Marshal.Copy(dataPtr, data, 0, dataLen);
            d.NetworkManagerInstance.OnMessage.Invoke(peerId, channelId, data);
        }
    }

    [MonoPInvokeCallback]
    private static void OnRouteUpdateImpl(IntPtr ptr, string routeData)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.NetworkManagerInstance?.OnRouteUpdate?.Invoke(routeData);
    }
}

public class OverlayManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ToggleHandler(IntPtr ptr, bool locked);

        internal ToggleHandler OnToggle;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void IsEnabledMethod(IntPtr methodsPtr, ref bool enabled);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void IsLockedMethod(IntPtr methodsPtr, ref bool locked);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetLockedCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetLockedMethod(IntPtr methodsPtr, bool locked, IntPtr callbackData, SetLockedCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OpenActivityInviteCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OpenActivityInviteMethod(IntPtr methodsPtr, ActivityActionType type, IntPtr callbackData, OpenActivityInviteCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OpenGuildInviteCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OpenGuildInviteMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string code, IntPtr callbackData, OpenGuildInviteCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OpenVoiceSettingsCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OpenVoiceSettingsMethod(IntPtr methodsPtr, IntPtr callbackData, OpenVoiceSettingsCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result InitDrawingDxgiMethod(IntPtr methodsPtr, IntPtr swapchain, bool useMessageForwarding);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void OnPresentMethod(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ForwardMessageMethod(IntPtr methodsPtr, IntPtr message);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void KeyEventMethod(IntPtr methodsPtr, bool down, [MarshalAs(UnmanagedType.LPStr)]string keyCode, KeyVariant variant);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CharEventMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string character);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void MouseButtonEventMethod(IntPtr methodsPtr, byte down, int clickCount, MouseButton which, int x, int y);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void MouseMotionEventMethod(IntPtr methodsPtr, int x, int y);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ImeCommitTextMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string text);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ImeSetCompositionMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string text, ref ImeUnderline underlines, int from, int to);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ImeCancelCompositionMethod(IntPtr methodsPtr);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetImeCompositionRangeCallbackCallback(IntPtr ptr, int from, int to, ref Rect bounds);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetImeCompositionRangeCallbackMethod(IntPtr methodsPtr, IntPtr callbackData, SetImeCompositionRangeCallbackCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetImeSelectionBoundsCallbackCallback(IntPtr ptr, Rect anchor, Rect focus, bool isAnchorFirst);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetImeSelectionBoundsCallbackMethod(IntPtr methodsPtr, IntPtr callbackData, SetImeSelectionBoundsCallbackCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate bool IsPointInsideClickZoneMethod(IntPtr methodsPtr, int x, int y);

        internal IsEnabledMethod IsEnabled;

        internal IsLockedMethod IsLocked;

        internal SetLockedMethod SetLocked;

        internal OpenActivityInviteMethod OpenActivityInvite;

        internal OpenGuildInviteMethod OpenGuildInvite;

        internal OpenVoiceSettingsMethod OpenVoiceSettings;

        internal InitDrawingDxgiMethod InitDrawingDxgi;

        internal OnPresentMethod OnPresent;

        internal ForwardMessageMethod ForwardMessage;

        internal KeyEventMethod KeyEvent;

        internal CharEventMethod CharEvent;

        internal MouseButtonEventMethod MouseButtonEvent;

        internal MouseMotionEventMethod MouseMotionEvent;

        internal ImeCommitTextMethod ImeCommitText;

        internal ImeSetCompositionMethod ImeSetComposition;

        internal ImeCancelCompositionMethod ImeCancelComposition;

        internal SetImeCompositionRangeCallbackMethod SetImeCompositionRangeCallback;

        internal SetImeSelectionBoundsCallbackMethod SetImeSelectionBoundsCallback;

        internal IsPointInsideClickZoneMethod IsPointInsideClickZone;
    }

    public delegate void SetLockedHandler(Result result);

    public delegate void OpenActivityInviteHandler(Result result);

    public delegate void OpenGuildInviteHandler(Result result);

    public delegate void OpenVoiceSettingsHandler(Result result);

    public delegate void SetImeCompositionRangeCallbackHandler(int from, int to, ref Rect bounds);

    public delegate void SetImeSelectionBoundsCallbackHandler(Rect anchor, Rect focus, bool isAnchorFirst);

    public delegate void ToggleHandler(bool locked);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event ToggleHandler? OnToggle;

    internal OverlayManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnToggle = OnToggleImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public bool IsEnabled()
    {
        var ret = new bool();
        Methods.IsEnabled(_methodsPtr, ref ret);
        return ret;
    }

    public bool IsLocked()
    {
        var ret = new bool();
        Methods.IsLocked(_methodsPtr, ref ret);
        return ret;
    }

    [MonoPInvokeCallback]
    private static void SetLockedCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SetLockedHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void SetLocked(bool locked, SetLockedHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SetLocked(_methodsPtr, locked, GCHandle.ToIntPtr(wrapped), SetLockedCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void OpenActivityInviteCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as OpenActivityInviteHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void OpenActivityInvite(ActivityActionType type, OpenActivityInviteHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.OpenActivityInvite(_methodsPtr, type, GCHandle.ToIntPtr(wrapped), OpenActivityInviteCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void OpenGuildInviteCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as OpenGuildInviteHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void OpenGuildInvite(string code, OpenGuildInviteHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.OpenGuildInvite(_methodsPtr, code, GCHandle.ToIntPtr(wrapped), OpenGuildInviteCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void OpenVoiceSettingsCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as OpenVoiceSettingsHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void OpenVoiceSettings(OpenVoiceSettingsHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.OpenVoiceSettings(_methodsPtr, GCHandle.ToIntPtr(wrapped), OpenVoiceSettingsCallbackImpl);
    }

    public void InitDrawingDxgi(IntPtr swapchain, bool useMessageForwarding)
    {
        var res = Methods.InitDrawingDxgi(_methodsPtr, swapchain, useMessageForwarding);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public void OnPresent()
    {
        Methods.OnPresent(_methodsPtr);
    }

    public void ForwardMessage(IntPtr message)
    {
        Methods.ForwardMessage(_methodsPtr, message);
    }

    public void KeyEvent(bool down, string keyCode, KeyVariant variant)
    {
        Methods.KeyEvent(_methodsPtr, down, keyCode, variant);
    }

    public void CharEvent(string character)
    {
        Methods.CharEvent(_methodsPtr, character);
    }

    public void MouseButtonEvent(byte down, int clickCount, MouseButton which, int x, int y)
    {
        Methods.MouseButtonEvent(_methodsPtr, down, clickCount, which, x, y);
    }

    public void MouseMotionEvent(int x, int y)
    {
        Methods.MouseMotionEvent(_methodsPtr, x, y);
    }

    public void ImeCommitText(string text)
    {
        Methods.ImeCommitText(_methodsPtr, text);
    }

    public void ImeSetComposition(string text, ImeUnderline underlines, int from, int to)
    {
        Methods.ImeSetComposition(_methodsPtr, text, ref underlines, from, to);
    }

    public void ImeCancelComposition()
    {
        Methods.ImeCancelComposition(_methodsPtr);
    }

    [MonoPInvokeCallback]
    private static void SetImeCompositionRangeCallbackCallbackImpl(IntPtr ptr, int from, int to, ref Rect bounds)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SetImeCompositionRangeCallbackHandler;
        h.Free();
        callback?.Invoke(from, to, ref bounds);
    }

    public void SetImeCompositionRangeCallback(SetImeCompositionRangeCallbackHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SetImeCompositionRangeCallback(_methodsPtr, GCHandle.ToIntPtr(wrapped), SetImeCompositionRangeCallbackCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void SetImeSelectionBoundsCallbackCallbackImpl(IntPtr ptr, Rect anchor, Rect focus, bool isAnchorFirst)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SetImeSelectionBoundsCallbackHandler;
        h.Free();
        callback?.Invoke(anchor, focus, isAnchorFirst);
    }

    public void SetImeSelectionBoundsCallback(SetImeSelectionBoundsCallbackHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SetImeSelectionBoundsCallback(_methodsPtr, GCHandle.ToIntPtr(wrapped), SetImeSelectionBoundsCallbackCallbackImpl);
    }

    public bool IsPointInsideClickZone(int x, int y)
    {
        return Methods.IsPointInsideClickZone(_methodsPtr, x, y);
    }

    [MonoPInvokeCallback]
    private static void OnToggleImpl(IntPtr ptr, bool locked)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.OverlayManagerInstance?.OnToggle?.Invoke(locked);
    }
}

public partial class StorageManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result ReadMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, byte[] data, int dataLen, ref uint read);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ReadAsyncCallback(IntPtr ptr, Result result, IntPtr dataPtr, int dataLen);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ReadAsyncMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, IntPtr callbackData, ReadAsyncCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ReadAsyncPartialCallback(IntPtr ptr, Result result, IntPtr dataPtr, int dataLen);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void ReadAsyncPartialMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, ulong offset, ulong length, IntPtr callbackData, ReadAsyncPartialCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result WriteMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, byte[] data, int dataLen);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void WriteAsyncCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void WriteAsyncMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, byte[] data, int dataLen, IntPtr callbackData, WriteAsyncCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result DeleteMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result ExistsMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, ref bool exists);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CountMethod(IntPtr methodsPtr, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result StatMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)]string name, ref FileStat stat);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result StatAtMethod(IntPtr methodsPtr, int index, ref FileStat stat);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetPathMethod(IntPtr methodsPtr, StringBuilder path);

        internal ReadMethod Read;

        internal ReadAsyncMethod ReadAsync;

        internal ReadAsyncPartialMethod ReadAsyncPartial;

        internal WriteMethod Write;

        internal WriteAsyncMethod WriteAsync;

        internal DeleteMethod Delete;

        internal ExistsMethod Exists;

        internal CountMethod Count;

        internal StatMethod Stat;

        internal StatAtMethod StatAt;

        internal GetPathMethod GetPath;
    }

    public delegate void ReadAsyncHandler(Result result, byte[] data);

    public delegate void ReadAsyncPartialHandler(Result result, byte[] data);

    public delegate void WriteAsyncHandler(Result result);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    internal StorageManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public uint Read(string name, byte[] data)
    {
        var ret = new uint();
        var res = Methods.Read(_methodsPtr, name, data, data.Length, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void ReadAsyncCallbackImpl(IntPtr ptr, Result result, IntPtr dataPtr, int dataLen)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ReadAsyncHandler;
        h.Free();
        var data = new byte[dataLen];
        Marshal.Copy(dataPtr, data, 0, dataLen);
        callback?.Invoke(result, data);
    }

    public void ReadAsync(string name, ReadAsyncHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ReadAsync(_methodsPtr, name, GCHandle.ToIntPtr(wrapped), ReadAsyncCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void ReadAsyncPartialCallbackImpl(IntPtr ptr, Result result, IntPtr dataPtr, int dataLen)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as ReadAsyncPartialHandler;
        h.Free();
        var data = new byte[dataLen];
        Marshal.Copy(dataPtr, data, 0, dataLen);
        callback?.Invoke(result, data);
    }

    public void ReadAsyncPartial(string name, ulong offset, ulong length, ReadAsyncPartialHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.ReadAsyncPartial(_methodsPtr, name, offset, length, GCHandle.ToIntPtr(wrapped), ReadAsyncPartialCallbackImpl);
    }

    public void Write(string name, byte[] data)
    {
        var res = Methods.Write(_methodsPtr, name, data, data.Length);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    [MonoPInvokeCallback]
    private static void WriteAsyncCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as WriteAsyncHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void WriteAsync(string name, byte[] data, WriteAsyncHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.WriteAsync(_methodsPtr, name, data, data.Length, GCHandle.ToIntPtr(wrapped), WriteAsyncCallbackImpl);
    }

    public void Delete(string name)
    {
        var res = Methods.Delete(_methodsPtr, name);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public bool Exists(string name)
    {
        var ret = new bool();
        var res = Methods.Exists(_methodsPtr, name, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public int Count()
    {
        var ret = new int();
        Methods.Count(_methodsPtr, ref ret);
        return ret;
    }

    public FileStat Stat(string name)
    {
        var ret = new FileStat();
        var res = Methods.Stat(_methodsPtr, name, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public FileStat StatAt(int index)
    {
        var ret = new FileStat();
        var res = Methods.StatAt(_methodsPtr, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public string GetPath()
    {
        var ret = new StringBuilder(4096);
        var res = Methods.GetPath(_methodsPtr, ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret.ToString();
    }
}

public partial class StoreManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void EntitlementCreateHandler(IntPtr ptr, ref Entitlement entitlement);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void EntitlementDeleteHandler(IntPtr ptr, ref Entitlement entitlement);

        internal EntitlementCreateHandler OnEntitlementCreate;

        internal EntitlementDeleteHandler OnEntitlementDelete;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchSkusCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchSkusMethod(IntPtr methodsPtr, IntPtr callbackData, FetchSkusCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CountSkusMethod(IntPtr methodsPtr, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetSkuMethod(IntPtr methodsPtr, long skuId, ref Sku sku);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetSkuAtMethod(IntPtr methodsPtr, int index, ref Sku sku);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchEntitlementsCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchEntitlementsMethod(IntPtr methodsPtr, IntPtr callbackData, FetchEntitlementsCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CountEntitlementsMethod(IntPtr methodsPtr, ref int count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetEntitlementMethod(IntPtr methodsPtr, long entitlementId, ref Entitlement entitlement);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetEntitlementAtMethod(IntPtr methodsPtr, int index, ref Entitlement entitlement);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result HasSkuEntitlementMethod(IntPtr methodsPtr, long skuId, ref bool hasEntitlement);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void StartPurchaseCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void StartPurchaseMethod(IntPtr methodsPtr, long skuId, IntPtr callbackData, StartPurchaseCallback callback);

        internal FetchSkusMethod FetchSkus;

        internal CountSkusMethod CountSkus;

        internal GetSkuMethod GetSku;

        internal GetSkuAtMethod GetSkuAt;

        internal FetchEntitlementsMethod FetchEntitlements;

        internal CountEntitlementsMethod CountEntitlements;

        internal GetEntitlementMethod GetEntitlement;

        internal GetEntitlementAtMethod GetEntitlementAt;

        internal HasSkuEntitlementMethod HasSkuEntitlement;

        internal StartPurchaseMethod StartPurchase;
    }

    public delegate void FetchSkusHandler(Result result);

    public delegate void FetchEntitlementsHandler(Result result);

    public delegate void StartPurchaseHandler(Result result);

    public delegate void EntitlementCreateHandler(ref Entitlement entitlement);

    public delegate void EntitlementDeleteHandler(ref Entitlement entitlement);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event EntitlementCreateHandler OnEntitlementCreate = null!;

    public event EntitlementDeleteHandler OnEntitlementDelete = null!;

    internal StoreManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnEntitlementCreate = OnEntitlementCreateImpl;
        events.OnEntitlementDelete = OnEntitlementDeleteImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    [MonoPInvokeCallback]
    private static void FetchSkusCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as FetchSkusHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void FetchSkus(FetchSkusHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.FetchSkus(_methodsPtr, GCHandle.ToIntPtr(wrapped), FetchSkusCallbackImpl);
    }

    public int CountSkus()
    {
        var ret = new int();
        Methods.CountSkus(_methodsPtr, ref ret);
        return ret;
    }

    public Sku GetSku(long skuId)
    {
        var ret = new Sku();
        var res = Methods.GetSku(_methodsPtr, skuId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public Sku GetSkuAt(int index)
    {
        var ret = new Sku();
        var res = Methods.GetSkuAt(_methodsPtr, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void FetchEntitlementsCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as FetchEntitlementsHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void FetchEntitlements(FetchEntitlementsHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.FetchEntitlements(_methodsPtr, GCHandle.ToIntPtr(wrapped), FetchEntitlementsCallbackImpl);
    }

    public int CountEntitlements()
    {
        var ret = new int();
        Methods.CountEntitlements(_methodsPtr, ref ret);
        return ret;
    }

    public Entitlement GetEntitlement(long entitlementId)
    {
        var ret = new Entitlement();
        var res = Methods.GetEntitlement(_methodsPtr, entitlementId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public Entitlement GetEntitlementAt(int index)
    {
        var ret = new Entitlement();
        var res = Methods.GetEntitlementAt(_methodsPtr, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public bool HasSkuEntitlement(long skuId)
    {
        var ret = new bool();
        var res = Methods.HasSkuEntitlement(_methodsPtr, skuId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void StartPurchaseCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as StartPurchaseHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void StartPurchase(long skuId, StartPurchaseHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.StartPurchase(_methodsPtr, skuId, GCHandle.ToIntPtr(wrapped), StartPurchaseCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void OnEntitlementCreateImpl(IntPtr ptr, ref Entitlement entitlement)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.StoreManagerInstance?.OnEntitlementCreate(ref entitlement);
    }

    [MonoPInvokeCallback]
    private static void OnEntitlementDeleteImpl(IntPtr ptr, ref Entitlement entitlement)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.StoreManagerInstance?.OnEntitlementDelete(ref entitlement);
    }
}

public class VoiceManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SettingsUpdateHandler(IntPtr ptr);

        internal SettingsUpdateHandler OnSettingsUpdate;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetInputModeMethod(IntPtr methodsPtr, ref InputMode inputMode);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetInputModeCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetInputModeMethod(IntPtr methodsPtr, InputMode inputMode, IntPtr callbackData, SetInputModeCallback callback);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result IsSelfMuteMethod(IntPtr methodsPtr, ref bool mute);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetSelfMuteMethod(IntPtr methodsPtr, bool mute);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result IsSelfDeafMethod(IntPtr methodsPtr, ref bool deaf);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetSelfDeafMethod(IntPtr methodsPtr, bool deaf);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result IsLocalMuteMethod(IntPtr methodsPtr, long userId, ref bool mute);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetLocalMuteMethod(IntPtr methodsPtr, long userId, bool mute);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetLocalVolumeMethod(IntPtr methodsPtr, long userId, ref byte volume);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result SetLocalVolumeMethod(IntPtr methodsPtr, long userId, byte volume);

        internal GetInputModeMethod GetInputMode;

        internal SetInputModeMethod SetInputMode;

        internal IsSelfMuteMethod IsSelfMute;

        internal SetSelfMuteMethod SetSelfMute;

        internal IsSelfDeafMethod IsSelfDeaf;

        internal SetSelfDeafMethod SetSelfDeaf;

        internal IsLocalMuteMethod IsLocalMute;

        internal SetLocalMuteMethod SetLocalMute;

        internal GetLocalVolumeMethod GetLocalVolume;

        internal SetLocalVolumeMethod SetLocalVolume;
    }

    public delegate void SetInputModeHandler(Result result);

    public delegate void SettingsUpdateHandler();

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    public event SettingsUpdateHandler? OnSettingsUpdate;

    internal VoiceManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnSettingsUpdate = OnSettingsUpdateImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    public InputMode GetInputMode()
    {
        var ret = new InputMode();
        var res = Methods.GetInputMode(_methodsPtr, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void SetInputModeCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SetInputModeHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void SetInputMode(InputMode inputMode, SetInputModeHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SetInputMode(_methodsPtr, inputMode, GCHandle.ToIntPtr(wrapped), SetInputModeCallbackImpl);
    }

    public bool IsSelfMute()
    {
        var ret = new bool();
        var res = Methods.IsSelfMute(_methodsPtr, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public void SetSelfMute(bool mute)
    {
        var res = Methods.SetSelfMute(_methodsPtr, mute);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public bool IsSelfDeaf()
    {
        var ret = new bool();
        var res = Methods.IsSelfDeaf(_methodsPtr, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public void SetSelfDeaf(bool deaf)
    {
        var res = Methods.SetSelfDeaf(_methodsPtr, deaf);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public bool IsLocalMute(long userId)
    {
        var ret = new bool();
        var res = Methods.IsLocalMute(_methodsPtr, userId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public void SetLocalMute(long userId, bool mute)
    {
        var res = Methods.SetLocalMute(_methodsPtr, userId, mute);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    public byte GetLocalVolume(long userId)
    {
        var ret = new byte();
        var res = Methods.GetLocalVolume(_methodsPtr, userId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public void SetLocalVolume(long userId, byte volume)
    {
        var res = Methods.SetLocalVolume(_methodsPtr, userId, volume);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
    }

    [MonoPInvokeCallback]
    private static void OnSettingsUpdateImpl(IntPtr ptr)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.VoiceManagerInstance?.OnSettingsUpdate?.Invoke();
    }
}

[Obsolete]
public class AchievementManager
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiEvents
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void UserAchievementUpdateHandler(IntPtr ptr, ref UserAchievement userAchievement);

        internal UserAchievementUpdateHandler OnUserAchievementUpdate;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FfiMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetUserAchievementCallback(IntPtr ptr, Result result);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void SetUserAchievementMethod(IntPtr methodsPtr, long achievementId, byte percentComplete, IntPtr callbackData, SetUserAchievementCallback callback);

        [Obsolete]
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchUserAchievementsCallback(IntPtr ptr, Result result);

        [Obsolete]
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void FetchUserAchievementsMethod(IntPtr methodsPtr, IntPtr callbackData, FetchUserAchievementsCallback callback);

        [Obsolete]
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void CountUserAchievementsMethod(IntPtr methodsPtr, ref int count);

        [Obsolete]
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetUserAchievementMethod(IntPtr methodsPtr, long userAchievementId, ref UserAchievement userAchievement);

        [Obsolete]
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate Result GetUserAchievementAtMethod(IntPtr methodsPtr, int index, ref UserAchievement userAchievement);

        internal SetUserAchievementMethod SetUserAchievement;

        [Obsolete]
        internal FetchUserAchievementsMethod FetchUserAchievements;

        [Obsolete]
        internal CountUserAchievementsMethod CountUserAchievements;

        [Obsolete]
        internal GetUserAchievementMethod GetUserAchievement;

        [Obsolete]
        internal GetUserAchievementAtMethod GetUserAchievementAt;
    }

    [Obsolete]
    public delegate void SetUserAchievementHandler(Result result);

    [Obsolete]
    public delegate void FetchUserAchievementsHandler(Result result);

    [Obsolete]
    public delegate void UserAchievementUpdateHandler(ref UserAchievement userAchievement);

    private readonly IntPtr _methodsPtr;

    private object? _methodsStructure;

    private FfiMethods Methods
    {
        get
        {
            _methodsStructure ??= Marshal.PtrToStructure(_methodsPtr, typeof(FfiMethods));
            return (FfiMethods)(_methodsStructure ?? throw new InvalidOperationException());
        }

    }

    [Obsolete]
    public event UserAchievementUpdateHandler? OnUserAchievementUpdate;

    internal AchievementManager(IntPtr ptr, IntPtr eventsPtr, ref FfiEvents events)
    {
        if (eventsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
        InitEvents(eventsPtr, ref events);
        _methodsPtr = ptr;
        if (_methodsPtr == IntPtr.Zero) {
            throw new ResultException(Result.InternalError);
        }
    }

    private void InitEvents(IntPtr eventsPtr, ref FfiEvents events)
    {
        events.OnUserAchievementUpdate = OnUserAchievementUpdateImpl;
        Marshal.StructureToPtr(events, eventsPtr, false);
    }

    [MonoPInvokeCallback]
    private static void SetUserAchievementCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as SetUserAchievementHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void SetUserAchievement(long achievementId, byte percentComplete, SetUserAchievementHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.SetUserAchievement(_methodsPtr, achievementId, percentComplete, GCHandle.ToIntPtr(wrapped), SetUserAchievementCallbackImpl);
    }

    [MonoPInvokeCallback]
    private static void FetchUserAchievementsCallbackImpl(IntPtr ptr, Result result)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var callback = h.Target as FetchUserAchievementsHandler;
        h.Free();
        callback?.Invoke(result);
    }

    public void FetchUserAchievements(FetchUserAchievementsHandler callback)
    {
        var wrapped = GCHandle.Alloc(callback);
        Methods.FetchUserAchievements(_methodsPtr, GCHandle.ToIntPtr(wrapped), FetchUserAchievementsCallbackImpl);
    }

    public int CountUserAchievements()
    {
        var ret = new int();
        Methods.CountUserAchievements(_methodsPtr, ref ret);
        return ret;
    }

    public UserAchievement GetUserAchievement(long userAchievementId)
    {
        var ret = new UserAchievement();
        var res = Methods.GetUserAchievement(_methodsPtr, userAchievementId, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    public UserAchievement GetUserAchievementAt(int index)
    {
        var ret = new UserAchievement();
        var res = Methods.GetUserAchievementAt(_methodsPtr, index, ref ret);
        if (res != Result.Ok)
        {
            Debug.LogError(new ResultException(res));
        }
        return ret;
    }

    [MonoPInvokeCallback]
    private static void OnUserAchievementUpdateImpl(IntPtr ptr, ref UserAchievement userAchievement)
    {
        var h = GCHandle.FromIntPtr(ptr);
        var d = h.Target as Discord;
        d?.AchievementManagerInstance?.OnUserAchievementUpdate?.Invoke(ref userAchievement);
    }
}