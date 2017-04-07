[![Build Status](https://travis-ci.org/skrusty/AsterNET.ARI.svg?branch=master)](https://travis-ci.org/skrusty/AsterNET.ARI)

AsterNET.ARI
============

AsterNET.ARI is an incubation project and addition to the AsterNET framework for .NET. It allows you to develop against Stasis ARI for Asterisk using the .NET framework.

### Where to get AsterNET.ARI
**Nuget** http://www.nuget.org/packages/AsterNET.ARI/
```
PM> Install-Package AsterNET.ARI
```
**Releases** https://github.com/skrusty/AsterNET.ARI/releases

### Current Development
* Support for ARI Events
* Support for ARI Actions
* Support for ARI Models
* [Middleware Support](https://github.com/skrusty/AsterNET-ARI-Middleware-Queue)
* [AsterNET ARI Proxy](https://github.com/skrusty/AsterNET-ARI-Proxy)
* Async/Await Support
* Supports ARI up to Asterisk 13.5


### AsterNET on IRC
Join in the conversation on Freenode, #asternet

### Cross Platform
We are trying to ensure all .NET libs used are both .NET and mono compatible so ARI applications can be run on both windows and linux or any other OS with .NET or mono implementations.

## Examples

### Example Usage
coming soon

### Example Applications
* [Simple Bridge Example](https://github.com/skrusty/AsterNET.ARI/blob/master/AsterNET.ARI.SimpleBridge/Program.cs) - demonstrates how to create a bridge, play MOH on it and add and remove channels from the bridge.
* [Record and Playback](https://github.com/skrusty/AsterNET.ARI/blob/master/Sample-RecordAndPlayback/Program.cs) - Demonstrates how to record and playback on a channel.
* [Simple Conference Example](https://github.com/skrusty/AsterNET.ARI/blob/master/AsterNET.ARI.SimpleBridge/Program.cs) Sample Conference application using ARI.
* [ari-examples](https://github.com/asterisk/ari-examples)
ARI Samples managed by the Asterisk ARI Team (asternet.ari examples end with .cs)

### Blog
You can read about AsterNET.ARI and the original AsterNET framework on my blog: www.xdev.net or follow me on twitter (@benjmerrills) to get involved.
