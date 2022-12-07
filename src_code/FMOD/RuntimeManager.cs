using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AOT;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000100 RID: 256
	[AddComponentMenu("")]
	public class RuntimeManager : MonoBehaviour
	{
		// Token: 0x06000696 RID: 1686 RVA: 0x0000711C File Offset: 0x0000531C
		[MonoPInvokeCallback(typeof(DEBUG_CALLBACK))]
		private static RESULT DEBUG_CALLBACK(DEBUG_FLAGS flags, IntPtr filePtr, int line, IntPtr funcPtr, IntPtr messagePtr)
		{
			new StringWrapper(filePtr);
			StringWrapper fstring = new StringWrapper(funcPtr);
			StringWrapper fstring2 = new StringWrapper(messagePtr);
			if (flags == DEBUG_FLAGS.ERROR)
			{
				UnityEngine.Debug.LogError(string.Format("[FMOD] {0} : {1}", fstring, fstring2));
			}
			else if (flags == DEBUG_FLAGS.WARNING)
			{
				UnityEngine.Debug.LogWarning(string.Format("[FMOD] {0} : {1}", fstring, fstring2));
			}
			else if (flags == DEBUG_FLAGS.LOG)
			{
				UnityEngine.Debug.Log(string.Format("[FMOD] {0} : {1}", fstring, fstring2));
			}
			return RESULT.OK;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000071A4 File Offset: 0x000053A4
		[MonoPInvokeCallback(typeof(FMOD.SYSTEM_CALLBACK))]
		private static RESULT ERROR_CALLBACK(IntPtr system, FMOD.SYSTEM_CALLBACK_TYPE type, IntPtr commanddata1, IntPtr commanddata2, IntPtr userdata)
		{
			ERRORCALLBACK_INFO errorcallback_INFO = (ERRORCALLBACK_INFO)MarshalHelper.PtrToStructure(commanddata1, typeof(ERRORCALLBACK_INFO));
			if ((errorcallback_INFO.instancetype == ERRORCALLBACK_INSTANCETYPE.CHANNEL || errorcallback_INFO.instancetype == ERRORCALLBACK_INSTANCETYPE.CHANNELCONTROL) && errorcallback_INFO.result == RESULT.ERR_INVALID_HANDLE)
			{
				return RESULT.OK;
			}
			UnityEngine.Debug.LogError(string.Format("[FMOD] {0}({1}) returned {2} for {3} (0x{4}).", new object[]
			{
				errorcallback_INFO.functionname,
				errorcallback_INFO.functionparams,
				errorcallback_INFO.result,
				errorcallback_INFO.instancetype,
				errorcallback_INFO.instance.ToString("X")
			}));
			return RESULT.OK;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x00007248 File Offset: 0x00005448
		public static RuntimeManager Instance
		{
			get
			{
				if (RuntimeManager.initException != null)
				{
					UnityEngine.Debug.LogWarning(RuntimeManager.initException);
					return new RuntimeManager();
				}
				if (RuntimeManager.instance == null)
				{
					RESULT result = RESULT.OK;
					RuntimeManager[] array = Resources.FindObjectsOfTypeAll<RuntimeManager>();
					for (int i = 0; i < array.Length; i++)
					{
						Object.DestroyImmediate(array[i].gameObject);
					}
					GameObject gameObject = new GameObject("FMOD.UnityIntegration.RuntimeManager");
					RuntimeManager.instance = gameObject.AddComponent<RuntimeManager>();
					if (Application.isPlaying)
					{
						Object.DontDestroyOnLoad(gameObject);
					}
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					try
					{
						RuntimeUtils.EnforceLibraryOrder();
						result = RuntimeManager.instance.Initialize();
					}
					catch (Exception ex)
					{
						RuntimeManager.initException = (ex as SystemNotInitializedException);
						if (RuntimeManager.initException == null)
						{
							RuntimeManager.initException = new SystemNotInitializedException(ex);
						}
						UnityEngine.Debug.LogWarning(RuntimeManager.initException);
						return new RuntimeManager();
					}
					if (result != RESULT.OK)
					{
						UnityEngine.Debug.LogWarning(new SystemNotInitializedException(result, "Output forced to NO SOUND mode"));
					}
				}
				return RuntimeManager.instance;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x0000733C File Offset: 0x0000553C
		public static FMOD.Studio.System StudioSystem
		{
			get
			{
				return RuntimeManager.Instance.studioSystem;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x00007348 File Offset: 0x00005548
		public static FMOD.System CoreSystem
		{
			get
			{
				return RuntimeManager.Instance.coreSystem;
			}
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00007354 File Offset: 0x00005554
		public Dictionary<string, RuntimeManager.LoadedBank> GetLoadedBanks()
		{
			return this.loadedBanks;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0000735C File Offset: 0x0000555C
		private void CheckInitResult(RESULT result, string cause)
		{
			if (result != RESULT.OK)
			{
				this.ReleaseStudioSystem();
				UnityEngine.Debug.LogWarning(new SystemNotInitializedException(result, cause));
			}
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00007373 File Offset: 0x00005573
		private void ReleaseStudioSystem()
		{
			if (this.studioSystem.isValid())
			{
				this.studioSystem.release();
				this.studioSystem.clearHandle();
			}
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0000739C File Offset: 0x0000559C
		private RESULT Initialize()
		{
			RESULT result = RESULT.OK;
			Settings settings = Settings.Instance;
			this.currentPlatform = settings.FindCurrentPlatform();
			int sampleRate = this.currentPlatform.SampleRate;
			int num = Math.Min(this.currentPlatform.RealChannelCount, 256);
			int virtualChannelCount = this.currentPlatform.VirtualChannelCount;
			uint dspbufferLength = (uint)this.currentPlatform.DSPBufferLength;
			int dspbufferCount = this.currentPlatform.DSPBufferCount;
			SPEAKERMODE speakerMode = this.currentPlatform.SpeakerMode;
			OUTPUTTYPE output = this.currentPlatform.GetOutputType();
			FMOD.ADVANCEDSETTINGS advancedsettings = default(FMOD.ADVANCEDSETTINGS);
			advancedsettings.randomSeed = (uint)DateTime.UtcNow.Ticks;
			advancedsettings.maxVorbisCodecs = num;
			RuntimeManager.SetThreadAffinities(this.currentPlatform);
			this.currentPlatform.PreSystemCreate(new Action<RESULT, string>(this.CheckInitResult));
			FMOD.Studio.INITFLAGS initflags = FMOD.Studio.INITFLAGS.DEFERRED_CALLBACKS;
			if (this.currentPlatform.IsLiveUpdateEnabled)
			{
				initflags |= FMOD.Studio.INITFLAGS.LIVEUPDATE;
				advancedsettings.profilePort = (ushort)this.currentPlatform.LiveUpdatePort;
			}
			for (;;)
			{
				RESULT result2 = FMOD.Studio.System.create(out this.studioSystem);
				this.CheckInitResult(result2, "FMOD.Studio.System.create");
				result2 = this.studioSystem.getCoreSystem(out this.coreSystem);
				this.CheckInitResult(result2, "FMOD.Studio.System.getCoreSystem");
				result2 = this.coreSystem.setOutput(output);
				this.CheckInitResult(result2, "FMOD.System.setOutput");
				result2 = this.coreSystem.setSoftwareChannels(num);
				this.CheckInitResult(result2, "FMOD.System.setSoftwareChannels");
				result2 = this.coreSystem.setSoftwareFormat(sampleRate, speakerMode, 0);
				this.CheckInitResult(result2, "FMOD.System.setSoftwareFormat");
				if (dspbufferLength > 0U && dspbufferCount > 0)
				{
					result2 = this.coreSystem.setDSPBufferSize(dspbufferLength, dspbufferCount);
					this.CheckInitResult(result2, "FMOD.System.setDSPBufferSize");
				}
				result2 = this.coreSystem.setAdvancedSettings(ref advancedsettings);
				this.CheckInitResult(result2, "FMOD.System.setAdvancedSettings");
				if (settings.EnableErrorCallback)
				{
					this.errorCallback = new FMOD.SYSTEM_CALLBACK(RuntimeManager.ERROR_CALLBACK);
					result2 = this.coreSystem.setCallback(this.errorCallback, FMOD.SYSTEM_CALLBACK_TYPE.ERROR);
					this.CheckInitResult(result2, "FMOD.System.setCallback");
				}
				if (!string.IsNullOrEmpty(settings.EncryptionKey))
				{
					result2 = this.studioSystem.setAdvancedSettings(default(FMOD.Studio.ADVANCEDSETTINGS), Settings.Instance.EncryptionKey);
					this.CheckInitResult(result2, "FMOD.Studio.System.setAdvancedSettings");
				}
				if (settings.EnableMemoryTracking)
				{
					initflags |= FMOD.Studio.INITFLAGS.MEMORY_TRACKING;
				}
				this.currentPlatform.PreInitialize(this.studioSystem);
				PlatformCallbackHandler callbackHandler = this.currentPlatform.CallbackHandler;
				if (callbackHandler != null)
				{
					callbackHandler.PreInitialize(this.studioSystem, new Action<RESULT, string>(this.CheckInitResult));
				}
				result2 = this.studioSystem.initialize(virtualChannelCount, initflags, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
				if (result2 != RESULT.OK && result == RESULT.OK)
				{
					result = result2;
					output = OUTPUTTYPE.NOSOUND;
					UnityEngine.Debug.LogErrorFormat("[FMOD] Studio::System::initialize returned {0}, defaulting to no-sound mode.", new object[]
					{
						result2.ToString()
					});
				}
				else
				{
					this.CheckInitResult(result2, "Studio::System::initialize");
					if ((initflags & FMOD.Studio.INITFLAGS.LIVEUPDATE) == FMOD.Studio.INITFLAGS.NORMAL)
					{
						break;
					}
					this.studioSystem.flushCommands();
					result2 = this.studioSystem.update();
					if (result2 != RESULT.ERR_NET_SOCKET_ERROR)
					{
						break;
					}
					initflags &= ~FMOD.Studio.INITFLAGS.LIVEUPDATE;
					UnityEngine.Debug.LogWarning("[FMOD] Cannot open network port for Live Update (in-use), restarting with Live Update disabled.");
					result2 = this.studioSystem.release();
					this.CheckInitResult(result2, "FMOD.Studio.System.Release");
				}
			}
			this.currentPlatform.LoadPlugins(this.coreSystem, new Action<RESULT, string>(this.CheckInitResult));
			this.LoadBanks(settings);
			return result;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x000076EC File Offset: 0x000058EC
		private static void SetThreadAffinities(Platform platform)
		{
			foreach (ThreadAffinityGroup threadAffinityGroup in platform.ThreadAffinities)
			{
				foreach (ThreadType threadType in threadAffinityGroup.threads)
				{
					THREAD_TYPE type = RuntimeUtils.ToFMODThreadType(threadType);
					THREAD_AFFINITY affinity = RuntimeUtils.ToFMODThreadAffinity(threadAffinityGroup.affinity);
					Thread.SetAttributes(type, affinity, THREAD_PRIORITY.DEFAULT, THREAD_STACK_SIZE.DEFAULT);
				}
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0000778C File Offset: 0x0000598C
		public static int AddListener(StudioListener listener)
		{
			for (int i = 0; i < RuntimeManager.Listeners.Count; i++)
			{
				if (RuntimeManager.Listeners[i] != null && listener.gameObject == RuntimeManager.Listeners[i].gameObject)
				{
					UnityEngine.Debug.LogWarning(string.Format("[FMOD] Listener has already been added at index {0}.", i));
					return i;
				}
			}
			if (RuntimeManager.numListeners >= 8)
			{
				UnityEngine.Debug.LogWarning(string.Format("[FMOD] Max number of listeners reached : {0}.", 8));
			}
			if (RuntimeManager.Listeners.Count <= RuntimeManager.numListeners)
			{
				RuntimeManager.Listeners.Add(listener);
			}
			else
			{
				RuntimeManager.Listeners[RuntimeManager.numListeners] = listener;
			}
			RuntimeManager.numListeners++;
			int num = Mathf.Min(RuntimeManager.numListeners, 8);
			RuntimeManager.StudioSystem.setNumListeners(num);
			return RuntimeManager.numListeners - 1;
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00007870 File Offset: 0x00005A70
		public static bool RemoveListener(StudioListener listener)
		{
			int listenerNumber = listener.ListenerNumber;
			if (listenerNumber != -1)
			{
				listener.ListenerNumber = -1;
				RuntimeManager.Listeners[listenerNumber] = null;
				if (RuntimeManager.numListeners - 1 > listenerNumber)
				{
					for (int i = listenerNumber; i < RuntimeManager.Listeners.Count; i++)
					{
						if (i == RuntimeManager.Listeners.Count - 1)
						{
							RuntimeManager.Listeners[i] = null;
						}
						else
						{
							RuntimeManager.Listeners[i] = RuntimeManager.Listeners[i + 1];
							if (RuntimeManager.Listeners[i])
							{
								RuntimeManager.Listeners[i].ListenerNumber = i;
							}
						}
					}
				}
				RuntimeManager.numListeners--;
				int num = Mathf.Min(Mathf.Max(RuntimeManager.numListeners, 1), 8);
				RuntimeManager.StudioSystem.setNumListeners(num);
				return true;
			}
			return false;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00007948 File Offset: 0x00005B48
		private void Update()
		{
			if (this.studioSystem.isValid())
			{
				if (RuntimeManager.numListeners <= 0 && !this.listenerWarningIssued)
				{
					this.listenerWarningIssued = true;
					UnityEngine.Debug.LogWarning("[FMOD] Please add an 'FMOD Studio Listener' component to your a camera in the scene for correct 3D positioning of sounds.");
				}
				for (int i = 0; i < this.activeEmitters.Count; i++)
				{
					RuntimeManager.UpdateActiveEmitter(this.activeEmitters[i], false);
				}
				for (int j = 0; j < this.attachedInstances.Count; j++)
				{
					PLAYBACK_STATE playback_STATE = PLAYBACK_STATE.STOPPED;
					this.attachedInstances[j].instance.getPlaybackState(out playback_STATE);
					if (!this.attachedInstances[j].instance.isValid() || playback_STATE == PLAYBACK_STATE.STOPPED || this.attachedInstances[j].transform == null)
					{
						this.attachedInstances[j] = this.attachedInstances[this.attachedInstances.Count - 1];
						this.attachedInstances.RemoveAt(this.attachedInstances.Count - 1);
						j--;
					}
					else if (this.attachedInstances[j].rigidBody)
					{
						this.attachedInstances[j].instance.set3DAttributes(RuntimeUtils.To3DAttributes(this.attachedInstances[j].transform, this.attachedInstances[j].rigidBody));
					}
					else if (this.attachedInstances[j].rigidBody2D)
					{
						this.attachedInstances[j].instance.set3DAttributes(RuntimeUtils.To3DAttributes(this.attachedInstances[j].transform, this.attachedInstances[j].rigidBody2D));
					}
					else
					{
						this.attachedInstances[j].instance.set3DAttributes(this.attachedInstances[j].transform.To3DAttributes());
					}
				}
				if (this.isOverlayEnabled)
				{
					if (!this.overlayDrawer)
					{
						this.overlayDrawer = RuntimeManager.Instance.gameObject.AddComponent<FMODRuntimeManagerOnGUIHelper>();
						this.overlayDrawer.TargetRuntimeManager = this;
					}
					else
					{
						this.overlayDrawer.gameObject.SetActive(true);
					}
				}
				else if (this.overlayDrawer != null && this.overlayDrawer.gameObject.activeSelf)
				{
					this.overlayDrawer.gameObject.SetActive(false);
				}
				this.studioSystem.update();
			}
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00007BC7 File Offset: 0x00005DC7
		public static void RegisterActiveEmitter(StudioEventEmitter emitter)
		{
			if (!RuntimeManager.Instance.activeEmitters.Contains(emitter))
			{
				RuntimeManager.Instance.activeEmitters.Add(emitter);
			}
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00007BEB File Offset: 0x00005DEB
		public static void DeregisterActiveEmitter(StudioEventEmitter emitter)
		{
			RuntimeManager.Instance.activeEmitters.Remove(emitter);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00007C00 File Offset: 0x00005E00
		public static void UpdateActiveEmitter(StudioEventEmitter emitter, bool force = false)
		{
			bool flag = false;
			for (int i = 0; i < RuntimeManager.Listeners.Count; i++)
			{
				if (Vector3.Distance(emitter.transform.position, RuntimeManager.Listeners[i].transform.position) <= emitter.MaxDistance)
				{
					flag = true;
					break;
				}
			}
			if (force || flag != emitter.IsPlaying())
			{
				if (flag)
				{
					emitter.PlayInstance();
					return;
				}
				emitter.StopInstance();
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00007C74 File Offset: 0x00005E74
		public static void AttachInstanceToGameObject(EventInstance instance, Transform transform)
		{
			RuntimeManager.AttachedInstance attachedInstance = RuntimeManager.Instance.attachedInstances.Find((RuntimeManager.AttachedInstance x) => x.instance.handle == instance.handle);
			if (attachedInstance == null)
			{
				attachedInstance = new RuntimeManager.AttachedInstance();
				RuntimeManager.Instance.attachedInstances.Add(attachedInstance);
			}
			instance.set3DAttributes(transform.To3DAttributes());
			attachedInstance.transform = transform;
			attachedInstance.instance = instance;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00007CE8 File Offset: 0x00005EE8
		public static void AttachInstanceToGameObject(EventInstance instance, Transform transform, Rigidbody rigidBody)
		{
			RuntimeManager.AttachedInstance attachedInstance = RuntimeManager.Instance.attachedInstances.Find((RuntimeManager.AttachedInstance x) => x.instance.handle == instance.handle);
			if (attachedInstance == null)
			{
				attachedInstance = new RuntimeManager.AttachedInstance();
				RuntimeManager.Instance.attachedInstances.Add(attachedInstance);
			}
			instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, rigidBody));
			attachedInstance.transform = transform;
			attachedInstance.instance = instance;
			attachedInstance.rigidBody = rigidBody;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00007D64 File Offset: 0x00005F64
		public static void AttachInstanceToGameObject(EventInstance instance, Transform transform, Rigidbody2D rigidBody2D)
		{
			RuntimeManager.AttachedInstance attachedInstance = RuntimeManager.Instance.attachedInstances.Find((RuntimeManager.AttachedInstance x) => x.instance.handle == instance.handle);
			if (attachedInstance == null)
			{
				attachedInstance = new RuntimeManager.AttachedInstance();
				RuntimeManager.Instance.attachedInstances.Add(attachedInstance);
			}
			instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform, rigidBody2D));
			attachedInstance.transform = transform;
			attachedInstance.instance = instance;
			attachedInstance.rigidBody2D = rigidBody2D;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00007DE0 File Offset: 0x00005FE0
		public static void DetachInstanceFromGameObject(EventInstance instance)
		{
			RuntimeManager runtimeManager = RuntimeManager.Instance;
			for (int i = 0; i < runtimeManager.attachedInstances.Count; i++)
			{
				if (runtimeManager.attachedInstances[i].instance.handle == instance.handle)
				{
					runtimeManager.attachedInstances[i] = runtimeManager.attachedInstances[runtimeManager.attachedInstances.Count - 1];
					runtimeManager.attachedInstances.RemoveAt(runtimeManager.attachedInstances.Count - 1);
					return;
				}
			}
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00007E69 File Offset: 0x00006069
		public void ExecuteOnGUI()
		{
			if (this.studioSystem.isValid() && this.isOverlayEnabled)
			{
				this.windowRect = GUI.Window(base.GetInstanceID(), this.windowRect, new GUI.WindowFunction(this.DrawDebugOverlay), "FMOD Studio Debug");
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00007EA8 File Offset: 0x000060A8
		private void Start()
		{
			this.isOverlayEnabled = this.currentPlatform.IsOverlayEnabled;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00007EBC File Offset: 0x000060BC
		private void DrawDebugOverlay(int windowID)
		{
			if (this.lastDebugUpdate + 0.25f < Time.unscaledTime)
			{
				if (RuntimeManager.initException != null)
				{
					this.lastDebugText = RuntimeManager.initException.Message;
				}
				else
				{
					if (!this.mixerHead.hasHandle())
					{
						ChannelGroup channelGroup;
						this.coreSystem.getMasterChannelGroup(out channelGroup);
						channelGroup.getDSP(0, out this.mixerHead);
						this.mixerHead.setMeteringEnabled(false, true);
					}
					StringBuilder stringBuilder = new StringBuilder();
					CPU_USAGE cpu_USAGE;
					this.studioSystem.getCPUUsage(out cpu_USAGE);
					stringBuilder.AppendFormat("CPU: dsp = {0:F1}%, studio = {1:F1}%\n", cpu_USAGE.dspusage, cpu_USAGE.studiousage);
					int num;
					int num2;
					Memory.GetStats(out num, out num2, true);
					stringBuilder.AppendFormat("MEMORY: cur = {0}MB, max = {1}MB\n", num >> 20, num2 >> 20);
					int num3;
					int num4;
					this.coreSystem.getChannelsPlaying(out num3, out num4);
					stringBuilder.AppendFormat("CHANNELS: real = {0}, total = {1}\n", num4, num3);
					DSP_METERING_INFO dsp_METERING_INFO;
					this.mixerHead.getMeteringInfo(IntPtr.Zero, out dsp_METERING_INFO);
					float num5 = 0f;
					for (int i = 0; i < (int)dsp_METERING_INFO.numchannels; i++)
					{
						num5 += dsp_METERING_INFO.rmslevel[i] * dsp_METERING_INFO.rmslevel[i];
					}
					num5 = Mathf.Sqrt(num5 / (float)dsp_METERING_INFO.numchannels);
					float num6 = (num5 > 0f) ? (20f * Mathf.Log10(num5 * Mathf.Sqrt(2f))) : -80f;
					if (num6 > 10f)
					{
						num6 = 10f;
					}
					stringBuilder.AppendFormat("VOLUME: RMS = {0:f2}db\n", num6);
					this.lastDebugText = stringBuilder.ToString();
					this.lastDebugUpdate = Time.unscaledTime;
				}
			}
			GUI.Label(new Rect(10f, 20f, 290f, 100f), this.lastDebugText);
			GUI.DragWindow();
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000080A5 File Offset: 0x000062A5
		private void OnDestroy()
		{
			this.coreSystem.setCallback(null, (FMOD.SYSTEM_CALLBACK_TYPE)0U);
			this.ReleaseStudioSystem();
			RuntimeManager.initException = null;
			RuntimeManager.instance = null;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000080C7 File Offset: 0x000062C7
		private void OnApplicationPause(bool pauseStatus)
		{
			if (this.studioSystem.isValid())
			{
				RuntimeManager.PauseAllEvents(pauseStatus);
				if (pauseStatus)
				{
					this.coreSystem.mixerSuspend();
					return;
				}
				this.coreSystem.mixerResume();
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000080F8 File Offset: 0x000062F8
		private void loadedBankRegister(RuntimeManager.LoadedBank loadedBank, string bankPath, string bankName, bool loadSamples, RESULT loadResult)
		{
			if (loadResult == RESULT.OK)
			{
				loadedBank.RefCount = 1;
				if (loadSamples)
				{
					loadedBank.Bank.loadSampleData();
				}
				RuntimeManager.Instance.loadedBanks.Add(bankName, loadedBank);
			}
			else if (loadResult == RESULT.ERR_EVENT_ALREADY_LOADED)
			{
				loadedBank.RefCount = 2;
				RuntimeManager.Instance.loadedBanks.Add(bankName, loadedBank);
			}
			else
			{
				UnityEngine.Debug.LogWarning(new BankLoadException(bankPath, loadResult));
			}
			this.ExecuteSampleLoadRequestsIfReady();
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0000816C File Offset: 0x0000636C
		private void ExecuteSampleLoadRequestsIfReady()
		{
			if (this.sampleLoadRequests.Count > 0)
			{
				foreach (string key in this.sampleLoadRequests)
				{
					if (!this.loadedBanks.ContainsKey(key))
					{
						return;
					}
				}
				foreach (string text in this.sampleLoadRequests)
				{
					this.CheckInitResult(this.loadedBanks[text].Bank.loadSampleData(), string.Format("Loading sample data for bank: {0}", text));
				}
				this.sampleLoadRequests.Clear();
			}
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0000824C File Offset: 0x0000644C
		public static void LoadBankSamples(string bankName)
		{
			if (string.IsNullOrEmpty(bankName))
			{
				return;
			}
			RuntimeManager.LoadedBank loadedBank;
			if (RuntimeManager.Instance.loadedBanks.TryGetValue(bankName, out loadedBank))
			{
				loadedBank.Bank.loadSampleData();
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00008284 File Offset: 0x00006484
		public static void LoadBank(string bankName, bool loadSamples = false)
		{
			if (string.IsNullOrEmpty(bankName))
			{
				return;
			}
			if (RuntimeManager.Instance.loadedBanks.ContainsKey(bankName))
			{
				RuntimeManager.LoadedBank value = RuntimeManager.Instance.loadedBanks[bankName];
				value.RefCount++;
				if (loadSamples)
				{
					value.Bank.loadSampleData();
				}
				RuntimeManager.Instance.loadedBanks[bankName] = value;
				return;
			}
			string text = RuntimeManager.Instance.currentPlatform.GetBankFolder();
			if (!string.IsNullOrEmpty(Settings.Instance.TargetSubFolder))
			{
				text = RuntimeUtils.GetCommonPlatformPath(Path.Combine(text, Settings.Instance.TargetSubFolder));
			}
			string text2;
			if (Path.GetExtension(bankName) != ".bank")
			{
				text2 = string.Format("{0}/{1}{2}", text, bankName, ".bank");
			}
			else
			{
				text2 = string.Format("{0}/{1}", text, bankName);
			}
			RuntimeManager.LoadedBank loadedBank = default(RuntimeManager.LoadedBank);
			RESULT loadResult = RuntimeManager.Instance.studioSystem.loadBankFile(text2, LOAD_BANK_FLAGS.NORMAL, out loadedBank.Bank);
			RuntimeManager.Instance.loadedBankRegister(loadedBank, text2, bankName, loadSamples, loadResult);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00008388 File Offset: 0x00006588
		public static void LoadBank(TextAsset asset, bool loadSamples = false)
		{
			string name = asset.name;
			if (RuntimeManager.Instance.loadedBanks.ContainsKey(name))
			{
				RuntimeManager.LoadedBank loadedBank = RuntimeManager.Instance.loadedBanks[name];
				loadedBank.RefCount++;
				if (loadSamples)
				{
					loadedBank.Bank.loadSampleData();
					return;
				}
			}
			else
			{
				RuntimeManager.LoadedBank value = default(RuntimeManager.LoadedBank);
				RESULT result = RuntimeManager.Instance.studioSystem.loadBankMemory(asset.bytes, LOAD_BANK_FLAGS.NORMAL, out value.Bank);
				if (result == RESULT.OK)
				{
					value.RefCount = 1;
					RuntimeManager.Instance.loadedBanks.Add(name, value);
					if (loadSamples)
					{
						value.Bank.loadSampleData();
						return;
					}
				}
				else
				{
					if (result == RESULT.ERR_EVENT_ALREADY_LOADED)
					{
						value.RefCount = 2;
						RuntimeManager.Instance.loadedBanks.Add(name, value);
						return;
					}
					UnityEngine.Debug.LogWarning(new BankLoadException(name, result));
					return;
				}
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00008460 File Offset: 0x00006660
		private void LoadBanks(Settings fmodSettings)
		{
			if (fmodSettings.ImportType == ImportType.StreamingAssets)
			{
				if (fmodSettings.AutomaticSampleLoading)
				{
					this.sampleLoadRequests.AddRange(this.BanksToLoad(fmodSettings));
				}
				try
				{
					foreach (string bankName in this.BanksToLoad(fmodSettings))
					{
						RuntimeManager.LoadBank(bankName, false);
					}
					RuntimeManager.WaitForAllLoads();
				}
				catch (BankLoadException message)
				{
					UnityEngine.Debug.LogWarning(message);
				}
			}
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x000084EC File Offset: 0x000066EC
		private IEnumerable<string> BanksToLoad(Settings fmodSettings)
		{
			switch (fmodSettings.BankLoadType)
			{
			case BankLoadType.All:
			{
				foreach (string masterBankFileName in fmodSettings.MasterBanks)
				{
					yield return masterBankFileName + ".strings";
					yield return masterBankFileName;
					masterBankFileName = null;
				}
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				foreach (string text in fmodSettings.Banks)
				{
					yield return text;
				}
				enumerator = default(List<string>.Enumerator);
				break;
			}
			case BankLoadType.Specified:
			{
				foreach (string text2 in fmodSettings.BanksToLoad)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						yield return text2;
					}
				}
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				break;
			}
			}
			yield break;
			yield break;
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x000084FC File Offset: 0x000066FC
		public static void UnloadBank(string bankName)
		{
			if (string.IsNullOrEmpty(bankName))
			{
				return;
			}
			RuntimeManager.LoadedBank loadedBank;
			if (RuntimeManager.Instance.loadedBanks.TryGetValue(bankName, out loadedBank))
			{
				loadedBank.RefCount--;
				if (loadedBank.RefCount == 0)
				{
					loadedBank.Bank.unload();
					RuntimeManager.Instance.loadedBanks.Remove(bankName);
					RuntimeManager.Instance.sampleLoadRequests.Remove(bankName);
					return;
				}
				RuntimeManager.Instance.loadedBanks[bankName] = loadedBank;
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0000857C File Offset: 0x0000677C
		public static void UnloadBankSamples(string bankName)
		{
			if (string.IsNullOrEmpty(bankName))
			{
				return;
			}
			RuntimeManager.LoadedBank loadedBank;
			if (RuntimeManager.Instance.loadedBanks.TryGetValue(bankName, out loadedBank))
			{
				loadedBank.Bank.unloadSampleData();
			}
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x000085B4 File Offset: 0x000067B4
		public static bool AnyBankLoading()
		{
			bool flag = false;
			foreach (RuntimeManager.LoadedBank loadedBank in RuntimeManager.Instance.loadedBanks.Values)
			{
				Bank bank = loadedBank.Bank;
				LOADING_STATE loading_STATE;
				bank.getSampleLoadingState(out loading_STATE);
				flag |= (loading_STATE == LOADING_STATE.LOADING);
			}
			return flag;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00008628 File Offset: 0x00006828
		public static void WaitForAllLoads()
		{
			RuntimeManager.Instance.studioSystem.flushSampleLoading();
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0000863C File Offset: 0x0000683C
		public static Guid PathToGUID(string path)
		{
			Guid empty = Guid.Empty;
			if (path.StartsWith("{"))
			{
				Util.parseID(path, out empty);
			}
			else if (RuntimeManager.Instance.studioSystem.lookupID(path, out empty) == RESULT.ERR_EVENT_NOTFOUND)
			{
				UnityEngine.Debug.LogError(new EventNotFoundException(path));
			}
			return empty;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0000868C File Offset: 0x0000688C
		public static EventInstance CreateInstance(string path, bool set_3d = true)
		{
			EventInstance result;
			try
			{
				result = RuntimeManager.CreateInstance(RuntimeManager.PathToGUID(path), set_3d);
			}
			catch (EventNotFoundException)
			{
				UnityEngine.Debug.LogError(new EventNotFoundException(path));
				result = default(EventInstance);
			}
			return result;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000086D4 File Offset: 0x000068D4
		public static EventInstance CreateInstance(Guid guid, bool set_3d = true)
		{
			EventInstance result;
			RuntimeManager.GetEventDescription(guid).createInstance(out result);
			return result;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000086F4 File Offset: 0x000068F4
		public static void PlayOneShot(string path, Vector3 position = default(Vector3))
		{
			try
			{
				RuntimeManager.PlayOneShot(RuntimeManager.PathToGUID(path), position);
			}
			catch (EventNotFoundException)
			{
				UnityEngine.Debug.LogError(new EventNotFoundException(path));
			}
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00008730 File Offset: 0x00006930
		public static void PlayOneShot(Guid guid, Vector3 position = default(Vector3))
		{
			EventInstance eventInstance = RuntimeManager.CreateInstance(guid, true);
			eventInstance.set3DAttributes(position.To3DAttributes());
			eventInstance.start();
			eventInstance.release();
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00008764 File Offset: 0x00006964
		public static void PlayOneShotAttached(string path, GameObject gameObject)
		{
			try
			{
				RuntimeManager.PlayOneShotAttached(RuntimeManager.PathToGUID(path), gameObject);
			}
			catch (EventNotFoundException)
			{
				UnityEngine.Debug.LogWarning("[FMOD] Event not found: " + path);
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000087A4 File Offset: 0x000069A4
		public static void PlayOneShotAttached(Guid guid, GameObject gameObject)
		{
			EventInstance eventInstance = RuntimeManager.CreateInstance(guid, true);
			RuntimeManager.AttachInstanceToGameObject(eventInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
			eventInstance.start();
			eventInstance.release();
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000087DC File Offset: 0x000069DC
		public static EventDescription GetEventDescription(string path)
		{
			EventDescription result;
			try
			{
				result = RuntimeManager.GetEventDescription(RuntimeManager.PathToGUID(path));
			}
			catch (EventNotFoundException)
			{
				UnityEngine.Debug.LogError(new EventNotFoundException(path));
				result = default(EventDescription);
			}
			return result;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00008820 File Offset: 0x00006A20
		public static EventDescription GetEventDescription(Guid guid)
		{
			EventDescription eventDescription;
			if (RuntimeManager.Instance.cachedDescriptions.ContainsKey(guid) && RuntimeManager.Instance.cachedDescriptions[guid].isValid())
			{
				eventDescription = RuntimeManager.Instance.cachedDescriptions[guid];
			}
			else
			{
				if (RuntimeManager.Instance.studioSystem.getEventByID(guid, out eventDescription) != RESULT.OK)
				{
					throw new EventNotFoundException(guid);
				}
				if (eventDescription.isValid())
				{
					RuntimeManager.Instance.cachedDescriptions[guid] = eventDescription;
				}
			}
			return eventDescription;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x000088A2 File Offset: 0x00006AA2
		public static void SetListenerLocation(GameObject gameObject, Rigidbody rigidBody, GameObject attenuationObject = null)
		{
			RuntimeManager.SetListenerLocation(0, gameObject, rigidBody, attenuationObject);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000088B0 File Offset: 0x00006AB0
		public static void SetListenerLocation(int listenerIndex, GameObject gameObject, Rigidbody rigidBody, GameObject attenuationObject = null)
		{
			if (attenuationObject)
			{
				RuntimeManager.Instance.studioSystem.setListenerAttributes(listenerIndex, RuntimeUtils.To3DAttributes(gameObject.transform, rigidBody), attenuationObject.transform.position.ToFMODVector());
				return;
			}
			RuntimeManager.Instance.studioSystem.setListenerAttributes(listenerIndex, RuntimeUtils.To3DAttributes(gameObject.transform, rigidBody));
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00008910 File Offset: 0x00006B10
		public static void SetListenerLocation(GameObject gameObject, Rigidbody2D rigidBody2D, GameObject attenuationObject = null)
		{
			RuntimeManager.SetListenerLocation(0, gameObject, rigidBody2D, attenuationObject);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0000891C File Offset: 0x00006B1C
		public static void SetListenerLocation(int listenerIndex, GameObject gameObject, Rigidbody2D rigidBody2D, GameObject attenuationObject = null)
		{
			if (attenuationObject)
			{
				RuntimeManager.Instance.studioSystem.setListenerAttributes(listenerIndex, RuntimeUtils.To3DAttributes(gameObject.transform, rigidBody2D), attenuationObject.transform.position.ToFMODVector());
				return;
			}
			RuntimeManager.Instance.studioSystem.setListenerAttributes(listenerIndex, RuntimeUtils.To3DAttributes(gameObject.transform, rigidBody2D));
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0000897C File Offset: 0x00006B7C
		public static void SetListenerLocation(GameObject gameObject, GameObject attenuationObject = null)
		{
			RuntimeManager.SetListenerLocation(0, gameObject, attenuationObject);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00008988 File Offset: 0x00006B88
		public static void SetListenerLocation(int listenerIndex, GameObject gameObject, GameObject attenuationObject = null)
		{
			if (attenuationObject)
			{
				RuntimeManager.Instance.studioSystem.setListenerAttributes(listenerIndex, gameObject.transform.To3DAttributes(), attenuationObject.transform.position.ToFMODVector());
				return;
			}
			RuntimeManager.Instance.studioSystem.setListenerAttributes(listenerIndex, gameObject.transform.To3DAttributes());
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x000089E8 File Offset: 0x00006BE8
		public static Bus GetBus(string path)
		{
			Bus result;
			if (RuntimeManager.StudioSystem.getBus(path, out result) != RESULT.OK)
			{
				UnityEngine.Debug.LogWarning(new BusNotFoundException(path));
			}
			return result;
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00008A14 File Offset: 0x00006C14
		public static VCA GetVCA(string path)
		{
			VCA result;
			if (RuntimeManager.StudioSystem.getVCA(path, out result) != RESULT.OK)
			{
				UnityEngine.Debug.LogWarning(new VCANotFoundException(path));
			}
			return result;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00008A40 File Offset: 0x00006C40
		public static void PauseAllEvents(bool paused)
		{
			Bus bus;
			if (RuntimeManager.HasBanksLoaded && RuntimeManager.StudioSystem.getBus("bus:/", out bus) == RESULT.OK)
			{
				bus.setPaused(paused);
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00008A74 File Offset: 0x00006C74
		public static void MuteAllEvents(bool muted)
		{
			Bus bus;
			if (RuntimeManager.HasBanksLoaded && RuntimeManager.StudioSystem.getBus("bus:/", out bus) == RESULT.OK)
			{
				bus.setMute(muted);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00008AA7 File Offset: 0x00006CA7
		public static bool IsInitialized
		{
			get
			{
				return RuntimeManager.instance != null && RuntimeManager.instance.studioSystem.isValid();
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00008AC7 File Offset: 0x00006CC7
		public static bool HasBanksLoaded
		{
			get
			{
				return RuntimeManager.Instance.loadedBanks.Count > 1;
			}
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00008ADB File Offset: 0x00006CDB
		public static bool HasBankLoaded(string loadedBank)
		{
			return RuntimeManager.Instance.loadedBanks.ContainsKey(loadedBank);
		}

		// Token: 0x04000521 RID: 1313
		private static SystemNotInitializedException initException = null;

		// Token: 0x04000522 RID: 1314
		private static RuntimeManager instance;

		// Token: 0x04000523 RID: 1315
		private Platform currentPlatform;

		// Token: 0x04000524 RID: 1316
		private DEBUG_CALLBACK debugCallback;

		// Token: 0x04000525 RID: 1317
		private FMOD.SYSTEM_CALLBACK errorCallback;

		// Token: 0x04000526 RID: 1318
		private FMOD.Studio.System studioSystem;

		// Token: 0x04000527 RID: 1319
		private FMOD.System coreSystem;

		// Token: 0x04000528 RID: 1320
		private DSP mixerHead;

		// Token: 0x04000529 RID: 1321
		private Dictionary<string, RuntimeManager.LoadedBank> loadedBanks = new Dictionary<string, RuntimeManager.LoadedBank>();

		// Token: 0x0400052A RID: 1322
		private List<string> sampleLoadRequests = new List<string>();

		// Token: 0x0400052B RID: 1323
		private Dictionary<Guid, EventDescription> cachedDescriptions = new Dictionary<Guid, EventDescription>(new RuntimeManager.GuidComparer());

		// Token: 0x0400052C RID: 1324
		private List<StudioEventEmitter> activeEmitters = new List<StudioEventEmitter>();

		// Token: 0x0400052D RID: 1325
		private List<RuntimeManager.AttachedInstance> attachedInstances = new List<RuntimeManager.AttachedInstance>(128);

		// Token: 0x0400052E RID: 1326
		private bool listenerWarningIssued;

		// Token: 0x0400052F RID: 1327
		protected bool isOverlayEnabled;

		// Token: 0x04000530 RID: 1328
		private FMODRuntimeManagerOnGUIHelper overlayDrawer;

		// Token: 0x04000531 RID: 1329
		private Rect windowRect = new Rect(10f, 10f, 300f, 100f);

		// Token: 0x04000532 RID: 1330
		private string lastDebugText;

		// Token: 0x04000533 RID: 1331
		private float lastDebugUpdate;

		// Token: 0x04000534 RID: 1332
		public const string BankStubPrefix = "bank stub:";

		// Token: 0x04000535 RID: 1333
		public static List<StudioListener> Listeners = new List<StudioListener>();

		// Token: 0x04000536 RID: 1334
		private static int numListeners = 0;

		// Token: 0x0200012B RID: 299
		public struct LoadedBank
		{
			// Token: 0x0400062F RID: 1583
			public Bank Bank;

			// Token: 0x04000630 RID: 1584
			public int RefCount;
		}

		// Token: 0x0200012C RID: 300
		private class GuidComparer : IEqualityComparer<Guid>
		{
			// Token: 0x0600076C RID: 1900 RVA: 0x0000B520 File Offset: 0x00009720
			bool IEqualityComparer<Guid>.Equals(Guid x, Guid y)
			{
				return x.Equals(y);
			}

			// Token: 0x0600076D RID: 1901 RVA: 0x0000B52A File Offset: 0x0000972A
			int IEqualityComparer<Guid>.GetHashCode(Guid obj)
			{
				return obj.GetHashCode();
			}
		}

		// Token: 0x0200012D RID: 301
		private class AttachedInstance
		{
			// Token: 0x04000631 RID: 1585
			public EventInstance instance;

			// Token: 0x04000632 RID: 1586
			public Transform transform;

			// Token: 0x04000633 RID: 1587
			public Rigidbody rigidBody;

			// Token: 0x04000634 RID: 1588
			public Rigidbody2D rigidBody2D;
		}
	}
}
