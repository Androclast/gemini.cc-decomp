# CRACKING.md

Run in a VM you're willing to throw away. The original binary erases its own PE headers and screenshots your desktop on startup. Treat it like the malware it is.

## 1. Cut tamper protections

Flip the defaults in `Configuration/StrictConfigSerializer.cs:GetDefault` so `AntiCheatConfig` ships with all five flags off:

```csharp
EnableAntiDebug = false;
EnableAntiVM = false;
EnableAntiDump = false;
EnableHooksDetection = false;
EnableProcessHiding = false;
```

Belt-and-braces — early-`return;` from `StartMonitoring` / `Initialize` in:

- `AntiCheat/AntiDebugMonitor.cs`, `AntiDumpProcessDetector.cs`, `AntiDumpToolMonitor.cs`, `AntiDumpThreadMonitor.cs`, `AntiDumpFileMonitor.cs`
- `AntiCheat/VmDetector.cs`, `VmRuntimeMonitor.cs`, `HardwareEnvironmentDetector.cs`, `MemoryThreatMonitor.cs`
- `AntiCheat/PeHeaderEraser.cs:EraseHeaders`
- `AntiCheat/CheatEngineKiller.cs:DetectAndKillCheatEngine`
- `AntiCheat/MemoryAccessBlocker.cs:BlockOpenProcess` and `:BlockReadProcessMemory`
- `AntiCheat/ProcessHider.cs:HideFromProcessExplorer`, `:HideFromTaskManager`, `:HideFromDumpers`
- `AntiCheat/WatcherProcess.cs:StartWatcher`

`Bootstrap/BootstrapHooks.cs:InitializeC2Client` + `:InitializeTelemetrySystem` — early-return; they're called from the entry hook.

Now the binary survives `dnSpy` and a sandboxed VM.

## 2. Cut phone-homes

| File | Method | What |
| --- | --- | --- |
| `Auth/HostAvailabilityChecker.cs` | `CheckHostOrExitAsync` | exits the host if `31.177.83.245:3001` is offline — return immediately |
| `Auth/EndpointValidator.cs` | `ValidateAllEndpointsAsync` | return a passing summary |
| `Auth/JwtTokenValidator.cs` | `ValidateTokenAsync`, `StartPeriodicValidationAsync` | return `true`; cancel the timer |
| `Auth/WatermarkValidator.cs` | `ValidateWatermark` | return early |
| `Auth/RuntimeTokenVerifier.cs` | `VerifyRuntimeContext` | return early |
| `Auth/VersionChecker.cs`, `Auth/ApiUrlValidator.cs` | `StartMonitoring` | return |
| `Telemetry/TelemetryHttpClient.cs` | every `Send*Async` | return false |
| `Telemetry/TelemetryCollector.cs` | `SendTelemetryAsync`, `SendScreenshotAsync`, ctor's screenshot loop | gut the timer in the ctor |
| `Telemetry/TelemetryQueue.cs` | `Initialize`, `QueueEvent`, `BatchSendCallback` | early-return from `Initialize`; never starts |
| `Telemetry/UserDataCollector.cs` | `CollectAndSendAsync`, `GetPublicIpAddress` | return null |
| `Telemetry/DiscordRelayClient.cs` | `ConnectAsync` | early-return false (the rest of the code handles `IsConnected == false`) |
| `Telemetry/DiscordRpcManager.cs` | ctor / `OnReady` | don't construct it |
| `Bootstrap/BootstrapHooks.cs` | `SendStartupScreenshotAsync`, `SendSecurityScreenshot`, `HandleC2*Async` | return |
| `AntiCheat/ProtectionSequence.cs` | `SendSecurityAlertAsync`, `SendScreenshotAsync` | return |
| `Localization/ChatTranslatePatch.cs` | the whole patch | disable — routes other players' chat through `ftapi.pythonanywhere.com` |

Now the binary doesn't phone home.

## 3. Re-embed the payload resources

Without the resources, every `Assembly.GetManifestResourceStream(...)` callsite in `Resources/*.cs` and `Bootstrap/EmbeddedNativeLibraryLoader.cs` returns `null` and the cheat NREs on first overlay draw. `ImGuiImpl.dll` in particular gates the menu — no resources, no UI.

`payload/` already holds all 459 files flat, with the logical name baked into the filename (`Kaban.cc.Resources.Sounds.Disable.Disable1.wav`, etc.). Add this to `cheat/Kaban.cc.csproj`:

```xml
<ItemGroup>
  <EmbeddedResource Include="..\payload\Kaban.cc.Resources.*">
    <LogicalName>%(Filename)%(Extension)</LogicalName>
  </EmbeddedResource>
</ItemGroup>
```

The existing `Хитролох_иди_нахуй._________72_8_6__5_` `EmbeddedResource` line stays — the obfuscator decoder still reads from it.

## Sanity check

1. `strings rebuilt.dll | grep -E "(31\.177\.83\.245|api\.ipify|icanhazip|ftapi\.pythonanywhere|RobusterHome)"` — any hit means a phone-home call you missed.
2. `ildasm rebuilt.dll /text | grep -c '.mresource public'` — should be ~460.
3. Run with `dnSpy` attached. If you reach `Main` without the process exiting, tamper protections are gutted.
4. Run with the network unplugged. If anything throws or the process exits, you missed an `await` somewhere — telemetry calls are scattered across feature folders.
5. Watch `%TEMP%` for `kaban_collect_*` directories. If any appear, `UserDataCollector` is still alive.
