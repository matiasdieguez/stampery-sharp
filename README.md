# stampery-sharp

## Setup
- Get ClientId and Secret from your dashboard after register at https://api-dashboard.stampery.com/signup
- Install the NuGet package in your project

```

install-package stamperysharp

```

## Usage:

```csharp

var stamperyClient = new StamperySharpClient("your-client-id", "your-secret");
var result = stamperyClient.Stamp("fa814e37ad092518b0b33ed1f21c8bac4daed663435abba01e369399522279e5");

```
