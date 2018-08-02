# stampery-sharp
StamperySharp is the C# Client for Stampery API, a blockchain-powered, industrial-scale timestamping and certification platform.

```csharp

var stamperyClient = new StamperySharpClient("your-client-id", "your-secret");
var result = stamperyClient.Stamp("fa814e37ad092518b0b33ed1f21c8bac4daed663435abba01e369399522279e5");

```
