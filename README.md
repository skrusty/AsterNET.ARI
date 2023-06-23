
Arke.ARI
============

Arke.ARI is a fork of the AsterNET.ARI project started by the AsterNET team.. It allows you to develop against Stasis ARI for Asterisk using modern .NET platforms.

### Where to get Arke.ARI
**Nuget** http://www.nuget.org/packages/Arke.ARI/
```
PM> Install-Package Arke.ARI
```
**Releases** https://github.com/seiggy/Arke.ARI/releases

### Current Development
* Support for ARI Events
* Support for ARI Actions
* Support for ARI Models
* [Middleware Support](https://github.com/skrusty/AsterNET-ARI-Middleware-Queue)
* [AsterNET ARI Proxy](https://github.com/skrusty/AsterNET-ARI-Proxy)
* Async/Await Support
* Supports ARI up to Asterisk 20
* Fully virtualized to support mocking for unit tests


### AsterNET on IRC
Join in the conversation on Freenode, #asternet

### Cross Platform
Arke.ARI is built ontop of .NET Standard 2.0, so it will support all modern and supported .NET platforms.

## Examples

### Example Usage
coming soon

### Example Applications
* [Simple Bridge Example](https://github.com/seiggy/Arke.ARI/blob/master/Arke.ARI.SimpleBridge/Program.cs) - demonstrates how to create a bridge, play MOH on it and add and remove channels from the bridge.
* [Record and Playback](https://github.com/seiggy/Arke.ARI/blob/master/Sample-RecordAndPlayback/Program.cs) - Demonstrates how to record and playback on a channel.
* [Simple Conference Example](https://github.com/seiggy/Arke.ARI/blob/master/Arke.ARI.SimpleBridge/Program.cs) Sample Conference application using ARI.
* [ari-examples](https://github.com/asterisk/ari-examples)
ARI Samples managed by the Asterisk ARI Team (asternet.ari examples end with .cs)

### Blog
You can read about AsterNET.ARI and the original AsterNET framework on my blog: www.xdev.net or follow me on twitter (@benjmerrills) to get involved.
