In this project I focused my attention, besides the course content, to learn how structure an project using Assemblies Definitions

- I created An Core assembly that holds the principal gameplay features and systems
    - And Assembly References to the Configurations files (SO's) and Settings (Input and other things) CoreConfiguration.asmref and CoreSettings.asmref
- After that I created an Core.UI that holds only UI related code
    - And to know about some gameplay data, like score after killing a ship,
    I created an Shared assembly, Core.Shared.asmdef, I don´t know if this is
    the cleanest approach but I was the way I got it working without making
    circular references (Core -> Core.UI / Core.UI -> Core)
    This assembly its supposed to hold only data that should be shared

In the context of this project the Shared Data is only and Score scriptable object

Core (ScoreManager) -> Core.Shared (ScoreUpdaterSO) <- Core.UI (ScoreUpdater)

My project exploded and a lot of assets is missing from this repo, for some reason, F
